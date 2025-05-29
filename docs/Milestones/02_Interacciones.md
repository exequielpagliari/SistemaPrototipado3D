﻿## Base del Sistema de Eventos

### Objetivo del milestone:

Diseñar e implementar un sistema de eventos globales modular, que permita a emisores y receptores comunicarse a través de canales identificados por un enum. Esto permitirá interacciones como botones que activan puertas, plataformas, mecanismos, etc.

| # | Tarea                                  | Descripción                                      | 
| - | -------------------------------------- | ------------------------------------------------ |
| 1 | Implementar `VolumenInteractable`                | Implementación de Botón de activación.                 | 
| 2 | Implementar `VolumenAutoInteractable`         | Implementación de Zona de activación.       | 
| 3 | Implementar `KillVolumen`            | Implementación de Zona de destrucción del Player y activación.       | 
| 4 | Implementar `RotateAction`                   | Acción de rotación | 
| 5 | Crear `MoveActionPlataformCorrutine` 		     | Creación de clase Plataforma, con funcionamiento por corrutina.         | 
| 6 | Crear `MoveActionCorrutine` 		     | Acción de desplazamiento por Corrutina      |
| 7 | Crear `ActionChainer` 		     | Acctivación de conjunto de Acciones en una sola interacción.         | 
| 8 | Crear `IActor` 		     | Implementación de interfaz IActor. | 
| 9 | Crear `ActorManager` 		     | Creación de clase que manipula Actores. | 
| 10 | Crear `MovementCC` 		     | Implementación de movimiento para CharacterController. | 
| 11 | Crear `RaycastGround` 		     | Implementación de Raycast para detección de Ground. | 
| 12 | Test rápido de flujo completo con nuevos comportamientos          | Emisor → Canal → Receptor → Acción               | 




## Clases principales

### Volumenes
Sistema de volúmenes que emiten un evento en un canal seleccionado según input interacción específica.

### VolumenInteractable.cs
Volumen que emite evento al presionar tecla acción dentro de su area de acción.
### VolumenAutoInteractable.cs
Volumen que emite evento al ingresar a su área de acción.
### KillVolumen.cs
Volumen que destruye al Player al ingresar a su área de acción y emite un evento..


### Acciones

### RotateAction.cs
Recive un evento y rota el objeto selecionado en el inpector.
### MoveActionPlataformCorrutine
Realiza un desplazamiento de plataforma entre dos puntos, marcados por un GameObject cada uno, utilizando una corrutina de por medio. Tiene relación con el Player, para generar un desplazamiento acorde controlador en el Transform del Player.
### MoveActionCorrutine
Realiza un desplazamiento entre dos puntos, marcados por un GameObject cada uno, utilizando una corrutina de por medio.

### Disparador de Acciones

### ActionChainer
Genera una secuencia en cadena. Puede ser por una corrutina o disparados simultáneamente.

### Interfaces

### IActor
Interfaz de Actores que afectarán o serán afectados por eventos.

### Manager

### ActorManager
Manager que controla a los objetos que pertenezcan a IActor.

### Control

### MovementCC
Clase dedicada a implementar movimiento del Character Controller, recibiendo información de InputManager.

### RaycastGround
Clase dedicada a detección de la layer `Ground` por medio de Raycast


## Posibles errores o dudas comunes
No se activa nada al presionar el botón: revisar si el `EventChannelID` coincide en emisor y receptor.

Receptor no escucha: asegurarse de haber hecho `Register()` en `Awake` y `Unregister()` en `OnDestroy`.

¿Y si quiero un canal con parámetros? Este milestone solo contempla eventos sin parámetros (Action). Para parámetros, hay que ampliar la arquitectura (Action<T>).


## Conclusión
Este milestone mejora las bases del sistema de interacción del mundo. La idea es que los elementos del entorno puedan escucharse y responder a eventos sin necesidad de conocer entre sí, manteniendo el código desacoplado y modular, ahora ampliando controladores y desencadenadores de eventos.