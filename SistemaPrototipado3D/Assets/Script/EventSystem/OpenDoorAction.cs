using UnityEngine;

public class OpenDoorAction : EnvironmentAction
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private string triggerName = "Open";
    [SerializeField] private string debugString = "Debug_Open";

    public override void Execute()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger(triggerName);
        }
        Debug.Log(debugString);

    }
}
