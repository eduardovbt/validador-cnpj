# Etapa 1: Construção
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Defina o diretório de trabalho como /src dentro do container
WORKDIR /src

# Copie o arquivo .csproj para o diretório correto dentro do container
COPY ["src/UI/Nstech.Mdm.Api/Nstech.Mdm.Api.csproj", "Nstech.Mdm.Api/"]

# Restaure as dependências do projeto
RUN dotnet restore "src/UI/Nstech.Mdm.Api/Nstech.Mdm.Api.csproj"

# Copie o restante dos arquivos do projeto
COPY Nstech.Mdm.Api/. Nstech.Mdm.Api/

# Defina o diretório de trabalho como o diretório do projeto
WORKDIR "/src/Nstech.Mdm.Api"

# Compile o projeto
RUN dotnet build "Nstech.Mdm.Api.csproj" -c Release -o /app/build

# Etapa 2: Publicação
FROM build AS publish
RUN dotnet publish "Nstech.Mdm.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa 3: Execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Defina o diretório de trabalho para o diretório de execução
WORKDIR /app

# Exponha a porta 80 para o container
EXPOSE 80

# Copie o aplicativo publicado para o diretório de execução
COPY --from=publish /app/publish .

# Defina o ponto de entrada para o aplicativo
ENTRYPOINT ["dotnet", "Nstech.Mdm.Api.dll"]
