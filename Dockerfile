FROM microsoft/dotnet:latest
COPY src/WebApp1/bin/Debug/netcoreapp1.0/publish/ /app
WORKDIR /app

EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000

ENTRYPOINT dotnet /app/WebApp1.dll
