#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SC.Tracker.Api/SC.Tracker.Api.csproj", "SC.Tracker.Api/"]
RUN dotnet restore "SC.Tracker.Api/SC.Tracker.Api.csproj"
COPY . .
WORKDIR "/src/SC.Tracker.Api"
RUN dotnet build "SC.Tracker.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SC.Tracker.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SC.Tracker.Api.dll"]