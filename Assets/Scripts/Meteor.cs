using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject FireParticle;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("MapVolcanico")){
            Instantiate(FireParticle, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("Cow"))
        {
            Instantiate(FireParticle, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Turret"))
        {
            Instantiate(FireParticle, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
}
