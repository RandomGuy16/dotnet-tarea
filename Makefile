# Variables
DB_CONTAINER=mibotica_db

# Detect Windows (PowerShell / cmd) vs Unix-like shells
ifeq ($(OS),Windows_NT)
# On Windows use backslash path for docker cp and single-quote password works in cmd/powershell
DOCKER_CP = docker cp .\script.sql $(DB_CONTAINER):/tmp/script.sql
SQLCMD_PASS = 'mibotica_dbA12345$$'
# Ejecutar con la ruta de proyecto Windows (backslashes) al usar 'make run' en Windows
RUN_ARGS = --project .\MiBotica.SolPedido.Cliente.Web\MiBotica.SolPedido.Cliente.Web.csproj
else
DOCKER_CP = docker cp ./script.sql $(DB_CONTAINER):/tmp/script.sql
SQLCMD_PASS = 'mibotica_dbA12345$$'
RUN_ARGS = --project MiBotica.SolPedido.Cliente.Web/MiBotica.SolPedido.Cliente.Web.csproj
endif

.PHONY: up down db-init build run test

# Mostrar la ayuda por defecto cuando se ejecuta 'make' sin argumentos
.DEFAULT_GOAL := help

## Muestra esta pantalla de ayuda con todos los comandos disponibles
help:
	@echo "Uso: make [objetivo]"
	@echo ""
	@echo "Objetivos disponibles:"
	@echo "  up             Levanta el contenedor de SQL Server en segundo plano"
	@echo "  down           Detiene y borra los contenedores"
	@echo "  db-init        Aplica el script SQL al contenedor (importa script.sql)"
	@echo "  build          Compila el proyecto .NET"
	@echo "  run            Corre el proyecto .NET"
	@echo "  test           Ejecuta las pruebas (dotnet test)"

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
	dotnet run $(RUN_ARGS)

# test project
test:
	dotnet test
