FROM mcr.microsoft.com/dotnet/sdk:10.0-azurelinux3.0 AS sdk
RUN dotnet tool install --global dotnet-svcutil
ENV PATH="${PATH}:/root/.dotnet/tools/"
ENV DOTNET_SVCUTIL_TELEMETRY_OPTOUT=1