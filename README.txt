- Backend desenvolvido em C#, .net 8.0, Dapper

- Bando de dados em Postgre SQL

Descrição dos passos a serem seguidos para subir a aplicação

1) Baixe os aplicativos

- Docker Desktop
https://www.docker.com/products/docker-desktop/

- pgAdmin
https://www.pgadmin.org/download/pgadmin-4-windows/

2) Script a ser executado no terminal para subir no Docker desktop o servidor de dados, onde a senha do usuário admin (postgres) é "Xpto@10'

docker run -d --name srvdb001 -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=Xpto@10 -p 5432:5432
docker update --restart=always [ID DO CONTAINER]


3) No pgAdmin, logue com o usuário recem criado (postgres) e execute os scripts contidos em ...\Documentação\Script de acordo com sequencia

   - 1-DDL - Banco de dados.sql

   - 2-DDL - Tabelas.sql

   - 3-DCL - Permissoes.sql

4) Arquivos de log estão em ../Logs

5) Publicação no Docker

- No arquivo "appsettings.json", substituir "127.0.0.1" por "host.docker.internal"

- Pelo terminal, executar de dentro da pasta Taking:
docker build -t avaliacao_taking .
docker run -p 4950:80 --name taking_web_api avaliacao_taking
docker update --restart=always [ID DO CONTAINER]