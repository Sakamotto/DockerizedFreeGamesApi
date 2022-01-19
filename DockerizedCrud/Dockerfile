FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /webapp

# copy the csproj file and restore
COPY ../*.sln .
COPY ./*.csproj ./
RUN dotnet restore

# copy everything else and build
COPY . .
WORKDIR /webapp
RUN dotnet publish -c Release -o out --no-restore

# build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /webapp
COPY --from=build /webapp/out .
ENTRYPOINT [ "dotnet", "DockerizedCrud.dll" ]