FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /src

COPY *.config ./
COPY *sln ./
COPY Financial.Bill.Api/Financial.Bill.Api.csproj Financial.Bill.Api/
COPY Financial.Bill.Domain/Financial.Bill.Domain.csproj Financial.Bill.Domain/
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /src
EXPOSE 80
COPY --from=build-env /src/out .
ENTRYPOINT ["dotnet", "Financial.Bill.Api.dll"]