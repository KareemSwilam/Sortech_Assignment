[Demo](https://drive.google.com/file/d/1QYzNGn2_sw_E6NjC4wajiTvzb_oiOUbG/view?usp=drive_link)
# Project Structure

```text
Sortech_Assignment/
├── Sortech_Assignment/               # Presentation Layer (API)
│   ├── Controllers/
│   │   ├── CountriesController.cs
│   │   ├── IPController.cs
│   │   └── LogsController.cs
│   ├── Program.cs
│   └── appsettings.json
│
├── Sortech_Assignment.Application/   # Application Layer
│   ├── Common/
│   │   └── PaginationParams.cs
│   ├── Dtos/
│   │   ├── CountryDtos/
│   │   └── LogDtos/
│   ├── IServices/
│   │   ├── ICountryServices.cs
│   │   ├── ILocationServices.cs
│   │   └── ILogServices.cs
│   ├── Services/
│   │   ├── CountryServices.cs
│   │   └── LogServices.cs
│   ├── Result/
│   │   ├── CustomResult.cs
│   │   └── CustomError.cs
│   ├── Validation/
│   │   ├── IPLockupDtoValidator.cs
│   │   ├── TemporalBlockedCountryDtoValidator.cs
│   │   └── ValidationFilter.cs
│   └── DependencyInjection/
│       └── ApplicationDI.cs
│
├── Sortech_Assignment.Domain/        # Domain Layer
│   ├── Models/
│   │   ├── Country.cs
│   │   └── Log.cs
│   ├── IRepository/
│   │   ├── IBlockCountryRepository.cs
│   │   ├── ILogRepository.cs
│   │   ├── ITemporalBlockedCountryRepository.cs
│   │   └── IUnitOfWork.cs
│   └── ValueObject/
│       └── PaginationResult.cs
│
└── Sortech_Assignment.Infrastructure/ # Infrastructure Layer
    ├── BackgroundServices/
    │   └── RemoveExpireTemporalBlocksJob.cs
    ├── ExternalCalling/
    │   └── LocationServices/
    │       ├── LocationServices.cs
    │       ├── IPgeoLocationSetting.cs
    │       ├── IPgeoLocationResponse.cs
    │       ├── IpifyResponse.cs
    │       └── RestCountriesResponse.cs
    ├── Memory/
    │   └── InMemoryContext.cs
    ├── Repository/
    │   ├── BlockCountryRepository.cs
    │   ├── LogRepository.cs
    │   ├── TemporalBlockedCountryRepository.cs
    │   └── UnitOfWork.cs
    └── DependencyInjection/
        └── InfrastructureDI.cs
```
# 🌐 Presentation Layer — API Endpoints
``` text
CountriesController — /api/countries

Method	Route	                                                         Description
POST	/block/{countryCode}	=> Permanently block a country by any valid country code (Cca2 or Cca3). Resolves to canonical Cca2 via REST Countries.	
DELETE	/block/{countryCode} =>	Remove a country from the permanent block list.	
GET	/blocked =>	Return a paginated + searchable list of all currently blocked countries. Query params: PageNumber, PageSize, Search.	
POST	/Temporal-block =>	Block a country for a specified number of minutes. Body: { CountryCode, DurationMinutes }. Validated via FluentValidation.	

IPController — /api/ip

Method	Route	                                         Description	
GET	/lookup?IPAddress=x =>	Look up full country data for a given IP address. IP validated by FluentValidation.	
GET	/check-block =>	Detect the caller's IP automatically, check if their country is blocked, and log the attempt.	

LogsController — /api/logs

Method	Route	                                               Description	
GET	/blocked-attempts =>	Return a paginated list of all IP check-block log entries. Query params: PageNumber, PageSize.	

```
# 🚀 Getting Started

``` text
Prerequisites
•	.NET 9 SDK
•	An API key from ipgeolocation.io (free tier available)

Configuration
Add your IPGeolocation API key to appsettings.json or user secrets:
{
  "Ipgeolocation": {
    "BaseUrl": "https://api.ipgeolocation.io/ipgeo",
    "Key": "YOUR_API_KEY_HERE"
  }
}

Run
git clone https://github.com/KareemSwilam/Sortech_Assignment.git
cd Sortech_Assignment
dotnet run --project Sortech_Assignment

Navigate to https://localhost:{port}/swagger to explore the API interactively via Swagger UI.
```
