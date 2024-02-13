FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Codesaurs/Codesaurs.csproj", "Codesaurs/"]
RUN dotnet restore "Codesaurs/Codesaurs.csproj"
COPY . .
WORKDIR "/src/WebApplication1"
RUN dotnet build "Codesaurs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Codesaurs.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Codesaurs.dll"]
