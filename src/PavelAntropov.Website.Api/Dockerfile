FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PavelAntropov.Website.Api/PavelAntropov.Website.Api.csproj", "PavelAntropov.Website.Api/"]
RUN dotnet restore "PavelAntropov.Website.Api/PavelAntropov.Website.Api.csproj"
COPY . .
WORKDIR "/src/PavelAntropov.Website.Api"
RUN dotnet build "./PavelAntropov.Website.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PavelAntropov.Website.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PavelAntropov.Website.Api.dll"]
