# ToDoApp API

## Descrição
A **ToDoApp API** é uma aplicação backend desenvolvida em .NET Core para gerenciamento de tarefas (*to-do list*). A API suporta autenticação JWT, operações CRUD de tarefas e utiliza um banco de dados SQL Server.

---

## Pré-requisitos
Certifique-se de ter os seguintes softwares instalados:
- **.NET SDK 6.0 ou superior**: [Download .NET SDK](https://dotnet.microsoft.com/download)
- **SQL Server**: [Download SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

---

## Configuração do Banco de Dados

1. Certifique-se de que o SQL Server está em execução.
2. Crie o banco de dados manualmente no SQL Server:
 ```sql
   CREATE DATABASE ToDoAppDb;
```

---

## Clonar o Repositório

git clone https://github.com/Rodrigo-Paim/ToDoApp.git
``` 
cd ToDoApp
```

---

## Restaurar Dependências
```
 dotnet restore
 ```

 ---

## Aplicar Migrations
```
 dotnet ef database update
 ```

---

## Rodar o Projeto
```
 dotnet run
```