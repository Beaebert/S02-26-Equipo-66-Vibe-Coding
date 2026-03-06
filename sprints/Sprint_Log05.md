# 🏁 Sprint Log 05: Sprint Final y Preparación de Exposición

**Fecha Inicio del Sprint:** Lunes 02/03/2026
**Fecha Cierre del Sprint:** Viernes 06/03/2026
**Estado:** 🚧 En Progreso
**Scrum Master (Acting):** Analista Programadora C# [Beatriz Ebert Desarrolladora .NET ](https://github.com/Beaebert)

## 🎯 Objetivo del Sprint
Finalizar los detalles del proyecto (código y presentación visual), ensayar la demostración del simulador y realizar la exposición final del proyecto "Justina" el día Viernes 06 de Marzo en la reunión grupal por Google Meet con todo el grupo de simulación laboral.

## 📅 Bitácora Diaria (Daily Log)

### Lunes 02/03 - Reunión de Coordinación Final
* **Actividad:**
    * Reunión de equipo (Lara Almirón, Cristian Dal Piva, Beatriz Ebert).
    * Diálogo y planificación enfocados en el estado actual de la **Presentación (Google Slides)** y la grabación del **Video de Demostración**.
    * Se evaluó el estado del **Deploy** para revisar si es posible publicar la aplicación web, o si se mantendrá la demostración de forma local durante la exposición.
    * **Investigación de Hosting:** Beatriz se encuentra investigando qué servicio de plataforma (PaaS/IaaS) puede ser más beneficioso para el proyecto (evaluando opciones como **Vercel**, **Azure Web Apps**, **Render**, entre otras menos conocidas), buscando detalles técnicos sobre su compatibilidad nativa para hostear **Blazor WebAssembly** y la API en **C# .NET**.
    * Organización general y reparto de temas a exponer para la reunión del próximo Viernes 06.

### Martes 03/03 - Ajustes Finales
* **Actividad:**
    * **Desarrollo (Beatriz Ebert):** Finalización de la integración de la API C# con el frontend Blazor y preparación de una versión estable para mostrar.
    * **Diseño UX/UI (Lara Almirón y Cristian Dal Piva):** Acabados finales en la interfaz gráfica y revisión de la consistencia visual en las Google Slides.
* **Resultados Esperados:**
    * Código cerrado y funcional para el MVP.
    * Presentación en Google Slides terminada y lista para exponer.

### Miércoles 04/03 - QA, Resolución de Bugs Matemáticos y Deployment a Azure
* **Actividad:**
    * **Testing (Beatriz Ebert):** Se realizaron pruebas exhaustivas (QA) de la experiencia de usuario dentro de la simulación.
    * **Resolución de Errores:** Se identificó y resolvió un "falso positivo" donde la asimetría topográfica entre el centro visual de Blazor (800x500px) y la fórmula del backend C# provocaba bajas en el puntaje de "Precisión Global" catalogando equivocadamente los movimientos perfectos como "Peligro Clínico".
    * Se incluyó una funcionalidad de "Pausa de Rastreo" mediante el *click derecho* para permitir al usuario cambiar herramientas sin penalización al atravesar el lienzo.
    * Se respaldaron y consolidaron todos los arreglos actualizando exitosamente la rama `main` del repositorio oficial en GitHub.
    * **Deployment en la Nube:** Tras investigar las opciones técnicas, se logró automatizar el despliegue hacia **Microsoft Azure (App Services)** mediante pipelines CI/CD configurados en **GitHub Actions**. El entorno quedó dividido en dos aplicaciones (Frontend Blazor y Backend API), logrando que ambas instancias estén "En verde" y conectadas exitosamente en la nube.
    * **Equipo completo:** Ensayo general de la presentación en video (ahora sobre la versión cloud en vivo), asegurando que los tiempos coincidan con los requerimientos de la exposición.
* **Resultados Esperados:**
    * Código cerrado y funcional para el MVP.
    * Presentación en Google Slides terminada y lista para exponer.
### Jueves 05/03 - QA en Producción y Resolución de Bugs Críticos
* **Actividad:**
    * **Testing en Vivo (Beatriz Ebert):** Se realizaron pruebas de la aplicación directamente sobre el entorno de producción en Microsoft Azure.
    * **Resolución de Bug "Falso 100%":** Se detectó que el sistema siempre calculaba un 100% de precisión sin importar los errores cometidos. La investigación arrojó dos causas raíz:
        1. **Bloqueo CORS en Azure:** La configuración de seguridad en el backend `justina-api` solo permitía peticiones transversales (CORS) en el entorno local (Development). Se reescribió la arquitectura del `Program.cs` para habilitar el tráfico desde el frontend Blazor App Service hacia la API.
        2. **Ausencia de Esquema de Base de Datos:** Aunque se había configurado `db.Database.Migrate()`, los planos de Entity Framework (Migrations) nunca se habían generado. Azure intentaba escribir las colisiones en una tabla `Robots` inexistente (generando un Error 500 silencioso oculto por el UI). Se instaló la herramienta CLI de EF Core y se generó la migración `InitialCreate`.
    * **Despliegue Correctivo:** Se actualizaron e integraron exitosamente los parches técnicos. La aplicación en la nube fue validada 100% funcional, ejecutando penalizaciones precisas.
* **Resultados Esperados:**
    * Entorno Productivo QA Aprobado. El MVP es completamente capaz de detectar, transmitir y almacenar métricas de colisión a través de la nube.

### Viernes 06/03 - Exposición Final
* **Actividad Clave:** 
    * **Reunión Grupal (Google Meet):** Presentación del proyecto Justina frente al grupo de simulación laboral de No Country.
    * Defensa de las decisiones técnicas (Arquitectura en Capas, Pivot a Blazor, Mapeo de Coordenadas) y diseño de producto enfocado en la usabilidad médica.
* **Resultados Esperados:**
    * Dar cierre oficial al proyecto de simulación laboral, demostrando resiliencia y capacidad de adaptación del equipo reducido frente a las adversidades de gestión.

## 📊 Retrospectiva del Sprint 05 (A Completar post-exposición)

### 👍 Lo que hicimos bien (Start doing)
* 

### 👎 Lo que debemos mejorar (Stop doing)
* 

## ⏭️ Cierre del Proyecto
* Agradecimientos y conclusiones finales del trabajo en equipo.
