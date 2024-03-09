FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SweepstakeGeneratorv2/SweepstakeGeneratorv2.csproj", "SweepstakeGeneratorv2/"]
RUN dotnet restore "SweepstakeGeneratorv2/SweepstakeGeneratorv2.csproj"
COPY . .
WORKDIR "/src/SweepstakeGeneratorv2"
RUN dotnet build "SweepstakeGeneratorv2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SweepstakeGeneratorv2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SweepstakeGeneratorv2.dll"]
