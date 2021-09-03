#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["UzduotisEPS/UzduotisEPS.csproj", "UzduotisEPS/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Database/Database.csproj", "Database/"]
RUN dotnet restore "UzduotisEPS/UzduotisEPS.csproj"
COPY . .
WORKDIR "/src/UzduotisEPS"
RUN dotnet build "UzduotisEPS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UzduotisEPS.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UzduotisEPS.dll"]