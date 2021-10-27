using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{
    public GameObject Meteor;
    bool mSpawn;
    public float Cooldown;

    void Update()
    {
        if (!mSpawn)
        {
            Invoke("SpawnM", Cooldown);
            mSpawn = true;
        }
    }

    void SpawnM()
    {   
        Instantiate(Meteor, new Vector3(Random.Range(60.8f, 90.59f), 30, Random.Range(-70.81f, -84.3f)), Quaternion.identity);
        Invoke("RestartMeteor", 1);
    }

    void RestartMeteor()
    {
        mSpawn = false;
    }

}
