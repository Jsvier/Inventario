# Demo sobre ASP.NET Core 2.0 para redhat

proyecto de pruebas de ASP.NET Core con jwt, oracle client , pruebas unitarias y pruebas de integracion sobre docker.

## Demo

``` comando dotnet
inventory/
    web-api-inventory/
        api-inventory.csproj
            dotnet add package Swashbuckle.AspNetCore
            dotnet add package Dapper -Version 1.50.5
            dotnet add package Oracle.ManagedDataAccess.Core
            dotnet add package Microsoft.AspNetCore.Mvc.DataAnnotations --version 2.2.0
            dotnet add package JWT --version 5.0.1
            dotnet run
    web-api-inventory.UnitTests/
            web-api-inventory.UnitTests.csproj
                dotnet add package Microsoft.AspNetCore.Mvc.Core
                dotnet add package Microsoft.AspNetCore.Mvc.Abstractions
                dotnet add package Microsoft.AspNetCore.Mvc.ViewFeatures
    web-api-inventory.IntegrationTests/
        web-api-inventory.IntegrationTests.csproj
            dotnet add reference ../web-api-inventory/api-inventory.csproj
            dotnet add package Microsoft.AspNetCore.TestHost
            dotnet add package Microsoft.Extensions.Configuration.FileExtensions
            dotnet add package Microsoft.Extensions.Configuration.Json
            dotnet add package Microsoft.AspNetCore.Cors --version 2.2.0
            dotnet add package MicroNetCore.AspNetCore.ConfigurationExtensions --version 0.0.2-alpha
            dotnet add package AggregateException.Extensions.Handler --version 1.2.0
            dotnet test

    docker
        docker build -t web-api-inventory .
        docker run --name web-api-inventory-developer --rm -it -p 8080:80 web-api-inventory
        docker-compose up
```