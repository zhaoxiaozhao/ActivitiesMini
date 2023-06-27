#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["common.props", "."]
COPY ["/src/Activities.Mini.IdentityServer/Activities.Mini.IdentityServer.csproj", "Activities.Mini.IdentityServer/"]
COPY ["/src/Activities.Mini.EntityFrameworkCore/Activities.Mini.EntityFrameworkCore.csproj", "Activities.Mini.EntityFrameworkCore/"]
COPY ["/src/Activities.Mini.Domain/Activities.Mini.Domain.csproj", "src/Activities.Mini.Domain/"]
COPY ["/src/Activities.Mini.Domain.Shared/Activities.Mini.Domain.Shared.csproj", "Activities.Mini.Domain.Shared/"]
RUN dotnet restore "Activities.Mini.IdentityServer/Activities.Mini.IdentityServer.csproj"
COPY . .
WORKDIR "/src/src/Activities.Mini.IdentityServer"
RUN dotnet build "Activities.Mini.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Activities.Mini.IdentityServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Activities.Mini.IdentityServer.dll"]