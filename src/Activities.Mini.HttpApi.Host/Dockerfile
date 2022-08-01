#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY [NuGet.Config, .]
COPY ["src/Activities.Mini.HttpApi.Host/Activities.Mini.HttpApi.Host.csproj", "src/Activities.Mini.HttpApi.Host/"]
COPY ["src/Activities.Mini.EntityFrameworkCore/Activities.Mini.EntityFrameworkCore.csproj", "src/Activities.Mini.EntityFrameworkCore/"]
COPY ["src/Activities.Mini.Domain/Activities.Mini.Domain.csproj", "src/Activities.Mini.Domain/"]
COPY ["src/Activities.Mini.Domain.Shared/Activities.Mini.Domain.Shared.csproj", "src/Activities.Mini.Domain.Shared/"]
COPY ["src/Activities.Mini.Application/Activities.Mini.Application.csproj", "src/Activities.Mini.Application/"]
COPY ["src/Activities.Mini.Application.Contracts/Activities.Mini.Application.Contracts.csproj", "src/Activities.Mini.Application.Contracts/"]
COPY ["src/Activities.Mini.Common/Activities.Mini.Common.csproj", "src/Activities.Mini.Common/"]
COPY ["src/Activities.Mini.Core/Activities.Mini.Core.csproj", "src/Activities.Mini.Core/"]
COPY ["src/Activities.Mini.HttpApi/Activities.Mini.HttpApi.csproj", "src/Activities.Mini.HttpApi/"]
RUN dotnet restore "src/Activities.Mini.HttpApi.Host/Activities.Mini.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/src/Activities.Mini.HttpApi.Host"
RUN dotnet build "Activities.Mini.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Activities.Mini.HttpApi.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Activities.Mini.HttpApi.Host.dll"]