FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /source

COPY . .

RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime

WORKDIR /app

COPY --from=build /app .

VOLUME /app/data

ENTRYPOINT ["dotnet", "practica.dll"]

