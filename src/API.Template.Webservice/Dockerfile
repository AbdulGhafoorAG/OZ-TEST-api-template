#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["API.Template.Webservice/API.Template.Webservice.csproj", "API.Template.Webservice/"]
RUN dotnet restore "API.Template.Webservice/API.Template.Webservice.csproj"
COPY . .
WORKDIR "/src/API.Template.Webservice"
RUN dotnet build "API.Template.Webservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.Template.Webservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.Template.Webservice.dll"]