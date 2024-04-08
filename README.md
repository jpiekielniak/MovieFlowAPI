<p align="center">
  <img src="https://img.icons8.com/?size=512&id=55494&format=png" width="100" />
</p>
<p align="center">
    <h1 align="center">MovieFlowAPI</h1>
</p>
<p align="center">
	<img src="https://img.shields.io/github/license/jpiekielniak/MovieFlowAPI?style=flat&color=0080ff" alt="license">
	<img src="https://img.shields.io/github/last-commit/jpiekielniak/MovieFlowAPI?style=flat&logo=git&logoColor=white&color=0080ff" alt="last-commit">
	<img src="https://img.shields.io/github/languages/top/jpiekielniak/MovieFlowAPI?style=flat&color=0080ff" alt="repo-top-language">
	<img src="https://img.shields.io/github/languages/count/jpiekielniak/MovieFlowAPI?style=flat&color=0080ff" alt="repo-language-count">
<p>
<p align="center">
    <em>Developed with the software and tools below.</em>
</p>
<p align="center">
    <img src="https://img.shields.io/badge/JSON-000000.svg?style=flat&logo=JSON&logoColor=white" alt="JSON" style="display: inline-block; margin-right: 10px;"> <img src="https://img.shields.io/badge/.NET%20C%23-5C2D91.svg?style=flat&logo=.NET&logoColor=white" alt=".NET C#" style="display: inline-block; margin-right: 10px;"> <img src="https://img.shields.io/badge/Blazor%20C%23-5C2D91.svg?style=flat&logo=Blazor&logoColor=white" alt="Blazor" style="display: inline-block; margin-right: 10px;"> <img src="https://img.shields.io/badge/Rider-000000.svg?style=flat&logo=Rider&logoColor=white" alt="Rider" style="display: inline-block; margin-right: 10px;"> <img src="https://img.shields.io/badge/DataGrip-000000.svg?style=flat&logo=DataGrip&logoColor=white" alt="DataGrip" style="display: inline-block; margin-right: 10px;"> 
	<img src="https://img.shields.io/badge/SendGrid-93C93E.svg?style=flat&logo=SendGrid&logoColor=white" alt="SendGrid" style="display: inline-block; margin-right: 10px;"> <img src="https://img.shields.io/badge/Google%20Maps%20API-4285F4.svg?style=flat&logo=Google%20Maps&logoColor=white" alt="Google Maps API" style="display: inline-block; margin-right: 10px;"> <img src="https://img.shields.io/badge/Azure%20Storage-0089D6.svg?style=flat&logo=Microsoft%20Azure&logoColor=white" alt="Azure Storage" style="display: inline-block;">
</p>


<hr>

## 🔗 Quick Links

> - [📍 Overview](#-overview)
> - [📂 Repository Structure](#-repository-structure)
> - [🚀 Getting Started](#-getting-started)
>   - [⚙️ Installation](#️-installation)
>   - [🤖 Running MovieFlowAPI](#-running-MovieFlowAPI)
>   - [🧪 Tests](#-tests)
> - [📄 License](#-license)
> - [👏 Acknowledgments](#-acknowledgments)

---

## 📍 Overview

<em>Movie FlowAPI is a .NET-based application that enables users to browse, search, and access information about movies with the added feature of allowing users to submit reviews. The application is developed utilizing a modular monolithic architecture.</em>


---


## 📂 Repository Structure

```sh
└── MovieFlowAPI/
    ├── LICENSE
    ├── MovieFlow.sln
    ├── src
    │   ├── Bootstrapper
    │   │   └── MovieFlow.Bootstrapper
    │   │       ├── Modules.cs
    │   │       ├── MovieFlow.Bootstrapper.csproj
    │   │       ├── Program.cs
    │   │       ├── Properties
    │   │       │   └── launchSettings.json
    │   │       ├── appsettings.Development.json
    │   │       └── appsettings.json
    │   ├── Modules
    │   │   ├── Movies
    │   │   │   ├── Integrations
    │   │   │   │   ├── AzureStorage
    │   │   │   │   └── GoogleMaps
    │   │   │   ├── MovieFlow.Modules.Movies.Api
    │   │   │   │   ├── Cinemas
    │   │   │   │   ├── Common
    │   │   │   │   ├── Endpoints
    │   │   │   │   ├── MovieFlow.Modules.Movies.Api.csproj
    │   │   │   │   └── MoviesModule.cs
    │   │   │   ├── MovieFlow.Modules.Movies.Application
    │   │   │   │   ├── Common
    │   │   │   │   ├── Directors
    │   │   │   │   ├── Extensions.cs
    │   │   │   │   ├── Genres
    │   │   │   │   ├── MovieFlow.Modules.Movies.Application.csproj
    │   │   │   │   ├── Movies
    │   │   │   │   ├── Reviews
    │   │   │   │   ├── Services
    │   │   │   │   └── Shared
    │   │   │   ├── MovieFlow.Modules.Movies.Core
    │   │   │   │   ├── Common
    │   │   │   │   ├── Extensions.cs
    │   │   │   │   ├── MovieFlow.Modules.Movies.Core.csproj
    │   │   │   │   └── Movies
    │   │   │   ├── MovieFlow.Modules.Movies.Infrastructure
    │   │   │   │   ├── Common
    │   │   │   │   ├── EF
    │   │   │   │   ├── Extensions.cs
    │   │   │   │   └── MovieFlow.Modules.Movies.Infrastructure.csproj
    │   │   │   └── MovieFlow.Modules.Movies.Shared
    │   │   │       ├── DTO
    │   │   │       ├── IMoviesModuleApi.cs
    │   │   │       └── MovieFlow.Modules.Movies.Shared.csproj
    │   │   ├── Newsletters
    │   │   │   ├── MovieFlow.Modules.Newsletters.Api
    │   │   │   │   ├── Common
    │   │   │   │   ├── Endpoints
    │   │   │   │   ├── MovieFlow.Modules.Newsletters.Api.csproj
    │   │   │   │   └── NewslettersModule.cs
    │   │   │   ├── MovieFlow.Modules.Newsletters.Application
    │   │   │   │   ├── EmailSubscriptions
    │   │   │   │   ├── Extensions.cs
    │   │   │   │   └── MovieFlow.Modules.Newsletters.Application.csproj
    │   │   │   ├── MovieFlow.Modules.Newsletters.Core
    │   │   │   │   ├── Extensions.cs
    │   │   │   │   ├── MovieFlow.Modules.Newsletters.Core.csproj
    │   │   │   │   └── Newsletters
    │   │   │   ├── MovieFlow.Modules.Newsletters.Infrastructure
    │   │   │   │   ├── EF
    │   │   │   │   ├── Extensions.cs
    │   │   │   │   └── MovieFlow.Modules.Newsletters.Infrastructure.csproj
    │   │   │   └── MovieFlow.Modules.Newsletters.Shared
    │   │   │       ├── Events
    │   │   │       └── MovieFlow.Modules.Newsletters.Shared.csproj
    │   │   ├── Notifications
    │   │   │   └── Emails
    │   │   │       ├── Integrations
    │   │   │       ├── MovieFlow.Modules.Emails.Api
    │   │   │       ├── MovieFlow.Modules.Emails.Application
    │   │   │       ├── MovieFlow.Modules.Emails.Core
    │   │   │       ├── MovieFlow.Modules.Emails.Infrastructure
    │   │   │       └── MovieFlow.Modules.Emails.Shared
    │   │   └── Users
    │   │       ├── MovieFlow.Modules.Users.Api
    │   │       │   ├── Common
    │   │       │   ├── Endpoints
    │   │       │   ├── MovieFlow.Modules.Users.Api.csproj
    │   │       │   └── UsersModule.cs
    │   │       ├── MovieFlow.Modules.Users.Application
    │   │       │   ├── Common
    │   │       │   ├── Extensions.cs
    │   │       │   ├── MovieFlow.Modules.Users.Application.csproj
    │   │       │   └── Users
    │   │       ├── MovieFlow.Modules.Users.Core
    │   │       │   ├── Common
    │   │       │   ├── Extensions.cs
    │   │       │   ├── MovieFlow.Modules.Users.Core.csproj
    │   │       │   └── Users
    │   │       └── MovieFlow.Modules.Users.Infrastructure
    │   │           ├── Common
    │   │           ├── EF
    │   │           ├── Extensions.cs
    │   │           └── MovieFlow.Modules.Users.Infrastructure.csproj
    │   └── Shared
    │       ├── MovieFlow.Shared.Abstractions
    │       │   ├── Auth
    │       │   │   ├── IAuthManager.cs
    │       │   │   └── JsonWebToken.cs
    │       │   ├── Contexts
    │       │   │   ├── IContext.cs
    │       │   │   └── IIdentityContext.cs
    │       │   ├── Exceptions
    │       │   │   ├── Errors
    │       │   │   ├── ExceptionResponse.cs
    │       │   │   ├── FilmFlowException.cs
    │       │   │   └── IExceptionToResponseMapper.cs
    │       │   ├── Extensions.cs
    │       │   ├── Kernel
    │       │   │   ├── Entity.cs
    │       │   │   ├── EntityState.cs
    │       │   │   └── ValueObjects
    │       │   ├── Modules
    │       │   │   └── IModule.cs
    │       │   ├── MovieFlow.Shared.Abstractions.csproj
    │       │   ├── RenderView
    │       │   │   └── IRazorViewRenderer.cs
    │       │   └── Time
    │       │       └── IClock.cs
    │       └── MovieFlow.Shared.Infrastructure
    │           ├── Api
    │           │   ├── Attributes
    │           │   └── InternalControllerFeatureProvider.cs
    │           ├── Auth
    │           │   ├── AuthManager.cs
    │           │   ├── AuthOptions.cs
    │           │   ├── DisabledAuthenticationPolicyEvaluator.cs
    │           │   ├── Exceptions
    │           │   └── Extensions.cs
    │           ├── Contexts
    │           │   ├── Context.cs
    │           │   ├── ContextFactory.cs
    │           │   ├── IContextFactory.cs
    │           │   └── IdentityContext.cs
    │           ├── Exceptions
    │           │   ├── ErrorHandlerMiddleware.cs
    │           │   ├── ExceptionCompositionRoot.cs
    │           │   ├── ExceptionToResponseMapper.cs
    │           │   ├── Extensions.cs
    │           │   └── IExceptionCompositionRoot.cs
    │           ├── Extensions.cs
    │           ├── IInitializer.cs
    │           ├── Modules
    │           │   ├── Extensions.cs
    │           │   └── ModuleLoader.cs
    │           ├── MovieFlow.Shared.Infrastructure.csproj
    │           ├── Postgres
    │           │   ├── Extensions.cs
    │           │   └── PostgresOptions.cs
    │           ├── RenderView
    │           │   └── RazorViewRenderer.cs
    │           ├── Serialization
    │           │   ├── IJsonSerializer.cs
    │           │   └── SystemTextJsonSerializer.cs
    │           ├── Services
    │           │   └── AppInitializer.cs
    │           ├── Time
    │           │   └── Clock.cs
    │           └── Validation
    │               └── ValidationBehavior.cs
    └── tests
        └── Modules
            └── Movies
                └── MovieFlow.Modules.Movies.Tests.Unit
                    ├── Commong
                    ├── Entities
                    ├── Extensions
                    ├── Handlers
                    └── MovieFlow.Modules.Movies.Tests.Unit.csproj
```

---

## 🚀 Getting Started

***Requirements***

Ensure you have the following dependencies installed on your system:

* **.NET**: `version  8.0`
* **Google Maps API Key**
* **SendGrid API Key**
* **Azure Storage**

### ⚙️ Installation

1. Clone the MovieFlowAPI repository:

```sh
git clone https://github.com/jpiekielniak/MovieFlowAPI
```

2. Change to the project directory:

```sh
cd MovieFlowAPI
```

3. Install the dependencies:

```sh
dotnet build
```

### 🤖 Running MovieFlowAPI

Use the following command to run MovieFlowAPI:

```sh
dotnet run
```

### 🧪 Tests

To execute tests, run:

```sh
dotnet test
```

---


## 📄 License

This project is protected under the [MIT License](https://choosealicense.com/licenses/mit/). For more details, refer to the [LICENSE](https://choosealicense.com/licenses/mit/) file.


---

## 👏 Acknowledgments

- @DevMentors and their project [Confab](https://github.com/devmentors/Confab) for being a source of inspiration for this project.

---
