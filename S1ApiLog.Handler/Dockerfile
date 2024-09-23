#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM hub.lumigame.com/base/dotnet/core/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["S1ApiLog.Handler/S1ApiLog.Handler.csproj", "S1ApiLog.Handler/"]
COPY ["S1ApiLog.Repositories/S1ApiLog.Repositories.csproj", "S1ApiLog.Repositories/"]
COPY ["S1ApiLog.Common/S1ApiLog.Common.csproj", "S1ApiLog.Common/"]
COPY ["S1ApiLog.Core/S1ApiLog.Core.csproj", "S1ApiLog.Core/"]
RUN dotnet restore "./S1ApiLog.Handler/./S1ApiLog.Handler.csproj"
COPY . .
WORKDIR "/src/S1ApiLog.Handler"
RUN dotnet build "./S1ApiLog.Handler.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./S1ApiLog.Handler.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM hub.lumigame.com/base/dotnet/core/aspnet:8.0-alpine-24h1.1 AS base
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "S1ApiLog.Handler.dll"]