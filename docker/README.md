# Commands
## Docker
docker compose up -d\
docker compose down

docker compose exec sdk bash\
docker compose exec runtime bash

## docker's sdk shell
dotnet clean\
dotnet restore --runtime linux-x64\
### For chat-asp project
cd /source/chat-asp/\
dotnet publish -c Release -o /chat-asp-bin
### For chat-wcf project
cd /source/chat-wcf/\
dotnet publish -c Release -o /chat-wcf-bin

## docker's runtime shell
cd /app/chat-asp-bin\
dotnet aspnetapp.dll

# Docdker shell shortcuts
Detach console:     Ctrl p + q
