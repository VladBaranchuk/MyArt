#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyArt.API/MyArt.API.csproj", "MyArt.API/"]
COPY ["MyArt.BusinessLogic/MyArt.BusinessLogic.csproj", "MyArt.BusinessLogic/"]
COPY ["MyArt.API.ViewModels/MyArt.API.ViewModels.csproj", "MyArt.API.ViewModels/"]
COPY ["MyArt.DataAccess/MyArt.DataAccess.csproj", "MyArt.DataAccess/"]
COPY ["MyArt.Domain/MyArt.Domain.csproj", "MyArt.Domain/"]
RUN dotnet restore "MyArt.API/MyArt.API.csproj"
COPY . .
WORKDIR "/src/MyArt.API"
RUN dotnet build "MyArt.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyArt.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyArt.API.dll"]