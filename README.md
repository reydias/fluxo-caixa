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

2. **Execução**
 a. Inicie o banco de dados PostgreSQL:

```bash
docker-compose up -d postgres-db
```
 b. Aplique as Migrações:

```bash
dotnet ef database update --project FluxoCaixa.Data --startup-project FluxoCaixa.Api
```

 c. Inicie a API:

```bash
docker-compose up -d fluxocaixa-api
```

3. **Acessando a Aplicação**
A aplicação estará acessível através da interface gráfica do Nitro no endereço: http://localhost:5000/graphql/

**Exemplos de Queries e Mutações**
Você pode utilizar as seguintes queries e mutações para interagir com a API:

- Listar Lançamentos:

```bash
query {
  lancamentos {
    id
    tipo
    valor
    data
    descricao
  }
}
```
- Adicionar Lançamento (tipo C ou D, respectivamente, Crédito ou Débito):

```bash
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
```
- Consultar Consolidado Diário:

```bash
query{
  consolidadoDiario{
    data
    saldo
  }
}
```
- Remover Lançamento: (Substitua "a3968016-ea5a-455f-a0e8-334c250b87e1" pelo ID do lançamento)

```bash
mutation{
  removeLancamento(id:"a3968016-ea5a-455f-a0e8-334c250b87e1")
  {
    id
  }
}
```
4. **Parando a Aplicação**
Para parar os containers do Docker, execute:

```bash
docker-compose down
```


