using UnityEngine;
using Prototipe.Core.Interfaces;
public class HasKeyCondition : MonoBehaviour, ICondition
{
    public string keyID;
    public bool log = false;

    public bool IsMet()
    {
        if (log)
            Debug.LogWarning($"Condici�n: HasItem({keyID}) es {InventorySystem.Instance.HasItem(keyID)}");
        return InventorySystem.Instance.HasItem(keyID); // Suponiendo que ten�s un inventario
    }
}
