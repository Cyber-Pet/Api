#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS base
RUN apk add tzdata && cp /usr/share/zoneinfo/America/Bahia /etc/localtime && echo "America/Bahia" >  /etc/timezone
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /src
COPY ["src/CyberPet.Api/CyberPet.Api.csproj", "src/CyberPet.Api/"]
RUN dotnet restore "src/CyberPet.Api/CyberPet.Api.csproj"
COPY . .
WORKDIR "/src/src/CyberPet.Api"
RUN dotnet build "CyberPet.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CyberPet.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet CyberPet.Api.dll