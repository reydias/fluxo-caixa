# fluxo-caixa

docker run --name postgres-db -e POSTGRES_PASSWORD=12345678 -e POSTGRES_USER=fluxocaixa -e POSTGRES_DB=fluxocaixa -p 5432:5432 -d postgres:latest

dotnet ef database update --project FluxoCaixa.Data --startup-project FluxoCaixa.Api

docker network create fluxocaixa-network

docker network connect fluxocaixa-network postgres-db

docker network connect fluxocaixa-network FluxoCaixa.Api

