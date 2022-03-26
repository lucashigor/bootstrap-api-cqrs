FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy csproj and restore as distinct layers
COPY . .
RUN dotnet restore && \
    dotnet build -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:5.0
WORKDIR /app

COPY --from=build-env /app/out .
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

ENTRYPOINT ["dotnet", "ConectCar.{{cookiecutter.project_name}}.WebApi.dll"]
