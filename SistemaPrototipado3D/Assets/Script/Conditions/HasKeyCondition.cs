using UnityEngine;

public class HasKeyCondition : MonoBehaviour, ICondition
{
    public string keyID;
    public bool log = false;

    public bool IsMet()
    {
        if (log)
            Debug.LogWarning($"Condición: HasItem({keyID}) es {InventorySystem.Instance.HasItem(keyID)}");
        return InventorySystem.Instance.HasItem(keyID); // Suponiendo que tenés un inventario
    }
}
