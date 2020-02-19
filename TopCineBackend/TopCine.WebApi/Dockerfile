FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["TopCine.WebApi/TopCine.WebApi.csproj", "TopCine.WebApi/"]
RUN dotnet restore "TopCine.WebApi/TopCine.WebApi.csproj"
COPY . .
WORKDIR "/src/TopCine.WebApi"
RUN dotnet build "TopCine.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TopCine.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TopCine.WebApi.dll"]