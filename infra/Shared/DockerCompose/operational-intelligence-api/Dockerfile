# ===== Stage 1: Build =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet publish \
  src/OperationalIntelligence/Yeshua.OperationalIntelligence.Api/Yeshua.OperationalIntelligence.Api.csproj \
  -c Release \
  -o /app/publish


# ===== Stage 2: Runtime =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:5728
EXPOSE 5728

ENTRYPOINT ["dotnet", "Yeshua.OperationalIntelligence.Api.dll"]
