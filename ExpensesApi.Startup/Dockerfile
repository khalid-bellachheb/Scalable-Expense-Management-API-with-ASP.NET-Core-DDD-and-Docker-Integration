FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8000
EXPOSE 8001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ExpensesApi.Startup/ExpensesApi.Startup.csproj", "ExpensesApi.Startup/"]
COPY ["Expenses.Domain/ExpensesApi.Domain.csproj", "Expenses.Domain/"]
COPY ["ExpensesApi.Application/ExpensesApi.Application.csproj", "ExpensesApi.Application/"]
COPY ["ExpensesApi.Infrastructure/ExpensesApi.Infrastructure.csproj", "ExpensesApi.Infrastructure/"]
COPY ["ExpensesApi.Presentation/ExpensesApi.Presentation.csproj", "ExpensesApi.Presentation/"]
RUN dotnet restore "./ExpensesApi.Startup/ExpensesApi.Startup.csproj"
COPY . .
WORKDIR "/src/ExpensesApi.Startup"
RUN dotnet build "./ExpensesApi.Startup.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ExpensesApi.Startup.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExpensesApi.Startup.dll"]