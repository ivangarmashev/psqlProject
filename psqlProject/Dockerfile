FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["psqlProject/psqlProject.csproj", "psqlProject/"]
RUN dotnet restore "psqlProject/psqlProject.csproj"
COPY . .
WORKDIR "/src/psqlProject"
RUN dotnet build "psqlProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "psqlProject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "psqlProject.dll"]
