using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenoController : MonoBehaviour
{
    public GameObject[] henos;
    int cantidadHeno;
    public Manager perdidaheno;

    void Start()
    {
        cantidadHeno = 10;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && cantidadHeno > 0)
        {
            cantidadHeno--;
            ComerHeno();
        }

        if (cantidadHeno == 0)
        {
            perdidaheno.final--;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cow") && cantidadHeno > 0)
        {
            cantidadHeno--;
            ComerHeno();
            Destroy(other.gameObject);
        }
    }

    void ComerHeno()
    {
        henos[cantidadHeno].SetActive(false);
    }
}
