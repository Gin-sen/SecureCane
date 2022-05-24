#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SC.UserManagment.Api/SC.UserManagment.Api.csproj", "SC.UserManagment.Api/"]
COPY ["SC.UserManagment.Application/SC.UserManagment.Application.csproj", "SC.UserManagment.Application/"]
COPY ["SC.Common.CQRS/SC.Common.CQRS.csproj", "SC.Common.CQRS/"]
RUN dotnet restore "SC.UserManagment.Api/SC.UserManagment.Api.csproj"
COPY . .
WORKDIR "/src/SC.UserManagment.Api"
RUN dotnet build "SC.UserManagment.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SC.UserManagment.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SC.UserManagment.Api.dll"]