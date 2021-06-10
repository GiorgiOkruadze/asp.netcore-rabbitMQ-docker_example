#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ApiServices/Catalog/CatalogApi/CatalogApi.csproj", "ApiServices/Catalog/CatalogApi/"]
RUN dotnet restore "ApiServices/Catalog/CatalogApi/CatalogApi.csproj"
COPY . .
WORKDIR "/src/ApiServices/Catalog/CatalogApi"
RUN dotnet build "CatalogApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CatalogApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CatalogApi.dll"]
