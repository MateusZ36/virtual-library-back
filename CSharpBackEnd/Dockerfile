FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CSharpBackEnd/CSharpBackEnd.csproj", "CSharpBackEnd/"]
RUN dotnet restore "CSharpBackEnd/CSharpBackEnd.csproj"
COPY . .
WORKDIR "/src/CSharpBackEnd"
RUN dotnet build "CSharpBackEnd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSharpBackEnd.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSharpBackEnd.dll"]
