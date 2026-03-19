#!/bin/bash
cd /app/chat/asp/
dotnet chat-asp.dll &
cd /app/chat/wcf/
dotnet chat-wcf.dll &