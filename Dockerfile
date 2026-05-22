FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY Zad.API/Zad.API.csproj Zad.API/
COPY Zad.Application/Zad.Application.csproj Zad.Application/
COPY Zad.Infrastructure/Zad.Infrastructure.csproj Zad.Infrastructure/
COPY Zad.Domain/Zad.Domain.csproj Zad.Domain/
RUN dotnet restore Zad.API/Zad.API.csproj

COPY . .
WORKDIR /src/Zad.API
RUN dotnet publish Zad.API.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Zad.API.dll"]
