FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim

ARG source

RUN ["apt-get", "update"]
RUN ["apt-get", "-y", "install", "libgdiplus"]
RUN ["apt-get", "-y", "install", "xvfb", "libfontconfig", "wkhtmltopdf"]
RUN ["apt-get", "-y", "install", "libc6-dev"]
RUN ["apt-get", "-y", "install", "openssl"]
RUN ["apt-get", "-y", "install", "libssl1.1"]

WORKDIR /app

COPY ${source:-obj/Docker/publish} .

CMD ["dotnet","Vculp.Api.dll"]