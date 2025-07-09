
# 🏫 Projeto AVA - Ambiente Virtual de Aprendizagem

Bem-vindo ao **AVA** (Ambiente Virtual de Aprendizagem)!  
Este projeto foi construído com **.NET 8 + EF Core + Angular** seguindo o padrão **Clean Architecture** para garantir alta manutenção, testes facilitados e separação de responsabilidades.

---

## 📐 Arquitetura

O projeto segue a **Clean Architecture** de Robert C. Martin (Uncle Bob):

```
AVA.sln
├── AVA.Domain             🧠 Núcleo: entidades e contratos
├── AVA.Application        🎯 Casos de uso e regras de negócio
├── AVA.Infrastructure     🔧 Implementação de repositórios (EF Core)
├── AVA.Infrastructure.IOC 🔌 Configuração de Injeção de Dependência
└── AVA.Api                🌐 API REST com ASP.NET Core 8
```

📌 **Principais regras:**
- `Domain` e `Application` **não conhecem EF Core**.
- Apenas `Infrastructure` sabe como persistir dados.
- A API só fala com `Application` (via interfaces).

---

## 🚀 Como executar o projeto

### 📋 Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- PostGres (ou LocalDB)
- Node.js + Angular CLI

---

### 🔧 Configuração do banco de dados

📁 Abra `AVA.Api/appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=projeto_ava;Username=postgres;Password=123"
  }
}
```
➡️ Edite a connection string para apontar para seu banco se necessário.

---

### 📦 Restaurar dependências
Execute na raiz do projeto:
```bash
dotnet restore
```

---

### 🏗️ Criar banco e aplicar migrations

1️⃣ Gere a migration inicial:
```bash
dotnet ef migrations add InitialCreate -p AVA.Infrastructure -s AVA.Api
```

2️⃣ Atualize o banco de dados:
```bash
dotnet ef database update -p AVA.Infrastructure -s AVA.Api
```

---

### ▶️ Rodar a API
Execute:
```bash
dotnet run --project AVA.Api
```

Acesse a API no navegador:
```
https://localhost:5001/swagger
```

---

### ⚡ Rodar com banco InMemory (opcional)
Se você não quer configurar SQL Server agora, altere o DI:

📁 `AVA.Infrastructure.IOC/DependencyInjection.cs`
```csharp
services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("AVA_DB"));
```

E rode normalmente.

---

## 📖 APIs disponíveis

### 🔥 UserController
| Método | Rota          | Descrição               |
|--------|---------------|-------------------------|
| GET    | /api/user     | Lista todos os usuários |
| POST   | /api/user     | Cria um novo usuário    |

---

## 🧑‍💻 Tecnologias usadas
- ASP.NET Core 8
- Entity Framework Core 8
- SQL Server / InMemory Database
- Swagger (documentação da API)
- Clean Architecture

---

## 🤝 Contribuindo
1. Fork este repositório
2. Crie sua branch:
```bash
git checkout -b feature/sua-feature
```
3. Commit suas mudanças:
```bash
git commit -m "feat: adiciona nova feature"
```
4. Push:
```bash
git push origin feature/sua-feature
```
5. Abra um Pull Request

---
