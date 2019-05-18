FROM microsoft/aspnetcore-build:2.0

WORKDIR /bin/debug

COPY . .

run dotnet build -c Release

ENTRYPOINT ["dotnet", "run", "--no-launch-profile"]
