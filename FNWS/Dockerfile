FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["FNWS/FNWS.csproj", "FNWS/"]
COPY ["FNWS/bin/Release/netcoreapp3.1/FileNet.Api.dll", "FNWS/"]
COPY ["FNWS/bin/Release/netcoreapp3.1/Microsoft.Web.Services3.dll", "FNWS/"]
RUN dotnet restore "FNWS/FNWS.csproj"
COPY . .
WORKDIR "/src/FNWS"
RUN dotnet build "FNWS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FNWS.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FNWS.dll"]
ENTRYPOINT ["dotnet", "FNWS.dll"]
ENTRYPOINT ["dotnet", "Microsoft.Web.Services3.dll"]