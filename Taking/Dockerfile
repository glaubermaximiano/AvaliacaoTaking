# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Taking.WebApi/Taking.WebApi.csproj", "Taking.WebApi/"]
COPY ["Taking.Aplicacao/Taking.Aplicacao.csproj", "Taking.Aplicacao/"]
COPY ["Taking.Dominio/Taking.Dominio.csproj", "Taking.Dominio/"]
COPY ["Taking.Infra.IOC/Taking.Infra.IOC.csproj", "Taking.Infra.IOC/"]
COPY ["Taking.Infra.Dados/Taking.Infra.Dados.csproj", "Taking.Infra.Dados/"]
RUN dotnet restore "./Taking.WebApi/Taking.WebApi.csproj"
COPY . .
WORKDIR "/src/Taking.WebApi"
RUN dotnet build "./Taking.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Taking.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Taking.WebApi.dll"]