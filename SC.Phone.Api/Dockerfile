#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SC.Phone.Api/SC.Phone.Api.csproj", "SC.Phone.Api/"]
RUN dotnet restore "SC.Phone.Api/SC.Phone.Api.csproj"
COPY . .
WORKDIR "/src/SC.Phone.Api"
RUN dotnet build "SC.Phone.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SC.Phone.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SC.Phone.Api.dll"]