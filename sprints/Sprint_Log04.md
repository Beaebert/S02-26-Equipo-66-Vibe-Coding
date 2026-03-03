# 🏁 Sprint Log 04: Presentación Final y Continuidad del Desarrollo

**Fecha Inicio del Sprint:** Lunes 23/02/2026
**Fecha Cierre del Sprint:** Viernes 27/02/2026
**Estado:** ✅ Finalizado
**Scrum Master (Acting):** Analista Programadora C# [Beatriz Ebert Desarrolladora .NET ](https://github.com/Beaebert)

## 🎯 Objetivo del Sprint
Comenzar la preparación de la presentación final y material audiovisual del simulador "Justina". Iniciar el armado de las diapositivas y organizar las ideas a exponer, al mismo tiempo que se empuja el desarrollo técnico final en C# y Blazor dentro de las limitaciones de tiempo del equipo reducido.

## 📅 Bitácora Diaria (Daily Log)

### Lunes 23/02 y Martes 24/02 - Organización de Presentación Final
* **Actividad:**
    * Comenzamos a trabajar en la presentación de **Google Slides**.
    * Objetivo de las Slides: Poder presentar y explicar el proyecto de forma estructurada en un video demostrativo y en la reunión final.
    * Proceso de investigación y organización de las ideas principales, estructura técnica y de diseño a exponer.
* **Resultados:**
    * Definición de la estructura de la presentación.

### Martes 24/02 - Organización de Presentación Final
* **Actividad:**
    * Se continuo desarrollando la presentación Slides y se subio la documentación realizada a la plataforma No Country.

### Miércoles 25/02 - Situación del Equipo y Avances Técnicos
* **Actividad:**
    * Se evalúa el avance técnico y la velocidad del equipo. Como somos únicamente tres personas (Lara Almirón, Cristian Dal Piva como diseñadores y Beatriz Ebert como desarrolladora), el avance del proyecto va lento.
    * **Desarrollo (Vibe Coding):** Beatriz Ebert (stack .NET) es la única responsable del código. Debido a que continúa cursando estudios universitarios, está bastante limitada de tiempo y se ha atrasado frente a los tiempos ideales.
    * A pesar de las demoras, Beatriz continúa desarrollando el simulador integrando la API en C# y la interfaz visual en Radzen Blazor.

### Jueves 26/02 - Organización de Presentación Final y Persistencia de Datos
* **Actividad:**
    * Se finalizó el desarrollo del Front End en Radzen Blazor Studio y se unificaron sus archivos a la carpeta del proyecto.
    * Se subió al repositorio de GitHub el código de la parte Front End.
    * Se continuó con la preparación de la presentación Slides.
    * **Desarrollo Backend/Frontend:** Integración exitosa de Base de Datos local usando **Entity Framework Core con SQLite**.
    * Se configuró el ciclo de vida de **Sesiones (Session IDs)** en la Base de Datos para que cada ejecución de simulación genere reportes independientes (guardando Fecha, Doctor, Cantidad de Advertencias y Peligros Clínicos).
    * Se logró un mapeo " pixel-perfect" entre las zonas seguras visuales establecidas por los diseñadores en el Front End y las matemáticas cartesianas de la API de C# para eliminar la latencia visual.
    * La pantalla final de Resultados ahora es **100% dinámica**, consumiendo la base de datos (EndPoints GET) para calcular estadísticamente la "Precisión Global" y entregar insignias de UX en base a las penalizaciones de la sesión finalizada.

### Viernes 27/02 - Organización de Presentación Final y Persistencia de Datos
* **Actividad:**
    * **Continuidad Técnica:** Se continuó y profundizó el arduo trabajo iniciado el día Jueves respecto a la integración Backend-Frontend.
    * Se realizaron ajustes finos en el cálculo de "Precisión Global" y las métricas de penalización de la interfaz en base a las pruebas de lectura/escritura de la base de datos **SQLite**.
    * Se evaluó el mapeo en tiempo real de las coordenadas X/Y para el control de la zona segura.
    * **Presentación y Demo:** Se coordinaron los planes a seguir para la exposición, incluyendo la búsqueda de herramientas apropiadas para la grabación del video demostrativo.
    * Continuación del desarrollo de los contenidos teóricos en las Google Slides.

## 📊 Retrospectiva del Sprint 04

### 👍 Lo que hicimos bien (Start doing)
* Enfocarnos en tener la presentación preparada a tiempo para la reunión final.
* Mantener la comunicación fluida sobre la disponibilidad real de horas del equipo y organizar entregables en base a eso.

### 👎 Lo que debemos mejorar (Stop doing)
* 

## ⏭️ Consideraciones Finales
* Finalizar la grabación del video explicativo y dejar listo el repositorio para la evaluación final.