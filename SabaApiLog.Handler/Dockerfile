#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM hub.lumigame.com/base/dotnet/core/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["SabaApiLog.Handler/SabaApiLog.Handler.csproj", "SabaApiLog.Handler/"]
COPY ["SabaApiLog.Repositories/SabaApiLog.Repositories.csproj", "SabaApiLog.Repositories/"]
COPY ["SabaApiLog.Common/SabaApiLog.Common.csproj", "SabaApiLog.Common/"]
COPY ["SabaApiLog.Core/SabaApiLog.Core.csproj", "SabaApiLog.Core/"]
RUN dotnet restore "./SabaApiLog.Handler/./SabaApiLog.Handler.csproj"
COPY . .
WORKDIR "/src/SabaApiLog.Handler"
RUN dotnet build "./SabaApiLog.Handler.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SabaApiLog.Handler.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM hub.lumigame.com/base/dotnet/core/aspnet:8.0-alpine-24h1.1 AS base
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SabaApiLog.Handler.dll"]