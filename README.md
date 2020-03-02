Este é um projeto para o desafio tecnico proposto pela Qualyteam.


## Tecnologias utilizadas
* .NET Core 3
* Entity Framework Core 3
* PostgreSQL

## Como executar

Primeiramente deve-se criar um banco de dados no postgres com o nome *testeQualyteam* para que seja possivel da aplicação criar as migrations necessarias para seu funcionamento.

Caso queira alterar o nome do banco e os dados de acesso, a string de conexão se encontra no arquivo *appsettings.json* dentro do projeto *API*

1. Instalar a ultima versão do .NET Core SDK (caso já não tenha)
2. Navegue para a pasta do projeto utilizando `cd src\Api\`
3. Após isso você precisa atualizar o banco utilizando `dotnet ef database update`
4. Para iniciar o servidor utilize `dotnet run`