#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Rest/CloudSuite.Services.Subscriptions.API/CloudSuite.Services.Subscriptions.API.csproj", "src/Rest/CloudSuite.Services.Subscriptions.API/"]
COPY ["src/Modules/CloudSuite.Modules.Application/CloudSuite.Modules.Application.csproj", "src/Modules/CloudSuite.Modules.Application/"]
COPY ["src/Modules/CloudSuite.Modules.Domain/CloudSuite.Modules.Domain.csproj", "src/Modules/CloudSuite.Modules.Domain/"]
COPY ["src/Modules/CloudSuite.Modules.Commons/CloudSuite.Modules.Commons.csproj", "CloudSuite.Modules.Commons/"]
COPY ["src/Infrastructure/CloudSuite.Infrastructure.CrossCutting/CloudSuite.Infrastructure.CrossCutting.csproj", "src/Infrastructure/CloudSuite.Infrastructure.CrossCutting/"]
COPY ["src/Infrastructure/CloudSuite.Infrastructure/CloudSuite.Infrastructure.csproj", "src/Infrastructure/CloudSuite.Infrastructure/"]
RUN dotnet restore "src/Rest/CloudSuite.Services.Subscriptions.API/CloudSuite.Services.Subscriptions.API.csproj"
COPY . .
WORKDIR "/src/Rest/CloudSuite.Services.Subscriptions.API"
RUN dotnet build "CloudSuite.Services.Subscriptions.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudSuite.Services.Subscriptions.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudSuite.Services.Subscriptions.API.dll"]