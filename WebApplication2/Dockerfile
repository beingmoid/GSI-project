# #See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
# WORKDIR /app
# EXPOSE 80
# EXPOSE 443

# FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
# WORKDIR /src
# COPY ["WebApplication2.csproj", ""]
# RUN dotnet restore "./WebApplication2.csproj"
# COPY . .
# WORKDIR "/src/."
# RUN dotnet build "WebApplication2.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "WebApplication2.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "WebApplication2.dll"]


# # Get base SDK Image from Microsoft
# # FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
# # WORKDIR /app

# # #Copy the CSPROJ file and restore any dependencies (via Nuget)

# # COPY *.csproj ./
# # RUN dotnet restore -s https://api.nuget.org/v3/index.json

# # #Copy the project file and build our release

# # COPY . ./
# # RUN dotnet publish -c Release -o out

# # # GENERATE RUNTIME IMAGE

# # FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
# # WORKDIR /app
# # EXPOSE 80
# # COPY --from=build-env /app/out .
# # ENTRYPOINT ["dotnet","WebApplication2.dll"]



FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env

#WORKDIR /app
#
## Copy csproj and restore as distinct layers
#COPY *.csproj ./
#RUN dotnet restore
#
## Copy everything else and build
#COPY . ./
#RUN dotnet publish -c Release -o out
#
## Build runtime image
#FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
#WORKDIR /app
#COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "WebApplication2.dll"]