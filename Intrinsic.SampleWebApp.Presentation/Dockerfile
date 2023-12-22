#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Intrinsic.SampleWebApp.Presentation/Intrinsic.SampleWebApp.Presentation.csproj", "Intrinsic.SampleWebApp.Presentation/"]
RUN dotnet restore "Intrinsic.SampleWebApp.Presentation/Intrinsic.SampleWebApp.Presentation.csproj"
COPY . .
WORKDIR "/src/Intrinsic.SampleWebApp.Presentation"
RUN dotnet build "Intrinsic.SampleWebApp.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Intrinsic.SampleWebApp.Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Intrinsic.SampleWebApp.Presentation.dll"]