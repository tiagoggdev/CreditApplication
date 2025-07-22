ARG DOTNET_VERSION=9.0-alpine
ARG BUILD_CONFIGURATION=Release

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build
WORKDIR /src

COPY ["CreditApplication.Domain/", "CreditApplication.Domain/"]
COPY ["CreditApplication.Application/", "CreditApplication.Application/"]
COPY ["CreditApplication/CreditApplication.Infrastructure", "CreditApplication.Infrastructure/"]

WORKDIR /src/CreditApplication.API
RUN dotnet restore "./CreditApplication.API.csproj"
RUN dotnet build "./CreditApplication.API.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet publish -c Release -o /app/publish

