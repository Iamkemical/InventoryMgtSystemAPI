FROM mcr.microsoft.com/dotnet/core/sdk:3.1.101 AS build
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

WORKDIR /app/InventoryMgtSystemAPI
COPY InventoryMgtSystemAPI/*.csproj .
RUN dotnet restore 

COPY InventoryMgtSystemAPI/ .

RUN dotnet publish -c Release -o out


# Build runtime image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1.101
WORKDIR /app
COPY --from=build /app/InventoryMgtSystemAPI/out .
ENTRYPOINT ["dotnet", "InventoryMgtSystemAPI.dll"]
