using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    //destruir planeta pasarse mas cercano
    //gaseoso ->volcanico,acuatico,normal
    //volcanico ->acuatcio,volcanico,normal
    //acuatico -> normal,volcanico,acuaitco
    //normal -> acuatico,volcanico , gaseoso

    //Alarmas
    public float timer;
    public GameObject vacas;
    public GameObject vacas2;
    public GameObject vacas3;
    public GameObject vacas4;
    public float spawn;
    public float nivel_timer;
    public Text texto;
    public int leche;
    public int oleadas;
    private float oleada_timer;
    public Sprite boss;
    public Sprite interrogacion_2d;
    public Sprite admiracion_2d;
    public int final;

    /*  public Image admiracion;
      public Image interrogacion;
      public Image calaca;*/

    public Vector3 pos;
    public Vector3 pos2;
    public Vector3 pos3;
    public Vector3 pos4;

    public Image[] iconos_array;

    public Vector3[] pos_array;
    public GameObject[] vacas_array;

    public GameObject vaca_seleccionada;
    public bool boss_aparecio;

    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(3.78f, 16.95f, -22.18f);
        pos2 = new Vector3(62.26f, 16.95f, -21.27f);
        pos3 = new Vector3(3.33f, 16.95f, -75.17f);
        pos4 = new Vector3(78.35f, 16.95f, -82.83f);

        pos_array[0] = pos;
        pos_array[1] = pos2;
        pos_array[2] = pos3;
        pos_array[3] = pos4;

        vacas_array[0] = vacas;
        vacas_array[1] = vacas2;
        vacas_array[2] = vacas3;
        vacas_array[3] = vacas4;
        //oledas = 1;
    }

    // Update is called once per frame
    void Update()
    {

        //if (input.getmousebuttondown(0))
        //{
        //    ray ray = camera.main.screenpointtoray(input.mouseposition);
        //    raycasthit hitinfo;
        //    if (physics.raycast(ray, out hitinfo))
        //    {
        //        if (hitinfo.collider.gameobject.tag == "normal")
        //        {
        //            normal_icono.enabled = false;
        //            debug.log("si");

        //        }
        //        if (hitinfo.collider.gameobject.tag == "acuatico")
        //        {
        //            acuatico_icono.enabled = false;

        //        }
        //        if (hitinfo.collider.gameobject.tag == "gaseoso")
        //        {
        //            gaseoso_icono.enabled = false;

        //        }
        //        if (hitinfo.collider.gameobject.tag == "volcanico")
        //        {
        //            volcanico_icono.enabled = false;

        //        }
        //    }
        //}


        if (final == 0)
        {
            SceneManager.LoadScene("d");

        }
        if (oleadas == 0 && nivel_timer >= 3)
        {
            SceneManager.LoadScene("v");
        }

        nivel_timer += Time.deltaTime;
        if (oleadas != 0)// && oleadas != 2 && oleadas != 4 && oleadas != 6)
        {

            if (nivel_timer >= 3.0f && nivel_timer <= 13.0f)
            {
                //3.-gaseoso,2.-acuatico,4.-volcanico,1.-normal

                iconos_array[0].enabled = true;
                iconos_array[0].sprite = interrogacion_2d;

                SpawnCows(timer, pos_array[0], vacas_array[0]);
                //vaca_seleccionada.GetComponent<Vacas>().tanque = true;

            }
            if (nivel_timer >= 13.0f && nivel_timer <= 23.0f)
            {
                iconos_array[1].enabled = true;
                iconos_array[1].sprite = interrogacion_2d;
                SpawnCows(timer, pos_array[1], vacas_array[1]);

            }
            if (nivel_timer >= 23.0f && nivel_timer <= 33.0f)
            {
                iconos_array[2].enabled = true;
                iconos_array[2].sprite = interrogacion_2d;
                SpawnCows(timer, pos_array[2], vacas_array[2]);

            }
            if (nivel_timer >= 33.0f && nivel_timer <= 43.0f)
            {
                iconos_array[3].enabled = true;
                iconos_array[3].sprite = interrogacion_2d;

                SpawnCows(timer, pos_array[3], vacas_array[3]);

            }
        }

        if (nivel_timer > 43)
        {
            OleadaRandom(pos_array);
            nivel_timer = 0;
            oleadas--;
            iconos_array[0].enabled = false;
            iconos_array[1].enabled = false;
            iconos_array[2].enabled = false;
            iconos_array[3].enabled = false;
        }

        //if (oleadas == 6)
        //{
        //    if (boss_aparecio == false)
        //    {
        //        normal_icono.enabled = true;
        //        normal_icono.sprite = boss;
        //        vaca_seleccionada = Instantiate(vacas, pos, Quaternion.identity);
        //        vaca_seleccionada.GetComponent<Vacas>().normal = false;
        //        vaca_seleccionada.GetComponent<Vacas>().boss = true;
        //        boss_aparecio = true;
        //    }


        //    if (oleadas == 5)
        //    {
        //        boss_aparecio = false;
        //    }

        //}
        //if (oleadas == 4)
        //{
        //    if (boss_aparecio == false)
        //    {
        //        acuatico_icono.enabled = true;
        //        acuatico_icono.sprite = boss;


        //        vaca_seleccionada = Instantiate(vacas2, pos2, Quaternion.identity);
        //        vaca_seleccionada.GetComponent<Vacas>().normal = false;
        //        vaca_seleccionada.GetComponent<Vacas>().boss = true;
        //        boss_aparecio = true;
        //    }


        //}


        //if (oleadas == 3)
        //{
        //    boss_aparecio = false;
        //}


        //if (oleadas == 2)
        //{
        //    if (boss_aparecio == false)
        //    {
        //        gaseoso_icono.enabled = true;
        //        gaseoso_icono.sprite = boss;
        //        vaca_seleccionada = Instantiate(vacas3, pos3, Quaternion.identity);
        //        vaca_seleccionada.GetComponent<Vacas>().normal = false;
        //        vaca_seleccionada.GetComponent<Vacas>().boss = true;
        //        boss_aparecio = true;
        //    }
        //}


        //if (oleadas == 1)
        //{
        //    boss_aparecio = false;
        //}

        //if (oleadas == 0)
        //{
        //    if (boss_aparecio == false)
        //    {
        //        volcanico_icono.enabled = true;
        //        volcanico_icono.sprite = boss;
        //        vaca_seleccionada = Instantiate(vacas4, pos4, Quaternion.identity);
        //        vaca_seleccionada.GetComponent<Vacas>().normal = false;
        //        vaca_seleccionada.GetComponent<Vacas>().boss = true;
        //        boss_aparecio = true;
        //    }
        //}
    }

    void OleadaRandom(Vector3[] pos_arreglo)
    {

        for (int i = 0; i < 4; i++)
        {

            var x = 3;
            var r = Random.Range(0, 3);

            var tmp = pos_arreglo[i];
            pos_arreglo[i] = pos_arreglo[r];
            pos_arreglo[r] = tmp;

            var tmp2 = vacas_array[i];
            vacas_array[i] = vacas_array[r];
            vacas_array[r] = tmp2;

            var tmp3 = iconos_array[i];
            iconos_array[i] = iconos_array[r];
            iconos_array[r] = tmp3;

            x--;
        }
    }

    void SpawnCows(float timer, Vector3 position, GameObject vaca)
    {
        //float spawn;
        int porcentaje;
        //spawn += Time.deltaTime;
        if (timer <= spawn)
        {
            porcentaje = Random.Range(1, 101);

            if (porcentaje <= 50)
            {
                vaca_seleccionada = Instantiate(vaca, position, Quaternion.identity);
                vaca_seleccionada.GetComponent<Vacas>().normal = true;
                //Debug.Log(vaca_seleccionada.name + " es del tipo " + vaca_seleccionada.GetComponent<Vacas>().normal);
            }
            if (porcentaje > 50 && porcentaje <= 75)
            {
                vaca_seleccionada = Instantiate(vaca, position, Quaternion.identity);
                // vaca_seleccionada.GetComponent<Vacas>().normal = false;
                vaca_seleccionada.GetComponent<Vacas>().tanque = true;
                //Debug.Log(vaca_seleccionada.name + " es del tipo " + vaca_seleccionada.GetComponent<Vacas>().tanque);

            }
            if (porcentaje > 75)
            {
                vaca_seleccionada = Instantiate(vaca, position, Quaternion.identity);
                //vaca_seleccionada.GetComponent<Vacas>().normal = false;
                vaca_seleccionada.GetComponent<Vacas>().rapida = true;
                //Debug.Log(vaca_seleccionada.name + " es del tipo " + vaca_seleccionada.GetComponent<Vacas>().rapida);

            }

            spawn = 0;
        }
        else
        {
            spawn += Time.deltaTime;
        }

    }
}
