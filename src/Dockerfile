FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /src

COPY *.config ./
COPY *sln ./
COPY Api/Api.csproj Api/
COPY Domain/Domain.csproj Domain/
COPY Infra.Data.Command/Infra.Data.Command.csproj Infra.Data.Command/
COPY Infra.Data.Query/Infra.Data.Query.csproj Infra.Data.Query/
COPY Infra.Service/Infra.Service.csproj Infra.Service/
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /src
EXPOSE 80
COPY --from=build-env /src/out .
ENTRYPOINT ["dotnet", "Api.dll"]