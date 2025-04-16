# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar os arquivos de projeto (.csproj) de todas as pastas
COPY Tarefa5.API/*.csproj ./Tarefa5.API/
COPY Tarefa5.Service/*.csproj ./Tarefa5.Service/
COPY Tarefa5.Domain/*.csproj ./Tarefa5.Domain/
COPY Tarefa5.Data/*.csproj ./Tarefa5.Data/
COPY Tarefa5.Data.Rest/*.csproj ./Tarefa5.Data.Rest/
COPY Tarefa5.Data.Postgres/*.csproj ./Tarefa5.Data.Postgres/

# Restaurar as dependências
RUN dotnet restore ./Tarefa5.API/Tarefa5.API.csproj

# Copiar todo o restante do código
COPY . .

# Publicar o projeto em modo Release
RUN dotnet publish ./Tarefa5.API/Tarefa5.API.csproj -c Release -o /out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar os arquivos publicados da etapa de build
COPY --from=build /out .

# Copiar o certificado SSL para o container
COPY ../../https/aspnetapp.pfx /https/aspnetapp.pfx

# Configurar HTTPS
ENV ASPNETCORE_URLS="https://+:7213"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=12345

# Expor a porta HTTPS
EXPOSE 7213

# Comando para rodar a aplicação
ENTRYPOINT ["dotnet", "Tarefa5.API.dll"]