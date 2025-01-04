# Etapa 1: Build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar arquivos do projeto
COPY ["Tarefas.Api/Tarefas.Api.csproj", "Tarefas.Api/"]
COPY ["Tarefas.Business/Tarefas.Business.csproj", "Tarefas.Business/"]
COPY ["Tarefas.Business.Imp/Tarefas.Business.Imp.csproj", "Tarefas.Business.Imp/"]
COPY ["Tarefas.Entities/Tarefas.Entities.csproj", "Tarefas.Entities/"]
COPY ["Tarefas.Repository/Tarefas.Repository.csproj", "Tarefas.Repository/"]
COPY ["Tarefas.Repository.Imp/Tarefas.Repository.Imp.csproj", "Tarefas.Repository.Imp/"]

# Restaurar dependências
RUN dotnet restore "Tarefas.Api/Tarefas.Api.csproj"
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Copiar o restante do código
COPY . .

# Compilar o projeto
WORKDIR "/app/Tarefas.Api"
RUN dotnet publish -c Release -o /publish

RUN mkdir -p /app && chmod -R 777 /app



# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar artefatos publicados
COPY --from=build /publish .

# Expor a porta da aplicação
EXPOSE 5000

# Configurar variável de ambiente para porta
ENV ASPNETCORE_URLS=http://+:5000

# Comando para iniciar a aplicação

ENTRYPOINT ["dotnet", "Tarefas.Api.dll"]
