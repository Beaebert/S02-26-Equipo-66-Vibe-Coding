# Equipo S02-26-Equipo-66-Vibe-Coding
Simulación Laboral de No Country - Febrero 2026: Plataforma de simulación y entrenamiento para cirugía robótica.
# Justina: Simulador de Operación Quirúrgica con Robot
## Proyecto de Simulación de Operación Renal Mínimamente Invasiva

### 🎯 Visión del Producto
Desarrollar una plataforma digital de simulación que permita a los cirujanos ensayar trayectorias de las intervenciones renales que realizarán posteriormente con un robot quirúrgico.

- **Video de Presentación:**
https://youtu.be/E4ovj5YQ8K8
- **Repositorio del Desarrollo del Proyecto con su documentación en detalle:**
https://github.com/Beaebert/S02-26-Equipo-66-Vibe-Coding
- **Aplicación desplegada en el ecosistema de Azure:**
https://justina-blazor.azurewebsites.net/

**Objetivos de esta plataforma:**
- Que el Operador Humano pueda simular el control del brazo robótico (efector final/pinza) mediante periféricos estándar (mouse/puntero).
- Que el Operador Humano pueda interactuar con una interfaz de usuario (UX) realista, familiarizándose con el entorno de una consola quirúrgica en un ambiente seguro.
- Recopilar métricas en tiempo real para conocimiento y posterior evaluación de desempeño de la sesión. Actualmente registrando:
  - **Precisión Geométrica:** Cálculos cartesianos de colisiones visuales (Advertencias y Peligros Clínicos).
  - **Economía de Movimiento:** Tracking del desplazamiento total en píxeles del brazo robótico.
  - **Errores de Ejecución:** Registro de intentos fallidos (clicks en zonas no permitidas).
  - **Tiempo por Sesión:** Segundos transcurridos desde el inicio al fin del procedimiento.
- Corroborar la viabilidad lógica del sistema para, en el futuro, acoplar este "cerebro" a un robot de hardware real.

### 🛠️ Resumen de Herramientas (Stack Tecnológico)
Para la construcción ágil del MVP (*Vibe Coding*), nos alineamos con el catálogo tecnológico de No Country utilizando:

* **Frontend (UI/UX):** 
    * **Figma** (Prototipado médico), 
    * **Radzen Blazor Studio** y 
    * **Blazor WebAssembly** (Desarrollo de la interfaz de usuario interactiva 100% en C#).
* **Backend (API & Core):** 
    * **C# .NET 10** y 
    * **Antigravity IDE** (Desarrollo de la lógica espacial y redacción de la documentación nativa en Markdown).
* **Base de Datos:** 
    * **SQLite** + **Entity Framework Core**. 
  > 💡 *Nota: Se eligió SQLite por su agilidad (zero-config) para la fase MVP. Al usar EF Core, la migración a sistemas altamente escalables y robustos para historiales clínicos reales (como **SQL Server** o **PostgreSQL**) en futuras etapas de producción será transparente y solo requerirá cambiar un string de conexión en la API, respetando la estructura de métricas relacionales.*
* **Gestión y Colaboración:** 
    * **Markdown** (Versionado en Git) y 
    * **Notion** (Proyectado para la gestión del conocimiento del equipo multidisciplinario).

### 👥 Conformación del Equipo (Actualizada)
* **Tech Lead & Full Stack .NET Vibe Coding: [Beatriz Ebert](https://github.com/Beaebert):** Desarrollo del Core Backend (API), Frontend (Blazor), Arquitectura de Software (Analista Programadora C# .NET), y gestión ágil (Scrum Master Acting).
* **Equipo de Diseño UX/UI:** Investigación de usuario, diseño de interfaz de control, prototipado de alta fidelidad en Figma y diseño del feedback visual médico.
*(Nota: El equipo se reestructuró durante el Sprint 02, pivotando hacia un stack 100% .NET para asegurar la viabilidad del MVP tras la necesidad de absorber las tareas de Data Engineer y No-Code Developer).*

### 💻 Stack Tecnológico Definitivo
Para garantizar la entrega del MVP en los tiempos establecidos y unificar el lenguaje de desarrollo, se utiliza:
* **Backend (Core Engine & API):** C# .NET (ASP.NET Core Web API). Encargado de la lógica espacial, física, detección de colisiones y validación de zonas.
* **Frontend (Interfaz Gráfica):** Radzen Blazor WebAssembly (C#). Consolidación de la UI médica consumiendo la API en tiempo real.
* **Diseño y Prototipado:** Figma.

### 🏗️ Arquitectura de la Plataforma (Decoupled Architecture)
Para el desarrollo del MVP, el equipo ha optado por una **Arquitectura Desacoplada** basada en API REST y separación en capas. Esta decisión estratégica garantiza la escalabilidad del simulador a largo plazo:

1. **El Motor Lógico (Backend API):** Contiene el "Cerebro" del simulador. Al ser una API REST independiente, el núcleo lógico queda completamente agnóstico al hardware o a la pantalla que lo consuma.
2. **La Consola de Usuario (Frontend Blazor):** Actúa como el cliente actual que consume los datos de la API para renderizar la experiencia visual. **A pesar de estar construida con la misma tecnología base (.NET/C#) que el Backend, es una capa estrictamente separada e independiente.**

**🚀 Preparación para el Futuro:**
Esta estricta separación de capas garantiza que las funcionalidades sean independientes. Si en el futuro los stakeholders solicitan cambiar la tecnología del Frontend (ej. a React, Vue, Flutter, o motores 3D como Unity) o conectar el sistema a una Base de Datos en la nube para telemetría compleja, **el núcleo Backend permanecerá intacto**. Solo será necesario desechar la capa visual actual y conectar los nuevos clientes a los endpoints de la API existente.

### 🧑‍⚕️ User Story: Actor Cirujano 
Se considera como principal usuario directo del simulador al médico cirujano que en el futuro se encontrará en la situación de operar el brazo robot a través de la interfaz.

**Título:** Control de precisión del efector final (pinza) en entorno 2D/3D.  
**Actor:** Médico Cirujano.  

**Descripción:**
> *Como cirujano especialista en intervenciones renales, quiero una simulación de uso del sistema de pinza robótica, para ensayar de forma segura el abordaje al riñón con el mando y evitar colisiones accidentales en otras zonas que puedan ocasionar daños clínicos.*

**Criterios de Aceptación:**
1. La interfaz no debe estar saturada de colores estridentes o agotadores para la vista (foco en modos oscuros/médicos), ya que las intervenciones exigen alta concentración sostenida.
2. El sistema debe generar una señal de alerta inmediata (feedback visual) cuando el puntero sale del "área segura" o entra en zonas de riesgo (laterales o profundidad).
3. La plataforma debe calcular y mantener el estado de la simulación en tiempo real (trayectos, colisiones, herramientas activas) comunicando el Backend con el Frontend.