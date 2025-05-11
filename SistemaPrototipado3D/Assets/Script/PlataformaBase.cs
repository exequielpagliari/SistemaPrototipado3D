using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlataformaBase : MonoBehaviour
{


    protected abstract Vector3 ObtenerAltura();

    void Update()
    {
        transform.position = ObtenerAltura();
    }
}
