# 🚀 Estrategia de Deployment (Hosting) para Justina Simulador

La arquitectura de Justina consta de dos partes principales construidas sobre **.NET 10**:
1. **Frontend:** Blazor WebAssembly (WASM).
2. **Backend:** ASP.NET Core Web API + SQLite.

A continuación, se analizan las opciones de hosting investigadas para determinar la viabilidad del despliegue del MVP.

---

## 1. Vercel / Netlify / GitHub Pages (Static Site Generators)
Plataformas famosas por su rapidez y gratuidad para frontends modernos (React, Vue, Angular).

*   **Frontend (Blazor WASM):** ✅ **COMPATIBLE.** Blazor WebAssembly, al compilarse, genera archivos estáticos puros (`.dll`, `.wasm`, `.html`, `.css`). Por lo tanto, puede alojarse gratuitamente en cualquiera de estas plataformas estáticas.
*   **Backend (ASP.NET Core Web API):** ❌ **INCOMPATIBLE.** Estas plataformas **NO** ejecutan código de servidor .NET (no soportan procesos en segundo plano ni bases de datos locales como SQLite).
*   **Veredicto:** Solo serviría si dividimos el proyecto en dos repositorios distintos: el Frontend en Vercel y la API en otra plataforma.

---

## 2. Render / Heroku / Railway (PaaS Modernos)
Plataformas como servicio (Platform as a Service) muy amigables y enfocadas a desarrolladores.

*   **Frontend y Backend juntos:** ✅ **COMPATIBLE (con Docker).** Render soporta nativamente ambientes como Node.js, Python o Ruby. Para correr C# .NET, la única forma es crear un **`Dockerfile`**.
*   **Contras para este MVP:**
    *   Requiere conocimientos de Dockerización (escribir un Dockerfile multi-stage para compilar y ejecutar .NET).
    *   La base de datos actual (SQLite) es un archivo local (`JustinaSimulator.db`). Plataformas como Render usan "Sistemas de Archivos Efímeros" (Ephemeral Filesystems). Esto significa que cada vez que el servidor se reinicia o se actualiza, el archivo de la base de datos se borra y se pierde todo el progreso de los usuarios.
*   **Veredicto:** No recomendado para el MVP a menos que se migre la base de datos a PostgreSQL (que Render ofrece de forma gratuita pero separada).

---

## 3. Microsoft Azure (Azure App Service / Azure Static Web Apps)
El ecosistema nativo de Microsoft (creador de C# y .NET).

*   **Compatibilidad:** ✅ **NATIVA (100%).** Es el entorno natural para .NET. Permite publicar toda la solución (Frontend, Backend y Base de Datos SQLite) en un solo servicio (Azure App Service).
*   **Puntos Negativos (Los que te mencionaron):**
    *   **Curva de aprendizaje:** La interfaz de Azure ("Azure Portal") es abrumadora, corporativa y compleja en comparación con Vercel.
    *   **Costos ocultos:** Aunque existe un "Free Tier" (F1), es fácil activar servicios por error (métricas, bases de datos SQL) que generan cargos a la tarjeta de crédito.
    *   **Rendimiento del Free Tier:** El plan gratuito apaga el servidor ("Cold Start") si nadie lo usa durante 20 minutos. El primer usuario que entre tardará unos 10-15 segundos en cargar la aplicación mientras el servidor "despierta".
*   **Veredicto:** Es la opción más lógica técnicamente, pero requiere precaución con la configuración de facturación y aceptar el "Cold Start".

---

## 4. GitHub Actions (CI/CD)
Como se ve en tu captura de pantalla, GitHub Actions no es un "lugar" donde se aloja el código, sino un **robot (pipeline)** que automatiza tareas.

*   **¿Para qué sirve?** En lugar de que tú compiles la API en tu máquina y subas los archivos manualmente arrastrándolos a un servidor, le das instrucciones a GitHub: *"Cada vez que haga un 'git push' a la rama 'main', compila mi código C# automáticamente y mándalo por red a Azure"*.
*   **Viabilidad para Justina:** Es completamente viable. De hecho, los "Workflows" sugeridos en tu imagen (`Deploy a .NET Core app to an Azure Web App`) hacen exactamente eso. Te autogeneran un archivo `.yml` que hace de puente entre tu repositorio y el servidor de Microsoft.

---

## Conclusión y Recomendación para el Viernes

Debido a la reducción del equipo y al tiempo limitado antes de la exposición del Viernes:

1.  **Prioridad 1 (Demostración Local):** La forma más segura y libre de estrés es grabar el video demostrativo y hacer la presentación ejecutando el proyecto en tu máquina local (`localhost`). Esto garantiza que no habrá latencia, *Cold Starts* ni problemas de red.
2.  **Prioridad 2 (Deploy Opcional si sobra tiempo):** Si desean el "Wow Factor" de pasarle un link web real a los evaluadores, la ruta más directa es **Microsoft Azure App Service** (usando el plan gratuito F1), conectado mediante GitHub Actions. Tendrán que tolerar la lentitud del *Cold Start* del plan gratis.
