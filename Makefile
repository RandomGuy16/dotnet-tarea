# Variables
DB_CONTAINER=mibotica_db

.PHONY: up down db-init build run test

## Muestra esta pantalla de ayuda con todos los comandos disponibles
help:
	@echo "Uso: make [objetivo]"
	@echo ""
	@echo "Objetivos disponibles:"
	@grep -E '^[a-zA-Z_-]+:.*?## .*$$' $(MAKEFILE_LIST) | sort | awk 'BEGIN {FS = ":.*?## "}; {printf "  \033[36m%-15s\033[0m %s\n", $$1, $$2}'

# Levanta el contenedor de SQL Server en segundo plano
up:
	docker compose up -d

# Detiene y borra los contenedores
down:
	docker compose down

# Aplica el script SQL del profesor automáticamente al contenedor
db-init:
	docker exec -i $(DB_CONTAINER) /opt/mssql-tools18/bin/sqlcmd \
		-S localhost -U sa -P 'mibotica_dbA12345$$' -C \
		-Q "IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'BDPedido') CREATE DATABASE BDPedido;"
	docker exec -i $(DB_CONTAINER) /opt/mssql-tools18/bin/sqlcmd \
		-S localhost -U sa -P 'mibotica_dbA12345$$' -C \
		< ./script.sql

		
# Compila el proyecto .NET
build:
	dotnet build

# Corre el proyecto .NET
run:
	dotnet run

# test project
test:
	dotnet test
