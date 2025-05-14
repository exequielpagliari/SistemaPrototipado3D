# 🧩 Sistema Modular de Prototipado Unity

Sistema modular de prototipado para juegos en tercera persona en Unity. Ideal para desarrollar escenas jugables rápidas con interacción entre elementos del entorno como puertas, puentes levadizos, botones y más.

---

## 🎯 Objetivo

Permitir el diseño y prueba rápida de sistemas interactivos para escenarios 3D, sin necesidad de lógica compleja ni animaciones.

✔️ Sistema de eventos modular  
✔️ Acciones desacopladas (mover, rotar, activar objetos)  
✔️ Interfaz limpia desde el inspector  
✔️ Compatible con Unity New Input System  
✔️ Pensado para integración con herramientas de diseño de niveles

---

## 🚀 Instalación

1. Cloná el repositorio o descargalo como `.zip`.
2. Importá la carpeta en tu proyecto de Unity (`2022+` recomendado).
3. Abrí la escena de ejemplo en `Scenes/Demo`.
4. Presioná Play y usá la tecla `E` para interactuar.

---

## 🧱 Estructura de módulos

| Módulo             | Descripción                                       |
|--------------------|---------------------------------------------------|
| `InputManager`     | Sistema desacoplado de input                      |
| `EventChannelManager` | Sistema de eventos basado en enums              |
| `IAction` / `MoveAction` | Acciones del entorno modularizadas         |
| `ActivatorButton`  | Interacción física con el jugador (botones, etc)  |
| `MoveAction`| Componente base para mover o activar objetos      |

---

## 🛠️ Ejemplo rápido

```csharp
public class OpenDoorAction : MonoBehaviour, IAction
{
    public void Execute()
    {
        transform.Translate(Vector3.up * 2f);
    }
}
```

- Agregá este script a una puerta.

- Asignalo como acción en un receptor (EventReceiverByID).

- Conectalo a un botón que use el mismo canal de evento.

¡Listo! Al presionar el botón, la puerta se mueve.

## 🧪 Estado actual
🟡 Proyecto en desarrollo.
🚧 API y componentes pueden cambiar.
🧠 Ideal para pruebas internas y herramientas de diseño rápido.
