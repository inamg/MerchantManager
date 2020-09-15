FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS builder
ARG Configuration=Release
WORKDIR /src
COPY *.sln ./
COPY Andromeda.MerchantManager.Api/Andromeda.MerchantManager.Api.csproj Andromeda.MerchantManager.Api/
COPY Andromeda.MerchantManager.Data/Andromeda.MerchantManager.Data.csproj Andromeda.MerchantManager.Data/
COPY Andromeda.MerchantManager.Tests/Andromeda.MerchantManager.Tests.csproj Andromeda.MerchantManager.Tests/
RUN dotnet restore
COPY . .
WORKDIR /src/Andromeda.MerchantManager.Api
RUN dotnet build -c $Configuration -o /app

FROM builder AS publish
ARG Configuration=Release
RUN dotnet publish -c $Configuration -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Andromeda.MerchantManager.Api.dll"]