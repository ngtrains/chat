#!/bin/bash
export ASPNETCORE_Kestrel__Certificates__Default__Path=/
cd /app/chat/wcf
dotnet chat-wcf.dll &