FROM mcr.microsoft.com/dotnet/sdk:10.0-azurelinux3.0 AS sdk
WORKDIR /sources/chat/
ADD ../asp ./asp
ADD ../wcf ./wcf

WORKDIR /sources/chat/asp/
RUN dotnet publish -c Release -o /chat-bin/asp

WORKDIR /sources/chat/wcf/
RUN dotnet publish -c Release -o /chat-bin/wcf



FROM mcr.microsoft.com/dotnet/aspnet:10.0-azurelinux3.0 AS runtime
COPY --from=sdk /chat-bin /app/chat
ADD ../scripts/dotnet.sh /app/chat/dotnet.sh
WORKDIR /app/chat
ENTRYPOINT ["bash", "/app/chat/dotnet.sh"]
EXPOSE 8080