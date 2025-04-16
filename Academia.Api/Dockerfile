# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar os arquivos de projeto (.csproj) de todas as pastas
COPY ./Academia.Api/*.csproj ./Academia.Api/
COPY ./AcademiaService/Academia.Application.csproj ./AcademiaService/
COPY ./Academia.Domain/*.csproj ./Academia.Domain/
COPY ./Academia.Data/*.csproj ./Academia.Data/
COPY ./Academia.Data.Rest/*.csproj ./Academia.Data.Rest/
COPY ./Academia.Data.Postgres/*.csproj ./Academia.Data.Postgres/

# Restaurar as dependências
RUN dotnet restore ./Academia.Api/Academia.Api.csproj

# Copiar todo o restante do código
COPY . .

# Publicar o projeto em modo Release
RUN dotnet publish ./Academia.Api/Academia.Api.csproj -c Release -o /out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar os arquivos publicados da etapa de build
COPY --from=build /out .

# Configurar HTTPS (o certificado será montado como volume pelo docker-compose)
ENV ASPNETCORE_URLS="https://+:7162"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=12345

# Expor a porta HTTPS
EXPOSE 7162

# Comando para rodar a aplicação
ENTRYPOINT ["dotnet", "Academia.Api.dll"]