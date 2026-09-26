FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish src/Studio/Yeshua.Studio.Fiscal/Yeshua.Studio.Fiscal.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Yeshua.Studio.Fiscal.dll", "--database-only"]
