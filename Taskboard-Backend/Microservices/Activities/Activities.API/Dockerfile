FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Microservices/Task/Task.API/Task.API.csproj", "Microservices/Task/Task.API/"]
RUN dotnet restore "Microservices/Task/Task.API/Task.API.csproj"
COPY . .
WORKDIR "/src/Microservices/Task/Task.API"
RUN dotnet build "Task.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Task.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Task.API.dll"]