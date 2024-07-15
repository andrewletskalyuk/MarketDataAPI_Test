FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expose port 80 and 443
EXPOSE 80
EXPOSE 443

# Copy the development certificate
COPY --from=build-env /root/.aspnet/https /root/.aspnet/https

# Set environment variables for the certificate
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/root/.aspnet/https/aspnetapp.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=*******

# Run the application
ENTRYPOINT ["dotnet", "MarketDataAPI.dll"]
