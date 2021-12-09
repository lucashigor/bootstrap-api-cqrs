FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . .
RUN dotnet restore && \
    dotnet build -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
WORKDIR /app

COPY --from=build-env /app/out .
RUN apk add icu-libs
RUN dotnet dev-certs https --trust
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

ENTRYPOINT ["dotnet", "ConectCar.{{cookiecutter.project_name}}.WebApi.dll"]
