# 🫔 API - La Cazuela Chapina

Este proyecto es una API desarrollada en **.NET** para **La Cazuela Chapina**, un emprendimiento que fusiona dos pilares fundamentales de la cocina guatemalteca:

los **tamales tradicionales** y las **bebidas ancestrales de maíz y cacao**.

El objetivo de esta API es gestionar de forma eficiente los procesos operativos y ventas del negocio.

## ⚙️ Requisitos para levantar el proyecto en local

Para ejecutar este proyecto en tu entorno local, asegúrate de tener instalado lo siguiente:

### 🔧 Software necesario

- [.NET SDK](https://dotnet.microsoft.com/es-es/download)
  Necesario para compilar y ejecutar la API.
- [Docker Desktop](https://www.docker.com/get-started/)
  Usado para levantar contenedores de base de datos u otros servicios necesarios.

### 💡 Recomendaciones si usas Visual Studio Code

Si utilizas **VS Code** como editor de código y compilador, se recomienda instalar la siguiente extensión para una mejor experiencia de desarrollo:

- [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)

## ⚙️ Configuración del entorno de trabajo

Para ejecutar este proyecto en tu entorno local, asegúrate de tener instalado lo siguiente:

### 🔧 Software necesario

- Entity Framework (EF)
  ORM para trabajar con .net y base de datos.

  ```bash
  dotnet tool install --global dotnet-ef
  ```

- Instalar dependencias del proyecto
  Ejecuta el comando dotnet restore para descargar e instalar todas las dependencias NuGet definidas en el archivo .csproj
  ```bash
  dotnet restore
  ```

## ⚙️ Configuración del base de datos

Para ejecutar este proyecto en tu entorno local, asegúrate de tener levantado tu servicio de base de datos y creadas las tablas con conjunto de sus Bulks(Data de prueba para poder realizar reporteria y visualizar información simulando una aplicación productiva)

### 🔧 Scripts Necesarios

- Docker Desktop
  Se utilizara para correr un contenedor de SQL Server asegurando que la aplicación se ejecute de manera consistente en diferentes entornos.
  En la raiz del proyecto encontraras el archivo **`cazuela_chapina_core\docker-compose.yaml**` el cual contiene la configuración de nuestro contenedor, información y credenciales de prueba para nuestro servicio de base de datos.
  Antes de levantar la API es necesario correr el siguiente comando para levantar el contenedor.
  ```bash
  docker-compose up -d
  ```

### 🗃️ Configuración de Base de Datos - Simulación de Ambiente Productivo

Este proyecto incluye un conjunto de scripts SQL ubicados en la carpeta `Scripts/` que permiten crear y poblar una base de datos para simular un entorno productivo. Ideal para desarrollo, pruebas y validaciones internas.

## 📂 Estructura de la Carpeta `Scripts/`

```

Scripts/
├── tables.sql       # ✅ Script inicial: crea la base de datos, las tablas y datos base
├── bulk_data.sql    # 📦 Script que carga datos simulados para pruebas y desarrollo

```

## 🛠️ Requisitos

- Motor de base de datos compatible con los scripts proporcionados _(por ejemplo, SQL Server / MySQL / PostgreSQL)_
- Cliente SQL o herramienta de gestión de base de datos (SQL Server Management Studio, Azure Data Studio, etc.)

## ⚙️ Instrucciones de Ejecución

1. **Ejecutar `tables.sql`**

   Este script debe ejecutarse primero. Contiene:

   - Creación de la base de datos.
   - Creación de las tablas necesarias.
   - Inserciones de datos iniciales (Sucursales, Combos, ComboItems, Usuarios.).

2. **Ejecutar `bulk_data.sql`**

   Este script inserta datos masivos en las tablas, simulando registros operativos como ventas, movimientos, inventario, etc.

   Esto permite trabajar con un volumen representativo de datos para validaciones, reportes o pruebas de rendimiento.

### Configurar Entity Framework (EF Core)

Luego de ejecutar los scripts SQL, es necesario generar la tabla de manejo de usuarios para autenticación, la cual será gestionada mediante Entity Framework.

### Pasos:

- **Instalar la herramienta de Entity Framework CLI (si aún no lo has hecho):**

```bash

dotnet tool install --global dotnet-ef

```

- **Verifica que tu proyecto tenga instaladas las dependencias necesarias**, **(si aún no lo has hecho):**
