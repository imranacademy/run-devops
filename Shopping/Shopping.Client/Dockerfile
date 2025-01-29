# Base stage used for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

# Build stage to build and restore the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the csproj file and restore dependencies
COPY ["Shopping/Shopping.Client/Shopping.Client.csproj", "Shopping/Shopping.Client/"]
RUN dotnet restore "Shopping/Shopping.Client/Shopping.Client.csproj"

# Copy all files and build the project
COPY . . 
WORKDIR "/src/Shopping/Shopping.Client"
RUN dotnet build "Shopping.Client.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage to prepare the application for release
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Shopping.Client.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage to copy the built application to the production container
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish . 
ENTRYPOINT ["dotnet", "Shopping.Client.dll"]
