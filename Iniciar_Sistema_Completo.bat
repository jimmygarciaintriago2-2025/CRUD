@echo off
chcp 65001 >nul
title Sistema de Gestión de Alumnos - CRUD y Dashboard
echo ====================================================================
echo   INICIANDO SISTEMA DE GESTIÓN DE ALUMNOS (API REST + DASHBOARD)
echo ====================================================================
echo.
cd /d "%~dp0"

echo [1/2] Iniciando Servidor Web API en segundo plano...
start "API Backend CRUD (Puerto 5292)" cmd /k "dotnet run --project CRUD\CRUD.csproj --launch-profile http"

echo Esperando a que el servidor API esté listo...
timeout /t 3 /nobreak >nul

echo [2/2] Abriendo Dashboard de Windows Forms...
start "" "dashboard\bin\Debug\net10.0-windows\dashboard.exe"

echo.
echo ====================================================================
echo   ¡Listo! El Dashboard y la API se están ejecutando.
echo ====================================================================
