# Use the official.NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Set the working directory in the container
WORKDIR /app

# Copy the rest of the application's source code
COPY . ./
RUN dotnet restore "WeaponStoreAPI.csproj"

# Build the application
RUN dotnet build "WeaponStoreAPI.csproj" -c Release -o /app/build

# Publish the application
RUN dotnet publish "WeaponStoreAPI.csproj" -c Release -o /app/publish

# Use the official.NET runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Set the working directory in the container
WORKDIR /app

# Copy the published application from the build stage
COPY --from=build-env /app/publish .

# Configure the entry point to start the application
ENTRYPOINT ["dotnet", "WeaponStoreAPI.dll"]
