# Sistema modular

El sistema comprende una serie de clases e interfaces que trabajan entresí para detectar funcionalidad.

Las interfaces base del sistema son `IActivator` e `IAction`:

### IAction
```cs
namespace Prototipe.Core.Interfaces
{
        public interface IAction
    {
         void Execute();
    }
}
```

### IAction
```cs
namespace Prototipe.Core.Interfaces
{
    public interface IActivator
    {
        void Activate();
    }
}
```

Las clases que se especializan en las acciones, implementan la interfaz `IAction` para ser modulares y simplificar su interacción. Una acción base se construye de la siguiente manera:

```cs
using UnityEngine;
using Prototipe.Core.Interfaces;

namespace Prototipe.Core.Actions
{
  public class MoveAction : MonoBehaviour, IAction
  {
    public void Execute()
    {
      Trasform.position = Transform.postion = new Vector3(0,0,0);
    }
  }
}

```
La clase anterior representa una acción que desplaza el `GameObject` que la contenga al vector `(0,0,0)` al ejecutarse.

Hay que tener en cuenta que el proyecto utilizar diferentes namespaces para aislar los módulos internos:

### Prototipe.Core.Interfaces
Es el core que se dedica a la implementación de interfaces.
### Prototipe.Core.Actions
Es el core que se dedica a la implementación de acciones.
### Prototipe.Core.Activators
Es el core que se dedica a la implementación de activadores.

### EventReceiver

La clase EventReceiver se dedica a la recepción de eventos y 

```cs
public class EventReceiverByID : MonoBehaviour
{

    [DrawEventConnection("channel")]
    public EventChannelID channel;
    public MonoBehaviour[] actions;

    private List<IAction> _actions = new();
```
