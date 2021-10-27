using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Vacas : MonoBehaviour
{
	public int vida = 100;
	public bool normal;
	public bool rapida;
	public bool tanque;
    public bool boss;
    public Material def;
    public Material def1;
    public Material def2;
    public Material def3;
    NavMeshAgent agent;
    Vector3 destination;

    //Navegación de la vaca (nivel de agua);
    public Transform target;
    public Transform[] charcos;
    public Transform[] puntosaSeguir;
    public bool seguirCharcos;
    public bool seguirPuntos;
    int fase = 0;
    int fasePuntos = 0;
    //--------------------------------------

    int direccion = 0;

    public float targetTime = 3.0f;
    public int leche = 0;

    int dmg;
    public GameObject bala;

    public float normalspeed = 10;
    public float rapidaspeed = 15;
    public float tanquespeed = 7.5f;
    public float bossspeed = 2.5f;
    public float nuevaspeed = 1.0f;
    public bool timer = false;
    public bool muerto = false;
    public int normalleche = 10;
    public int rapidaleche = 5;
    public int tanqueleche = 25;
    public int bossleche = 50;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = normalspeed;
       
        destination = agent.destination;
        AsignarVacas();
    }

    void AsignarVacas()
    {
        if (normal == true)
        {
            gameObject.transform.GetChild(0).GetComponent<Renderer>().material = def;
            vida = 100; 
            agent.speed = normalspeed;
            leche = 0;
            rapida = false;
            tanque = false;
            boss = false;

        }
        if (rapida == true)
        {
            gameObject.transform.GetChild(0).GetComponent<Renderer>().material = def1;
            vida = 50;
            agent.speed = rapidaspeed;
            leche = 0;
            normal = false;
            tanque = false;
            boss = false;
        }
        if (tanque == true)
        {
            gameObject.transform.GetChild(0).GetComponent<Renderer>().material = def2;
            vida = 150;
            agent.speed = tanquespeed;
            leche = 0;
            normal = false;
            rapida = false;
            boss = false;
        }
        if (boss == true)
        {
            gameObject.transform.GetChild(0).GetComponent<Renderer>().material = def3;
            vida = 250;
            agent.speed = bossspeed;
            leche = 0;
            normal = false;
            rapida = false;
            tanque = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(bala != null)
        {
            dmg = bala.GetComponent<Bullet>().dmg;
            Debug.Log(bala.GetComponent<Bullet>().dmg);
        }
         
        if(!seguirCharcos)
        {
            if (Vector3.Distance(destination, target.position) > 1.0f)
            {
                destination = target.position;
                agent.destination = destination;
            }
        }
        else
        {
            agent.destination = destination;

            switch (fase)
            {
                case 0:
                    destination = charcos[0].position;
                    if (Vector3.Distance(gameObject.transform.position, charcos[0].position) <= 1.0f)
                    {
                        direccion = Random.Range(0, 2);
                        destination = puntosaSeguir[direccion].position;
                        fase++;
                    }
                    break;
                case 1:
                    Debug.Log("Algo");
                    if (Vector3.Distance(gameObject.transform.position, puntosaSeguir[direccion].position) <= 1.0f)
                    {
                        Debug.Log("Alguien");
                        destination = charcos[1].position;
                        fase++;
                    }
                    break;
                case 2:
                    if (Vector3.Distance(gameObject.transform.position, charcos[1].position) <= 1.0f)
                    {
                        direccion = Random.Range(2, 4);
                        destination = puntosaSeguir[direccion].position;
                        fase++;
                    }
                    break;
                case 3:
                    if (Vector3.Distance(gameObject.transform.position, puntosaSeguir[direccion].position) <= 1.0f)
                    {
                        destination = charcos[2].position;
                        fase++;
                    }
                    break;
                case 4:
                    if (Vector3.Distance(gameObject.transform.position, charcos[2].position) <= 1.0f)
                    {
                        direccion = Random.Range(4, 6);
                        destination = puntosaSeguir[direccion].position;
                        fase++;
                    }
                    break;
                case 5:
                    if (Vector3.Distance(gameObject.transform.position, puntosaSeguir[direccion].position) <= 1.0f)
                    {
                        destination = charcos[3].position;
                        fase++;
                    }
                    break;
                case 6:
                    if (Vector3.Distance(gameObject.transform.position, charcos[3].position) <= 1.0f)
                    {
                        direccion = Random.Range(6, 8);
                        destination = puntosaSeguir[direccion].position;
                        fase++;
                    }
                    break;
                case 7:
                    if (Vector3.Distance(gameObject.transform.position, puntosaSeguir[direccion].position) <= 1.0f)
                    {
                        seguirCharcos = false;
                    }
                    break;
            }
        }        

        if(timer == true)
        {
            targetTime -= Time.deltaTime;
        }
        
        if(targetTime <= 0.0f && normal == true)
        {
            timer = false;
            agent.speed = normalspeed;
        }
        if(targetTime <= 0.0f && rapida == true)
        {
            timer = false;
            agent.speed = rapidaspeed;
        }
        if(targetTime <= 0.0f && tanque == true)
        {
            timer = false;
            agent.speed = tanquespeed;
        }
        if(targetTime <= 0.0f && boss == true)
        {
            timer = false;
            agent.speed = bossspeed;
        }     
    }

    public void DarLeche(int leche)
    {
        PlayerStats.Leche += leche;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
           
            if (normal == true)
            {
               
                vida -= dmg;
                if (vida <= 0)
                {
                    muerto = true;
                }
                if (muerto == true)
                {
                    Destroy(gameObject);
                }
            }
            if (rapida == true)
            {

                vida -= dmg;
                if (vida <= 0)
                {
                    muerto = true;
                }
                if (muerto == true)
                {
                    Destroy(gameObject);
                }
            }
            if (tanque == true)
            {

                vida -= dmg;
                if (vida <= 0)
                {
                    muerto = true;
                }
                if (muerto == true)
                {
                    Destroy(gameObject);
                }
            }


            if (other.transform.GetComponent<Bullet>().slow == true && normal == true)
            {
                timer = true;

                nuevaspeed = normalspeed / 2;
                agent.speed = nuevaspeed;  
                Debug.Log(dmg);
                vida -= dmg;
                // leche += normalleche;
                PlayerStats.Leche += normalleche;

                
                
                if(vida <= 0)
                {
                    muerto = true;
                }
                if(muerto == true)
                {
                    Destroy(gameObject);
                }
            }
            else if(other.transform.GetComponent<Bullet>().slow == true && rapida == true)
            {
                timer = true;
                nuevaspeed = rapidaspeed / 2;
                agent.speed = nuevaspeed;
               
                vida -= dmg;
                // leche += rapidaleche;

                PlayerStats.Leche += rapidaleche;

                


                if (vida <= 0)
                {
                    muerto = true;
                }
                if(muerto == true)
                {
                    Destroy(gameObject);
                }
            }
            else if(other.transform.GetComponent<Bullet>().slow == true && tanque == true)
            {
                timer = true;
                nuevaspeed = tanquespeed / 2;
                agent.speed = nuevaspeed;
                
                vida -= dmg;
                //leche += tanqueleche;
                PlayerStats.Leche += tanqueleche;

                

                if (vida <= 0)
                {
                    muerto = true;
                }
                if(muerto == true)
                {
                    Destroy(gameObject);
                }
            }
            else if(other.transform.GetComponent<Bullet>().slow == true && boss == true)
            {
                timer = true;
                nuevaspeed = bossspeed / 2;
                agent.speed = nuevaspeed;
                
                vida -= dmg;
                //leche += bossleche;
                PlayerStats.Leche += bossleche;
                if (vida <= 0)
                {
                    muerto = true;
                }
                if(muerto == true)
                {
                    Destroy(gameObject);
                }
            }
        }

        if (other.gameObject.CompareTag("Cloud"))
        {
            
            int rndEffect = Random.Range(1, 4);
         
            switch (rndEffect)
            {
                case 1:
                    normal = true;
                    rapida = false;
                    tanque = false;
                    boss = false;
                    break;
                case 2:
                    normal = false;
                    rapida = true;
                    tanque = false;
                    boss = false;
                    break;
                case 3:
                    normal = false;
                    rapida = false;
                    tanque = true;
                    boss = false;
                    break;
                case 4:
                    normal = false;
                    rapida = false;
                    tanque = false;
                    boss = true;
                    break;
            }

            AsignarVacas();
        }
    }
}
