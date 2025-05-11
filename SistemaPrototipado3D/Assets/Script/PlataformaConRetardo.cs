using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaConRetardo : Plataforma
{
    [Range(0f, 10f)]
    public float tiempoDeRetardo;
    [SerializeField] float time;

    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
    }




 
    protected override Vector3 ObtenerAltura()
    {

        if (Time.time - time < tiempoDeRetardo)
        {
            return transform.position; // Retardo aún no ha terminado, no realizar movimiento
        }


        float nuevaDistancia = SeleccionEjeFloat(transform, eje) + velocidadDesplazamiento * Time.deltaTime * DetectarDireccion();

        nuevaDistancia = Mathf.Clamp(nuevaDistancia, minDistancia, maxDistancia);



        if (nuevaDistancia >= maxDistancia || nuevaDistancia <= minDistancia)
        {
            time = Time.time;
            InvertirDireccion();
        }

        return SeleccionEjeTransform(transform, eje, nuevaDistancia);
    }



}
