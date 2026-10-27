FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Race_Day/Race_Day.csproj", "Race_Day/"]
RUN dotnet restore "Race_Day/Race_Day.csproj"
COPY . .
WORKDIR "/src/Race_Day"
RUN dotnet build "Race_Day.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Race_Day.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Race_Day.dll"]
