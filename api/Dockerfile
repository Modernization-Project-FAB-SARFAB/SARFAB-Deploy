FROM mcr.microsoft.com/dotnet/sdk:8.0.300 AS build
WORKDIR /src

COPY . .

RUN dotnet restore "Modernization-SARFAB-Backend.WebAPI.sln" --no-cache
RUN dotnet publish "Modernization-SARFAB-Backend.WebAPI/Modernization-SARFAB-Backend.WebAPI.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0.4 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "Modernization-SARFAB-Backend.WebAPI.dll"]