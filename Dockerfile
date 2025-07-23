# Dockerfile
ARG DOTNET_VERSION=9.0
ARG BUILD_CONFIGURATION=Release

FROM mcr.microsoft.com/dotnet/sdk:$DOTNET_VERSION AS build
WORKDIR /src
COPY ["CreditApplication.API/", "CreditApplication.API/"]
COPY ["CreditApplication.Application/", "CreditApplication.Application/"]
COPY ["CreditApplication.Infrastructure/", "CreditApplication.Infrastructure/"]
COPY ["CreditApplication.Domain/", "CreditApplication.Domain/"]

WORKDIR /src/CreditApplication.API
RUN dotnet restore "./CreditApplication.API.csproj"
RUN dotnet build "./CreditApplication.API.csproj" -c "$BUILD_CONFIGURATION" -o /app/build
RUN dotnet publish "./CreditApplication.API.csproj" -c "$BUILD_CONFIGURATION" -o /app/publish -r linux-musl-x64
