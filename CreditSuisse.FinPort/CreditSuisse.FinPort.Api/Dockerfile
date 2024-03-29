#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CreditSuisse.FinPort.Api/CreditSuisse.FinPort.Api.csproj", "CreditSuisse.FinPort.Api/"]
COPY ["CreditSuisse.FinPort.Application.Interface/CreditSuisse.FinPort.Application.Interface.csproj", "CreditSuisse.FinPort.Application.Interface/"]
COPY ["CreditSuisse.FinPort.CrossDomain/CreditSuisse.FinPort.CrossDomain.csproj", "CreditSuisse.FinPort.CrossDomain/"]
COPY ["CreditSuisse.FinPort.Application/CreditSuisse.FinPort.Application.csproj", "CreditSuisse.FinPort.Application/"]
COPY ["CreditSuisse.FinPort.Domain/CreditSuisse.FinPort.Domain.csproj", "CreditSuisse.FinPort.Domain/"]
COPY ["CreditSuisse.FinPort.Repository.MS/CreditSuisse.FinPort.Repository.MS.csproj", "CreditSuisse.FinPort.Repository.MS/"]
RUN dotnet restore "./CreditSuisse.FinPort.Api/./CreditSuisse.FinPort.Api.csproj"
COPY . .
WORKDIR "/src/CreditSuisse.FinPort.Api"
RUN dotnet build "./CreditSuisse.FinPort.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CreditSuisse.FinPort.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CreditSuisse.FinPort.Api.dll"]