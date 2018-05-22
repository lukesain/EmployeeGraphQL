FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY EmployeeGraphQL/EmployeeGraphQL.csproj EmployeeGraphQL/
RUN dotnet restore EmployeeGraphQL/EmployeeGraphQL.csproj
COPY . .
WORKDIR /src/EmployeeGraphQL
RUN dotnet build EmployeeGraphQL.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish EmployeeGraphQL.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EmployeeGraphQL.dll"]
