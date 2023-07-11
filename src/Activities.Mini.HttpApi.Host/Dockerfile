#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["common.props", "."]
COPY ["/src/Activities.Mini.HttpApi.Host/Activities.Mini.HttpApi.Host.csproj", "Activities.Mini.HttpApi.Host/"]
COPY ["/src/Activities.Mini.EntityFrameworkCore/Activities.Mini.EntityFrameworkCore.csproj", "Activities.Mini.EntityFrameworkCore/"]
COPY ["/src/Activities.Mini.Domain/Activities.Mini.Domain.csproj", "Activities.Mini.Domain/"]
COPY ["/src/Activities.Mini.Domain.Shared/Activities.Mini.Domain.Shared.csproj", "Activities.Mini.Domain.Shared/"]
COPY ["/src/Activities.Mini.Application/Activities.Mini.Application.csproj", "Activities.Mini.Application/"]
COPY ["/src/Activities.Mini.Application.Contracts/Activities.Mini.Application.Contracts.csproj", "Activities.Mini.Application.Contracts/"]
COPY ["/src/Activities.Mini.Common/Activities.Mini.Common.csproj", "Activities.Mini.Common/"]
COPY ["/src/Activities.Mini.Core/Activities.Mini.Core.csproj", "Activities.Mini.Core/"]
COPY ["/src/Activities.Mini.HttpApi/Activities.Mini.HttpApi.csproj", "Activities.Mini.HttpApi/"]
RUN dotnet restore "Activities.Mini.HttpApi.Host/Activities.Mini.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/src/Activities.Mini.HttpApi.Host"
RUN dotnet build "Activities.Mini.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Activities.Mini.HttpApi.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Activities.Mini.HttpApi.Host.dll"]
