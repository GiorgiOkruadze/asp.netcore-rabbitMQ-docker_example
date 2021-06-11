#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ApiServices/Basket/BasketApi/BasketApi.csproj", "ApiServices/Basket/BasketApi/"]
RUN dotnet restore "ApiServices/Basket/BasketApi/BasketApi.csproj"
COPY . .
WORKDIR "/src/ApiServices/Basket/BasketApi"
RUN dotnet build "BasketApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasketApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasketApi.dll"]
