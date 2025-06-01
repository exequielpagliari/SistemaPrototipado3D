using UnityEngine;
using Prototipe.Core.Interfaces;

public class Key : MonoBehaviour , IInteractable
{
    /// <summary>
    /// String que se representará en la UI.
    /// </summary>
    public string keyString;
    public string GetInteractionPrompt() => keyString;
    


    public void Interact()
    {
        if (InventorySystem.Instance == null)
        {
            Debug.LogError("InventorySystem no inicializado.");
            return;
        }
        InventorySystem.Instance.AddItem(keyString);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.Interact();
        }
    }


}
