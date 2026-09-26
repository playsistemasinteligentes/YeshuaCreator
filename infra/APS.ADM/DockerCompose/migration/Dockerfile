FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish src/Studio/Yeshua.Studio.APS.ADM/Yeshua.Studio.APS.ADM.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Yeshua.Studio.APS.ADM.dll", "--database-only"]
