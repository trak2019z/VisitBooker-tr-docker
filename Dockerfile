FROM microsoft/dotnet:2.2-sdk AS build-env

WORKDIR /app

# copy csproj and restore as distinct layers
COPY ./src/*.sln ./src/
COPY ./src/WebApi/*.csproj ./src/WebApi/
COPY ./src/Domain/*.csproj ./src/Domain/
COPY ./src/Domain.Core/*.csproj ./src/Domain.Core/
COPY ./src/Persistance/*.csproj ./src/Persistance/
COPY ./src/Bootstrap/*.csproj ./src/Bootstrap/
COPY ./src/Application/*.csproj ./src/Application/

WORKDIR /app/src
RUN dotnet restore -nowarn:msb3202,nu1503

COPY ./src ./

FROM build-env AS publish
WORKDIR /app/src/WebApi
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app/src
COPY --from=publish /app/src/WebApi/out ./

EXPOSE 5000/tcp

ENV ASPNETCORE_URLS=http://0.0.0.0:5000

ENTRYPOINT ["dotnet", "WebApi.dll"]