using UnityEngine;

public class ActivationManager : MonoBehaviour ,IActivatorReceiver
{
    private IActivator currentActivator;
    public GameObject UI;

    public void RegisterActivator(IActivator activator)
    {
        currentActivator = activator;
        UI.SetActive(true);

    }

    public void UnregisterActivator(IActivator activator)
    {
        if (currentActivator == activator)
        {    
            currentActivator = null;
            UI.SetActive(false);
        }
    }

    private void Update()
    {

            if (InputManager.Instance.InteractPressed)
            {
              currentActivator?.Activate();
            }
            /*
            if (InputManager.Instance.MoveInput.sqrMagnitude > 0)
            {
              currentActivator?.Activate();
            }
            */
        
    }
}
