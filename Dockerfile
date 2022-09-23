FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 3000

ENV ASPNETCORE_URLS=http://*:3000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["EasyInsuranceAPI/EasyInsuranceAPI.csproj", "EasyInsuranceAPI/"]
RUN dotnet restore "EasyInsuranceAPI/EasyInsuranceAPI.csproj"
COPY . .
WORKDIR "/src/EasyInsuranceAPI"
RUN dotnet build "EasyInsuranceAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyInsuranceAPI.csproj" -c Release -o /app/publish

FROM build as development
WORKDIR /app
COPY --from=publish /app/publish .
RUN ["dotnet", "dev-certs", "https"]
CMD ["dotnet", "EasyInsuranceAPI.dll"]

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyInsuranceAPI.dll"]
