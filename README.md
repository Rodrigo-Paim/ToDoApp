# ToDoApp API

## Descri��o
A **ToDoApp API** � uma aplica��o backend desenvolvida em .NET Core para gerenciamento de tarefas (*to-do list*). A API suporta autentica��o JWT, opera��es CRUD de tarefas e utiliza um banco de dados SQL Server.

---

## Pr�-requisitos
Certifique-se de ter os seguintes softwares instalados:
- **.NET SDK 6.0 ou superior**: [Download .NET SDK](https://dotnet.microsoft.com/download)
- **SQL Server**: [Download SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

---

## Configura��o do Banco de Dados

1. Certifique-se de que o SQL Server est� em execu��o.
2. Crie o banco de dados manualmente no SQL Server:
 ```sql
   CREATE DATABASE ToDoAppDb;
```

---

## Clonar o Reposit�rio

git clone https://github.com/Rodrigo-Paim/ToDoApp.git
``` 
cd ToDoApp
```

---

## Restaurar Depend�ncias
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