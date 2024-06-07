# Use the official .NET 7.0 ASP.NET runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official .NET 7.0 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy and restore solution files
COPY *.sln .
COPY ["Api/Api.csproj", "Api/"]
COPY ["DataAccess.SqlLite/DataAccess.SqlLite.csproj", "DataAccess.SqlLite/"]
# Add other class library projects if needed

RUN dotnet restore

# Copy the entire solution and build
COPY . .
WORKDIR "/src/Api"
RUN dotnet build "Api.csproj" -c Release -o /app/build

# Use the build output from the previous stage
FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish

# Use the base runtime image to run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]
