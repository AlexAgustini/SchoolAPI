# Use an official ASP.NET Core runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:latest AS base
WORKDIR /app
EXPOSE 5000

# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /src
COPY ["SchoolAPI/SchoolAPI.csproj", "SchoolAPI/"]
RUN dotnet restore "SchoolAPI/SchoolAPI.csproj"
COPY . .
WORKDIR "/src/SchoolAPI"
RUN dotnet build "SchoolAPI.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "SchoolAPI.csproj" -c Release -o /app/publish

# Create the final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SchoolAPI.dll"]