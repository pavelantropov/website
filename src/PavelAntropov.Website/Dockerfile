FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PavelAntropov.Website/PavelAntropov.Website.csproj", "PavelAntropov.Website/"]
RUN dotnet restore "PavelAntropov.Website/PavelAntropov.Website.csproj"
COPY . .
WORKDIR "/src/PavelAntropov.Website"
RUN dotnet publish "./PavelAntropov.Website.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PavelAntropov.Website.dll"]
