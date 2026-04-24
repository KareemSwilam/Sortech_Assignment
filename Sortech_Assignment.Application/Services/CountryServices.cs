using Sortech_Assignment.Application.Dtos.CountryDtos;
using Sortech_Assignment.Application.IServices;
using Sortech_Assignment.Application.Result;
using Sortech_Assignment.Domain.IRepository;
using Sortech_Assignment.Domain.Models;

namespace Sortech_Assignment.Application.Services
{
    public class CountryServices : ICountryServices
    {
        private readonly ILocationServices _locationServices;
        private readonly IUnitOfWork _unit;
        public CountryServices(ILocationServices locationServices, IUnitOfWork unit)
        {
            _locationServices = locationServices;
            _unit = unit;
        }
        public async Task<CustomResult> AddBlockedCoutry(string coutryCode)
        {
            var countryBlocked = _unit.BlockCountryRepository.GetBlockedCountry(coutryCode);
            if (countryBlocked != null)
                return CustomResult.Failure(CustomError.ValidationError(new List<string> { "Country is already blocked" }));

            var counrty = await _locationServices.GetCountryByCode(coutryCode);
            if (counrty == null)
                return CustomResult.Failure(CustomError.NotFound(new List<string> { "Country not found, Check country code you submitted" }));
            var countryBlockedSecondCheck = _unit.BlockCountryRepository.GetBlockedCountry(counrty.Cca2);
            if (countryBlockedSecondCheck != null)
                return CustomResult.Failure(CustomError.ValidationError(new List<string> { "Country is already blocked" }));
            var saved = _unit.BlockCountryRepository.AddBlockedCountry(counrty.Cca2, counrty);
            if (!saved)
                return CustomResult.Failure(CustomError.ServerError(new List<string> { "Failed to block the country" }));
            return CustomResult.Success();
        }

        public async Task<CustomResult> AddTemporalBlockedCountry(TemporalBlockedCountryDto dto)
        {
            var countryBlocked = _unit.BlockCountryRepository.GetBlockedCountry(dto.CountryCode);
            if (countryBlocked != null)
                return CustomResult.Failure(CustomError.ValidationError(new List<string> { "Country is already blocked" }));
            var counrty = await _locationServices.GetCountryByCode(dto.CountryCode);
            if (counrty == null)
                return CustomResult.Failure(CustomError.NotFound(new List<string> { "Country not found, Check country code you submitted" }));
            var countryBlockedSecondCheck = _unit.BlockCountryRepository.GetBlockedCountry(counrty.Cca2);
            if (countryBlockedSecondCheck != null)
                return CustomResult.Failure(CustomError.ValidationError(new List<string> { "Country is already blocked" }));
            var saveBlocked = _unit.BlockCountryRepository.AddBlockedCountry(counrty.Cca2, counrty);
            var savedDuration = _unit.TemporalBlockedCountryRepository.AddTempBlockedCountry(counrty.Cca2, DateTime.UtcNow.AddMinutes(dto.DurationMinutes));
            if (!saveBlocked || !savedDuration)
                return CustomResult.Failure(CustomError.ServerError(new List<string> { "Failed to block the country temporarily" }));
            return CustomResult.Success();
        }

        public async Task<CustomResult<string>> CheckBlock()
        {
            var CountryByDto = await _locationServices.GetCountryByIPAdress();
            if (CountryByDto == null)
                return CustomResult<string>.Failure(CustomError.NotFound(new List<string> { "Failed To get Country" }));
            var countryBlocked = _unit.BlockCountryRepository.GetBlockedCountry(CountryByDto.Country.Cca2);
            var Log = new Log()
            {
                IPAddress = CountryByDto.IP,
                Timestamp = DateTime.UtcNow,
                CountryCode = CountryByDto.Country.Cca2,
                BlockedStatus = !(countryBlocked is null),
                UserAgent = CountryByDto.UserAgent
            };
            _unit.LogRepository.AddLog(Log);
            if (countryBlocked != null)
                return CustomResult<string>.Success("Country is blocked");
            return CustomResult<string>.Success("Country is not blocked");
        }

        public async Task<CustomResult<List<Country>>> GetAllCountry(CountryPaginationParams @params)
        {
            if (!string.IsNullOrEmpty(@params.Search))
            {
                var IsCode = IsValidCountryCode(@params.Search);
                if (IsCode)
                {
                    var Countries = _unit.BlockCountryRepository.GetBlockedCountryList(c => c.Cca2.Equals(@params.Search, StringComparison.OrdinalIgnoreCase) ||
                                                                                       c.Cca3.Equals(@params.Search, StringComparison.OrdinalIgnoreCase),
                                                                                       @params.PageNumber, @params.PageSize);
                    if (Countries.Count() > 0)
                        return CustomResult<List<Country>>.Success(Countries);

                }
                var CountriesNameSearch = _unit.BlockCountryRepository.GetBlockedCountryList(c => c.CommenName.Contains(@params.Search, StringComparison.OrdinalIgnoreCase) ||
                                                                                        c.OfficialName.Contains(@params.Search, StringComparison.OrdinalIgnoreCase),
                                                                                       @params.PageNumber, @params.PageSize);

                return CustomResult<List<Country>>.Success(CountriesNameSearch);


            }
            var countries = _unit.BlockCountryRepository.GetBlockedCountryList(c => true, @params.PageNumber, @params.PageSize);
            return CustomResult<List<Country>>.Success(countries);
        }

        public async Task<CustomResult<Country>> GetCountryByIPAdress(string? ipAddress)
        {
            var countryByIpDto = await _locationServices.GetCountryByIPAdress(ipAddress);
            if (countryByIpDto == null)
                return CustomResult<Country>.Failure(CustomError.NotFound(new List<string> { "Country not found for the provided IP address" }));
            return CustomResult<Country>.Success(countryByIpDto.Country);
        }

        public async Task<CustomResult> RemoveBlockedCoutry(string coutryCode)
        {
            var countryBlocked = _unit.BlockCountryRepository.GetBlockedCountry(coutryCode);
            if (countryBlocked == null)
            {
                var CheckCca2 = await _locationServices.GetCountryByCode(coutryCode);
                if (CheckCca2 == null)
                    return CustomResult.Failure(CustomError.NotFound(new List<string> { "Country not found, Check country code you submitted" }));
                var countryBlockedSecondCheck = _unit.BlockCountryRepository.GetBlockedCountry(CheckCca2.Cca2);
                if (countryBlockedSecondCheck == null)
                    return CustomResult.Failure(CustomError.NotFound(new List<string> { "Country is not blocked" }));
                var result = _unit.BlockCountryRepository.RemoveBlockedCountry(CheckCca2.Cca2);
                if (!result)
                    return CustomResult.Failure(CustomError.ServerError(new List<string> { "Failed to unblock the country" }));
                return CustomResult.Success();
            }
            var saved = _unit.BlockCountryRepository.RemoveBlockedCountry(coutryCode);
            if (!saved)
                return CustomResult.Failure(CustomError.ServerError(new List<string> { "Failed to unblock the country" }));
            return CustomResult.Success();
        }
        private bool IsValidCountryCode(string countryCode)
        {
            return !string.IsNullOrEmpty(countryCode) && (countryCode.Length == 2 || countryCode.Length == 3);
        }
    }


}
