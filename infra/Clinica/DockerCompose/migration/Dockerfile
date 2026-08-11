FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish src/Studio/Yeshua.Studio.AppClinicas/Yeshua.Studio.AppClinicas.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Yeshua.Studio.AppClinicas.dll", "--database-only"]
