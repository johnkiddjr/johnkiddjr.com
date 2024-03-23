FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app
COPY /publish ./
RUN ln -sf /usr/share/zoneinfo/America/Detroit /etc/localtime

EXPOSE 5000/tcp

ENTRYPOINT [ "dotnet", "MainSite.dll" ]