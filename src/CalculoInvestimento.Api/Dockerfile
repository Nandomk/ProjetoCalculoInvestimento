FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /home/app

COPY  ./CalculoInvestimento.sln ./
COPY ./src/*/*.csproj ./
COPY ./NuGet.config ./


RUN for file in $(ls *.csproj); do mkdir -p ./src/${file%.*}/ && mv $file ./src/${file%.*}/; done

RUN ls /home/app/src/CalculoInvestimento.Api/
RUN dotnet restore --configfile NuGet.config /home/app/src/CalculoInvestimento.Api/CalculoInvestimento.Api.csproj
 
COPY . .	

RUN dotnet build -c Release /home/app/src/CalculoInvestimento.Api/CalculoInvestimento.Api.csproj && \
	dotnet publish -c Debug -o /publish /home/app/src/CalculoInvestimento.Api/CalculoInvestimento.Api.csproj

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /publish

COPY --from=build /publish .

ENTRYPOINT ["dotnet", "CalculoInvestimento.Api.dll"]