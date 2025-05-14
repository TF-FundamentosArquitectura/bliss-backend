FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NRG3.Bliss.API/NRG3.Bliss.API.csproj", "NRG3.Bliss.API/"]
RUN dotnet restore "NRG3.Bliss.API/NRG3.Bliss.API.csproj"
COPY . .
WORKDIR "/src/NRG3.Bliss.API"
RUN dotnet build "NRG3.Bliss.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NRG3.Bliss.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NRG3.Bliss.API.dll"]
