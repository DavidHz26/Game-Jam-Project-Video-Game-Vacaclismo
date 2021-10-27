using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    float Random_x, Random_y;
    bool destiny;
    public float speed;

    void Start()
    {
        Random_x = Random.Range(4.48f, 28.05f);
        Random_y = Random.Range(-71.35f, -82.37f);
    }

    // Update is called once per frame
    void Update()
    {
        RndMov();
    }

    void RndMov()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(Random_x, 18.294f, Random_y), speed * Time.deltaTime);
        float distancia = Vector3.Distance(new Vector3(Random_x, 18.294f,  Random_y), transform.position);

        if(distancia < 0.5f)
        {
            destiny = true;
        }

        if (destiny)
        {
            Random_x = Random.Range(4.48f, 28.05f);
            Random_y = Random.Range(-71.35f, -82.37f);
            destiny = false;
        }
    }
}
