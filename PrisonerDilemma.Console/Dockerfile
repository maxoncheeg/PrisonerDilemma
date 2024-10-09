FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PrisonerDilemma.Console/PrisonerDilemma.Console.csproj", "PrisonerDilemma.Console/"]
RUN dotnet restore "PrisonerDilemma.Console/PrisonerDilemma.Console.csproj"
COPY . .
WORKDIR "/src/PrisonerDilemma.Console"
RUN dotnet build "PrisonerDilemma.Console.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PrisonerDilemma.Console.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PrisonerDilemma.Console.dll"]
