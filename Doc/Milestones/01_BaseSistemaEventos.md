## Base del Sistema de Eventos

### Objetivo del milestone:

Diseñar e implementar un sistema de eventos globales modular, que permita a emisores y receptores comunicarse a través de canales identificados por un enum. Esto permitirá interacciones como botones que activan puertas, plataformas, mecanismos, etc.

| # | Tarea                                  | Descripción                                      | 
| - | -------------------------------------- | ------------------------------------------------ |
| 1 | Crear `EventChannelID`                 | Enum con los canales disponibles                 | 
| 2 | Crear `EventChannelManager`            | Sistema de suscripción y emisión por canal       | 
| 3 | Crear `IActivator`                     | Interfaz para elementos que puedan ser activados | 
| 4 | Crear `MoveAction` 		     | Ejemplo de acción de entorno desacoplada         | 
| 5 | Test rápido de flujo completo          | Emisor → Canal → Receptor → Acción               | 


## Diagrama de flujo

```
[Player Input]
     |
     v
[ActivatorButton] --(RaiseEvent)--> [EventChannelManager] --(Invoke)--> [Receptor: Puente]
                                                                         |
                                                                 [IActivator.Activate()]
                                                                         |
                                                             [EnviromentAction.Move()]
```

## Clases principales

### EventChannelID.cs
```
public enum EventChannelID
{
    Canal_1,
    Canal_2,
    Canal_3,
    // Otros canales
}
```

### EventChannelManager.cs
Sistema estático que permite registrar, desregistrar y emitir eventos asociados a un canal.

- Métodos:

- - Register(channel, Action)

- - Unregister(channel, Action)

- - RaiseEvent(channel)


### IActivator.cs
```
public interface IActivator
{
    void Activate();
}
```
Se usa para cualquier objeto que reacciona a un evento: puertas, plataformas, luces, trampas, etc.

## MoveAction.cs

```
public class MoveAction : MonoBehaviour, IAction
{
    [SerializeField] private Vector3 offset;

    public void Execute()
    {
        transform.position += offset;
    }
}
```


## Posibles errores o dudas comunes
No se activa nada al presionar el botón: revisar si el EventChannelID coincide en emisor y receptor.

Receptor no escucha: asegurarse de haber hecho Register() en Awake y Unregister() en OnDestroy.

¿Y si quiero un canal con parámetros? Este milestone solo contempla eventos sin parámetros (Action). Para parámetros, hay que ampliar la arquitectura (Action<T>).

## Futuras mejoras
Agregar EventChannel<T> para pasar datos (como posición, valores, etc.).

Soporte visual en editor (inspector custom).

Logging y debug visual de eventos disparados.

## Conclusión
Este milestone sienta las bases del sistema de interacción del mundo. La idea es que los elementos del entorno puedan escucharse y responder a eventos sin necesidad de conocer entre sí, manteniendo el código desacoplado y modular.
