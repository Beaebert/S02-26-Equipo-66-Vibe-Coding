# Trabajo de los diseñadores UX/UI
## El objetivo es crear una interfaz de usuario para el simulador de cirugía renal mínimamente invasiva.

## Diseñadores: 
* **Cristian Dal Piva** [Cristian Dal Piva](https://github.com/cristiandalpiva)
* **Lara Almiron** [Lara Almiron](https://github.com/laraalmiron)

### Descripción del proceso de diseño:
* Los diseñadores se reunieron activamente durante los Sprints con el Analista Programador, Desarrolladores Vibe Coding y No Code para comprender los objetivos de los requerimientos y las posibilidades técnicas. 
* Se realizaron varias sesiones de BrainStorming e investigación asincronica sobre productos actuales en el mercado en conjunto los diseñadores con el Analista Programador.
* Se genero un listado de ideas de concepto y posibles herramientas a utilizarse en la interfaz por parte del usuario.
* Se determino que la presentación de boceto y prototipo se realice con la herramienta Figma.

### Descripción del prototipo:
* El prototipo se encuentra disponible en el siguiente enlace: [Aplicación Web de Simulacion Quirurgica](https://www.figma.com/make/lKleIf92KXBYNbQTkHredJ/Simulaci%C3%B3n-de-operaciones?p=f&t=AjS6jWzcaddYVWEx-0)
* El MVP inicia en la Pantalla Index. En Esta se visualiza un Dashboard del rendimiento del usuario (Actor Cirujano, en entrenamiento), de acuerdo a las simulaciones que ha realizado anteriormente.
* El Usuario tiene posibilidad de ingresar a su perfil, visualizar sus propios datos y modificarlos (como podria ser su foto, email, etc).
* En la Pantalla Index tiene un claro boton de "Iniciar Simulación". Como las operaciones renales, aunque sean minimamente invasivas, tienen sus diferentes metodos dependiendo de la patologia a la que se va a abordar (extripar un tumor, tomar una pequeña muestra de tejido, una incisión para retirar calculos, suturar heridas, realizar los puntos superficiales de la piel del paciente), se lo va a llevar a otra pantalla donde se le presentaran las diferentes opciones de patologias a simular.
* Así, en la Pantalla de Selección de Simulador, el usuario puede elegir qué procedimiento simular.
* En la Pantalla de Simulador el usuario tendra un cronometro de tiempo y la descripción de los pasos a realizar. En el centro será el área dónde el usuario maniobrará el control del robot. Cuando se encuentre listo para comenzar el usuario, le dara click al boton "iniciar simulación". En ese entonces el recuadro central pasara a verse como el área a tratar con limites claros a controlar (no salirse del espacio del riñón o sus alrededores que puedan provocar un daño critico para el paciente). 
* Pueden ver en la imagen de esta carpeta llamada "Inicio de Simulación" el recuadro conceptual del área representada abstractamente. Cuando avance el desarrollo del MVP, se irá puliendo esta representación abstracta a una representación más realista de un riñón y sus alrededores. Al momento de presentar este proyecto de MVP, el equipo se esta enfocando principalmente en el requerimiento de entrenamiento de concentración y pulso del usuario (teniendo en cuenta que en el futuro, también el usuario se estará acostumbrando a un mando especifico, cuándo se encuentre ya desarrollado para pruebas esa parte de hardware).
* La pantalla de Finalización de Simulación muestra las estadisticas obtenidas por el usuario en su sesión de simulación. Cuánto tiempo demoro, cuántas veces uso la pinza, cuántas veces se salió del área de trabajo, etc. 

### Aclaraciones a tener en cuenta:
* Al no trabajar con un hardware especifico al momento de este MVP, se esta utilizando como hardware de mando del usuario un mouse. Por lo que la interfaz está pensada para ser utilizada con mouse. En un futuro, se espera poder utilizar un mando especifico para el control del robot. 
* La interfaz está pensada para ser utilizada en una pantalla de 1920x1080. En un futuro, se espera poder utilizar la interfaz en una pantalla de 4K.
* La simulación del MVP es puramente un software de entrenamiento de agilidad, pulso y concentración. Se espera que en el futuro del desarrollo, el software crezca y se conecte a hardware necesario para una simulación más realista y completa (como el hardware de control del robot).
* La interfaz del MVP tiene representaciones abstractas de las áreas a trabajar. En un futuro, se espera poder utilizar representaciones más realistas de las áreas a trabajar.