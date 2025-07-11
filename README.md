# Sistema de Modernización SAR-FAB

Sistema de gestión para la Fuerza Aérea Boliviana (FAB) que moderniza y digitaliza los procesos administrativos del Servicio Voluntario de Búsqueda y Rescate (SAR).

## 📋 Tabla de Contenidos

- [Descripción General](#descripción-general)
- [Características Principales](#características-principales)
- [Arquitectura del Sistema](#arquitectura-del-sistema)
- [Tecnologías Utilizadas](#tecnologías-utilizadas)
- [Requisitos del Sistema](#requisitos-del-sistema)
- [Instalación y Configuración](#instalación-y-configuración)
- [Módulos del Sistema](#módulos-del-sistema)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Documentación API](#documentación-api)
- [Despliegue en Producción](#despliegue-en-producción)

## 📝 Descripción General

El Sistema de Modernización SAR-FAB es una plataforma web diseñada para optimizar la gestión de recursos, personal y operaciones del Servicio Voluntario de Búsqueda y Rescate de la Fuerza Aérea Boliviana. La aplicación proporciona herramientas modernas para la administración eficiente de las operaciones diarias, mejorando la coordinación y el control de los procesos institucionales.

## ✨ Características Principales

- **Gestión Integral**: Control unificado de personal, recursos y operaciones
- **Arquitectura Moderna**: Implementación de Clean Architecture para escalabilidad y mantenibilidad
- **Seguridad**: Autenticación JWT
- **Interfaz Intuitiva**: Diseño responsive y moderno con experiencia de usuario optimizada
- **Reportes**: Generación de reportes de operaciones, guardias y cursos
- **Notificaciones**: Sistema de alertas para chequeos médicos y control de faltas
- **Trazabilidad Completa**: Registro detallado de todas las actividades de los voluntarios

## 🏗️ Arquitectura del Sistema

El proyecto implementa **Clean Architecture** con cuatro capas principales:

### Domain Layer
- Contiene las entidades del negocio y la lógica de dominio
- Independiente de frameworks y tecnologías externas
- Define las reglas de negocio fundamentales

### Application Layer
- Implementa los casos de uso del sistema
- Orquesta el flujo de datos entre las capas
- Define interfaces para servicios externos

### Infrastructure Layer
- Implementa la persistencia de datos
- Gestiona servicios externos (email, notificaciones)
- Contiene las implementaciones concretas de repositorios

### Presentation Layer
- API REST con .NET 8
- Aplicación SPA con React
- Maneja la interacción con el usuario

## 🛠️ Tecnologías Utilizadas

### Frontend
- **React 18** con TypeScript para desarrollo de UI moderna
- **Vite** como herramienta de construcción rápida
- **Tanstack Query** para gestión de estado del servidor
- **Tanstack Router** para enrutamiento declarativo
- **Tailwind CSS** para estilos utilitarios
- **React Hook Form + Zod** para formularios con validación
- **ApexCharts** para visualización de datos

### Backend
- **.NET 8** como framework principal
- **Entity Framework Core 8** para ORM
- **MySQL 8.0** como base de datos
- **JWT Bearer** para autenticación
- **Swagger/OpenAPI** para documentación automática
- **Serilog** para logging estructurado
- **AutoMapper** para mapeo de objetos

### Infraestructura
- **Docker** y **Docker Compose** para containerización
- **Ubuntu Server** como sistema operativo de producción
- **Systemd** para gestión de servicios

## 💻 Requisitos del Sistema

### Requisitos de Desarrollo
- Node.js 18.0 o superior
- .NET SDK 8.0 o superior
- MySQL 8.0 o superior
- Visual Studio 2022 o Visual Studio Code
- Git para control de versiones

### Requisitos de Hardware
- Sistema Operativo: Windows 10+, macOS 10.15+, o Linux Ubuntu 20.04+
- RAM: Mínimo 8GB (16GB recomendado)
- Almacenamiento: 2GB de espacio libre mínimo
- Procesador: Intel Core i5 o equivalente

### Requisitos de Producción
- Ubuntu Server 20.04 o superior
- Docker y Docker Compose instalados
- Mínimo 4GB RAM
- 20GB de espacio en disco
- IP estática configurada

## 🚀 Instalación y Configuración

### Configuración Inicial

1. **Clonar el repositorio**
   ```bash
   git clone [url-del-repositorio]
   cd modernizacion-sarfab
   ```

2. **Configurar la base de datos**
   - Crear una base de datos MySQL llamada `sarfab_modernization`
   - Configurar las credenciales en `appsettings.json`

3. **Instalar dependencias del Backend**
   ```bash
   cd Modernization-SARFAB-Backend
   dotnet restore
   ```

4. **Instalar dependencias del Frontend**
   ```bash
   cd modernizacion-sar-fab
   npm install
   ```

### Ejecución en Desarrollo

- **Backend**: Ejecutar desde Visual Studio o mediante `dotnet run`
- **Frontend**: Ejecutar `npm run dev` en la carpeta del proyecto React

## 📦 Módulos del Sistema

### 🔐 Autenticación y Seguridad
Gestión completa de usuarios con autenticación segura mediante tokens JWT y control de sesiones.

### 👥 Gestión de Personal
Administración integral de los rescatistas, personal militar y proceso de reclutamiento.

### 🏥 Gestión de Sanidad
Control de tratamientos y diagnósticos de los voluntarios.

### 📦 Control de Inventario
Administración de recursos materiales, control de stock, gestión de solicitudes y asignaciones de elementos utilizados para las operaciones.

### ✈️ Gestión de Operaciones
Planificación y control de operaciones realizadas por los voluntarios al mando de los instructores y control de asistencia.

### 🔔 Sistema de Notificaciones
Alertas de notificaciones dentro del sistema para alertar al administrador el vencimiento del chequeo médico de los voluntarios y su control de faltas.

## 📁 Estructura del Proyecto

### Backend (.NET 8 - Clean Architecture)
```
Modernization-SARFAB-Backend/
├── Domain/                 # Entidades y lógica de negocio
├── Application/           # Casos de uso y servicios
├── Infrastructure/        # Implementaciones y persistencia
└── WebAPI/               # Controladores y configuración API
```

### Frontend (React + TypeScript)
```
modernizacion-sar-fab/
├── src/
│   ├── api/              # Servicios de comunicación con backend
│   ├── components/       # Componentes reutilizables
│   ├── views/           # Páginas y vistas principales
│   ├── hooks/           # Custom hooks
│   ├── routes/          # Configuración de rutas
│   └── utils/           # Utilidades y helpers
```

## 📖 Documentación API

La documentación completa de la API REST está disponible a través de Swagger cuando el proyecto se ejecuta en modo desarrollo. Los endpoints principales incluyen:

- **Autenticación**: Login, logout, renovación de tokens
- **Personal**: CRUD completo para gestión de reclutas, voluntarios y personal militar
- **Médico**: Gestión de tratamientos
- **Inventario**: Control de recursos (Extracción y devolución)
- **Operaciones**: Administración de operaciones y el control de asistencia a estas
- **Notificaciones**: Envío de alertas de chequeos médicos y faltas excedidas

## 🚢 Despliegue en Producción

### Prerrequisitos
- Servidor Ubuntu con IP estática configurada
- Acceso SSH al servidor
- Usuario con permisos sudo

### Variables de Entorno

Crear archivo `.env` con las siguientes variables:

```env
MYSQL_ROOT_PASSWORD=
MYSQL_DATABASE=
MYSQL_USER=
MYSQL_PASSWORD=
JWT_KEY=
SMTP_PASSWORD=
FRONTEND_URL=http://[IP_SERVIDOR]:3000
VITE_API_URL=http://[IP_SERVIDOR]:5000/api
```

### Proceso de Despliegue

1. **Instalación de Docker**
   ```bash
   sudo apt-get update
   sudo apt-get install -y ca-certificates curl
   sudo install -m 0755 -d /etc/apt/keyrings
   sudo curl -fsSL https://download.docker.com/linux/ubuntu/gpg -o /etc/apt/keyrings/docker.asc
   sudo chmod a+r /etc/apt/keyrings/docker.asc
   
   echo \
     "deb [arch=$(dpkg --print-architecture) signed-by=/etc/apt/keyrings/docker.asc] https://download.docker.com/linux/ubuntu \
     $(. /etc/os-release && echo "$VERSION_CODENAME") stable" | \
     sudo tee /etc/apt/sources.list.d/docker.list > /dev/null
   
   sudo apt-get update
   sudo apt-get install -y docker-ce docker-ce-cli containerd.io docker-buildx-plugin docker-compose-plugin
   ```

2. **Configuración de Docker**
   ```bash
   sudo systemctl enable docker
   sudo systemctl start docker
   sudo usermod -aG docker ${USER}
   ```

3. **Clonar repositorio de despliegue**
   ```bash
   git clone https://github.com/Modernization-Project-FAB-SARFAB/SARFAB-Deploy.git
   cd ~/SARFAB-Deploy
   ```

4. **Configurar variables de entorno**
   ```bash
   nano .env
   ```

5. **Iniciar servicios**
   ```bash
   docker compose up -d --build
   ```

6. **Verificar estado**
   ```bash
   docker compose ps
   docker compose logs api
   docker compose logs frontend
   ```

### Automatización del Arranque

1. **Crear servicio systemd**
   ```bash
   sudo nano /etc/systemd/system/sarfab.service
   ```

2. **Contenido del servicio**
   ```ini
   [Unit]
   Description=Despliegue SARFAB con Docker Compose
   After=network.target docker.service
   Requires=docker.service
   
   [Service]
   Type=oneshot
   WorkingDirectory=/home/[usuario]/SARFAB-Deploy
   ExecStart=/usr/bin/docker compose up -d
   ExecStop=/usr/bin/docker compose down
   RemainAfterExit=true
   
   [Install]
   WantedBy=multi-user.target
   ```

3. **Activar servicio**
   ```bash
   sudo systemctl daemon-reload
   sudo systemctl enable sarfab.service
   sudo systemctl start sarfab.service
   systemctl status sarfab.service
   ```

### Configuración de IP Estática (Opcional)

Para configurar una IP estática en el servidor:

1. **Editar configuración de red**
   ```bash
   sudo nano /etc/netplan/01-netcfg.yaml
   ```

2. **Configuración ejemplo**
   ```yaml
   network:
     version: 2
     ethernets:
       enp0s3:
         dhcp4: no
         addresses:
           - 192.168.0.14/24
         gateway4: 192.168.0.1
         nameservers:
           addresses: [8.8.8.8, 1.1.1.1]
   ```

3. **Aplicar cambios**
   ```bash
   sudo netplan apply
   ```

---

**Sistema desarrollado para la Fuerza Aérea Boliviana - Servicio Voluntario de Búsqueda y Rescate**
