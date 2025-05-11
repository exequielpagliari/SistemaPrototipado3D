using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class Plataforma : PlataformaBase
{
    [Range(0f, 10f)]
    public float velocidadDesplazamiento;
    protected bool subiendo = true;
    bool activate = false;

    [SerializeField] protected int eje;

    private int direction;
    [SerializeField] protected float maxDistancia;
    [SerializeField] protected float minDistancia;




    // Update is called once per frame
    void Update()
    {
        

        if(activate)
        transform.position = ObtenerAltura();



    }

    protected int DetectarDireccion()
    {
        if (subiendo)
            direction = 1;
        else
            direction = -1;

        return direction;
    }

    protected bool InvertirDireccion()
    { 
        return subiendo = !subiendo;
    }

    protected override Vector3 ObtenerAltura()
    {
        float nuevaDistancia = SeleccionEjeFloat(transform, eje) + velocidadDesplazamiento * Time.deltaTime * DetectarDireccion();

        nuevaDistancia = Mathf.Clamp(nuevaDistancia, minDistancia, maxDistancia);

        

        if (nuevaDistancia >= maxDistancia || nuevaDistancia <= minDistancia)
        {
            InvertirDireccion();
        }

        return SeleccionEjeTransform(transform, eje, nuevaDistancia);
    }


    protected float SeleccionEjeFloat(Transform transform, int Eje)
    {
        switch (Eje)
        {
            case 0:
                return transform.position.x;
            case 1:
                return transform.position.y;
            case 2:
                return transform.position.z;
            default:
                Debug.LogError("NO HAY SELECCIONADO UN EJE");
                return 0; 
        }
    }

    protected Vector3 SeleccionEjeTransform(Transform transform, int eje, float nuevaDistancia)
    {
        switch (eje)
        {
            case 0:
                return new Vector3(nuevaDistancia, transform.position.y, transform.position.z);
            case 1:
                return new Vector3(transform.position.x, nuevaDistancia, transform.position.z); 
            case 2:
                return new Vector3(transform.position.x, transform.position.y, nuevaDistancia); 
            default:
                Debug.LogError("NO HAY SELECCIONADO UN EJE");
                return Vector3.zero;
        }
    }

    public void Activate()
    {
        activate = true;
    }
}
