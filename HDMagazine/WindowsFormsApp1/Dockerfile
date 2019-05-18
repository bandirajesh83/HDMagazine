FROM microsoft/netcore-build:4.5

WORKDIR /bin/debug

COPY . .

run dotnet build -c Release

ENTRYPOINT ["dotnet", "run", "--no-launch-profile"]
