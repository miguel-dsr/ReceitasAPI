# 🍳 API de Receitas - Projeto DevOps

[![.NET](https://img.shields.io/badge/.NET-8.0-purple)](https://dotnet.microsoft.com/)

API para gerenciamento de receitas e ingredientes, desenvolvida como pré-tarefa para o curso de DevOps.


## 📋 Requisitos Atendidos
- **CRUD completo** de receitas e ingredientes
- Relacionamento N:N entre receitas e ingredientes com **quantidades específicas**
- API documentada e testável

## 🛠️ Tecnologias
- ASP.NET Core 
- Entity Framework Core
- SQL Server (localdb)
- Swagger/OpenAPI

## Acesse a documentação da API em:
  https://localhost:7149/swagger/v1/swagger.json

## 🚀 Como Executar
```bash
# Clone o repositório
git clone https://github.com/seu-usuario/ReceitasAPI.git

# Entre na pasta do projeto
cd ReceitasAPI

# Restaure as dependências
dotnet restore

# Execute a aplicação
dotnet run
