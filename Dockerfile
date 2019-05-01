FROM microsoft/dotnet:2.2-sdk AS build
COPY web-api-inventory/*.csproj ./app/web-api-inventory/
WORKDIR /app/web-api-inventory
RUN dotnet restore

COPY web-api-inventory/. ./
RUN dotnet publish -o out /p:PublishWithAspNetCoreTargetManifest="false"

ENV ASPNETCORE_URLS http://+:80

COPY --from=build /app/web-api-inventory/out ./
ENTRYPOINT ["dotnet", "web-api-inventory.dll"]
