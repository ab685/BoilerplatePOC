FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/BoilerplatePOC.Web.Host/BoilerplatePOC.Web.Host.csproj", "src/BoilerplatePOC.Web.Host/"]
COPY ["src/BoilerplatePOC.Web.Core/BoilerplatePOC.Web.Core.csproj", "src/BoilerplatePOC.Web.Core/"]
COPY ["src/BoilerplatePOC.Application/BoilerplatePOC.Application.csproj", "src/BoilerplatePOC.Application/"]
COPY ["src/BoilerplatePOC.Core/BoilerplatePOC.Core.csproj", "src/BoilerplatePOC.Core/"]
COPY ["src/BoilerplatePOC.EntityFrameworkCore/BoilerplatePOC.EntityFrameworkCore.csproj", "src/BoilerplatePOC.EntityFrameworkCore/"]
WORKDIR "/src/src/BoilerplatePOC.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/BoilerplatePOC.Web.Host", "src/BoilerplatePOC.Web.Host"]
COPY ["src/BoilerplatePOC.Web.Core", "src/BoilerplatePOC.Web.Core"]
COPY ["src/BoilerplatePOC.Application", "src/BoilerplatePOC.Application"]
COPY ["src/BoilerplatePOC.Core", "src/BoilerplatePOC.Core"]
COPY ["src/BoilerplatePOC.EntityFrameworkCore", "src/BoilerplatePOC.EntityFrameworkCore"]
WORKDIR "/src/src/BoilerplatePOC.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "BoilerplatePOC.Web.Host.dll"]
