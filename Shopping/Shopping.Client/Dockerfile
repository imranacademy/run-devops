# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Build image for compiling the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only the necessary files for dependency restore
COPY Shopping/Shopping.Client/Shopping.Client.csproj Shopping/Shopping.Client/
RUN dotnet restore Shopping/Shopping.Client/Shopping.Client.csproj

# Copy everything else and build
COPY . .
WORKDIR /src/Shopping/Shopping.Client
RUN dotnet build -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shopping.Client.dll"]
