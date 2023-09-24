FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PizzaApp.Server/PizzaApp.Server.csproj", "PizzaApp.Server/"]
RUN dotnet restore "PizzaApp.Server/PizzaApp.Server.csproj"
COPY . .
WORKDIR "/src/PizzaApp.Server"
RUN dotnet build "PizzaApp.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PizzaApp.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PizzaApp.Server.dll"]
