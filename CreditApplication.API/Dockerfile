# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar archivos de la solución
COPY ["../CreditApplication.API/CreditApplication.API.csproj", "./"]
COPY ["CreditApplication.Application/CreditApplication.Application.csproj", "CreditApplication.Application/"]
COPY ["CreditApplication.Domain/CreditApplication.Domain.csproj", "CreditApplication.Domain/"]
COPY ["CreditApplication.Infrastructure/CreditApplication.Infrastructure.csproj", "CreditApplication.Infrastructure/"]

# Restaurar dependencias
RUN dotnet restore "CreditApplication.API/CreditApplication.API.csproj"

# Copiar el resto de los archivos
COPY . .

# Compilar en modo Release
WORKDIR "/src/CreditApplication.API"
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CreditApplication.API.dll"]
