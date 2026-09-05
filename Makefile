# Variables
DB_CONTAINER=mibotica_db

# Detect Windows (PowerShell / cmd) vs Unix-like shells
ifeq ($(OS),Windows_NT)
# On Windows use backslash path for docker cp and single-quote password works in cmd/powershell
DOCKER_CP = docker cp .\script.sql $(DB_CONTAINER):/tmp/script.sql
SQLCMD_PASS = 'mibotica_dbA12345$$'
else
DOCKER_CP = docker cp ./script.sql $(DB_CONTAINER):/tmp/script.sql
SQLCMD_PASS = 'mibotica_dbA12345$$'
endif

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
# Usa variables para que funcione en Windows y Linux/macOS
db-init:
	@echo "Creando DB BDPedido si no existe..."
	docker exec -i $(DB_CONTAINER) /opt/mssql-tools18/bin/sqlcmd \
		-S localhost -U sa -P $(SQLCMD_PASS) -C \
		-Q "IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'BDPedido') CREATE DATABASE BDPedido;"

	@echo "Copiando script.sql al contenedor..."
	$(DOCKER_CP)

	@echo "Importando ./script.sql en BDPedido..."
	docker exec -i $(DB_CONTAINER) /opt/mssql-tools18/bin/sqlcmd \
		-S localhost -U sa -P $(SQLCMD_PASS) -C -i /tmp/script.sql

		
# Compila el proyecto .NET
build:
	dotnet build

# Corre el proyecto .NET
run:
	dotnet run

# test project
test:
	dotnet test
