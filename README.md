# Fluxo de Caixa - API GraphQL

Este projeto fornece uma API para gerenciar lançamentos financeiros, utilizando GraphQL para as consultas e mutações.

## Pré-requisitos

* Docker instalado e funcionando.
* .NET SDK 7 ou superior instalado.
* Uma conta no GitHub (se você quiser clonar o repositório).

## Instalação

1. **Clone o repositório:** (Se aplicável)

   ```bash
   git clone <URL_DO_REPOSITORIO>
   cd <nome_do_repositorio>

Execução
Inicie o banco de dados PostgreSQL:

docker-compose up -d postgres-db
Aplique as Migrações:

dotnet ef database update --project FluxoCaixa.Data --startup-project FluxoCaixa.Api
Inicie a API:

docker-compose up -d fluxocaixa-api
Acessando a Aplicação
A aplicação estará acessível através da interface gráfica do Nitro no endereço: http://localhost:5000/graphql/

Exemplos de Queries e Mutações
Você pode utilizar as seguintes queries e mutações para interagir com a API:

Listar Lançamentos:

query {
  lancamentos {
    id
    tipo
    valor
    data
    descricao
  }
}

Adicionar Lançamento:

mutation {
  addLancamento(input: {
    tipo: "C",
    valor: 100.0,
    data: "2024-11-18T10:40:00Z",
    descricao: "Venda de produto"
  }) {
    id
    tipo
    valor
    data
    descricao
  }
}
Consultar Consolidado Diário:

query{
  consolidadoDiario{
    data
    saldo
  }
}
Remover Lançamento: (Substitua "a3968016-ea5a-455f-a0e8-334c250b87e1" pelo ID do lançamento)

mutation{
  removeLancamento(id:"a3968016-ea5a-455f-a0e8-334c250b87e1")
  {
    id
  }
}
Parando a Aplicação
Para parar os containers do Docker, execute:

docker-compose down



