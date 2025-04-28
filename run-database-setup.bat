@echo off

REM Passo 1: Iniciar o docker-compose com o arquivo de override
echo Iniciando o docker-compose com o arquivo de override...
docker-compose -f docker-compose.override.yml up -d

REM Passo 2: Listar todos os containers
echo Listando todos os containers...
docker ps -a



REM Passo 3: Aguardar até que o container da API Web esteja em execução
echo Aguardando o container da API Web iniciar. Isso pode levar alguns momentos, por favor, seja paciente...
:wait_for_webapi_container
set WEBAPI_CONTAINER_RUNNING=false
docker inspect -f "{{.State.Running}}" ambev_developer_evaluation_webapi | findstr "true" >nul
if errorlevel 1 (
    timeout /t 5 >nul
    goto wait_for_webapi_container
)

REM Passo 3.1: Forçar o start nos containers
echo Forçando o start nos containers...
docker start ambev_developer_evaluation_database ambev_developer_evaluation_webapi

echo Ótimo! O container da API Web está em execução.

REM Passo 4: Obter a porta do container da API Web dinamicamente pelo docker ps
echo Obtendo a porta do container da API Web...
for /f "tokens=1,2 delims=->:" %%i in ('docker ps --filter "name=ambev_developer_evaluation_webapi" --format "{{.Ports}}"') do set WEBAPI_PORT=%%j

echo Aguardando a API Web estar pronta na porta %WEBAPI_PORT%...
set /a TIMEOUT_COUNTER=0
:wait_for_webapi_ready
if %TIMEOUT_COUNTER% GEQ 12 (
    echo Tempo limite atingido. A API Web não está pronta.
    exit /b 1
)

curl -s http://localhost:%WEBAPI_PORT%/health >nul 2>&1
if errorlevel 1 (
    timeout /t 5 >nul
    set /a TIMEOUT_COUNTER+=1
    goto wait_for_webapi_ready
)

echo A API Web está pronta.

REM Passo 5: Aguardar até que o PostgreSQL esteja pronto
echo Aguardando o PostgreSQL estar pronto dentro do container...
:wait_for_postgres
docker exec ambev_developer_evaluation_database pg_isready -U developer >nul 2>&1
if errorlevel 1 (
    timeout /t 5 >nul
    goto wait_for_postgres
)

echo PostgreSQL está pronto.

REM Passo 6: Criar um log do container da API Web
echo Criando log do container da API Web em log.txt...
docker logs ambev_developer_evaluation_webapi > log.txt

REM Step 6: Enter the database container and execute the SQL script
echo Executing init-database.sql inside the database container...
docker exec -i ambev_developer_evaluation_database psql -U developer -d developer_evaluation < init-database.sql

REM Step 7:  Products e Customers tables
echo Showing data from Products table...
docker exec -i ambev_developer_evaluation_database psql -U developer -d developer_evaluation -c "SELECT * FROM \"Products\";"

echo Showing data from Customers table...
docker exec -i ambev_developer_evaluation_database psql -U developer -d developer_evaluation -c "SELECT * FROM \"Customers\";"

echo Tudo pronto! O script foi ajustado para executar as migrações no container.

REM evitar fechamento automático
pause