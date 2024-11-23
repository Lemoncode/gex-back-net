FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . .
RUN dotnet publish ./GexBackendAPI/GexBackendAPI.csproj -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
WORKDIR /app
COPY --from=build /publish .
ENV ASPNETCORE_URLS=http://+:7070
ENTRYPOINT ["dotnet", "GexBackendAPI.dll"]