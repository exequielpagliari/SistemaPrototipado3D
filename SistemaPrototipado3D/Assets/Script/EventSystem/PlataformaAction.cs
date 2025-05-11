using UnityEngine;

public class PlataformaAction : EnvironmentAction
{
    [SerializeField] private Plataforma plataformaActivada;

    [SerializeField] private string debugString = "PlataformaActivada1";

    public override void Execute()
    {

        plataformaActivada.Activate();
        Debug.Log(debugString);

    }
}
