FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FriendNet.REST/FriendNet.REST.csproj", "FriendNet.REST/"]
RUN dotnet restore "FriendNet.REST/FriendNet.REST.csproj"
COPY . .
WORKDIR "/src/FriendNet.REST"
RUN dotnet build "FriendNet.REST.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FriendNet.REST.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FriendNet.REST.dll"]
