# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY HelloApi/*.csproj HelloApi/
RUN dotnet restore HelloApi/HelloApi.csproj

# Copy everything else and build
COPY HelloApi/ HelloApi/
WORKDIR /src/HelloApi
RUN dotnet build HelloApi.csproj -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish HelloApi.csproj -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelloApi.dll"]
