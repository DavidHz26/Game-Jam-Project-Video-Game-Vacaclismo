using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectPlnt : MonoBehaviour
{
    bool enJuego;

    bool Gaseoso;
    bool Acuatico;
    bool Volcanico;
    bool Normal;
    bool Default;

    Vector3 Default_Pos;
    float Default_fieldView;
    Camera Default_Camera;

    public GameObject CanvasP1;
    public GameObject CanvasP2;
    public GameObject CanvasP3;
    public GameObject CanvasP4;

    public Camera CameraP1;
    public Camera CameraP2;
    public Camera CameraP3;
    public Camera CameraP4;

    public RenderTexture RTCamP1;
    public RenderTexture RTCamP2;
    public RenderTexture RTCamP3;
    public RenderTexture RTCamP4;

    public GameObject Torrets;

    GameObject PlnGaseoso;
    GameObject PlnAcuatico;
    GameObject PlnNormal;
    GameObject PlnVolcanico;

    void Start()
    {
        Default_Pos = Camera.main.transform.position;
        Default_fieldView = Camera.main.fieldOfView;
        Default_Camera = Camera.main;

        PlnGaseoso = GameObject.FindGameObjectWithTag("Gaseoso");
        PlnAcuatico = GameObject.FindGameObjectWithTag("Acuatico");
        PlnNormal = GameObject.FindGameObjectWithTag("Normal");
        PlnVolcanico = GameObject.FindGameObjectWithTag("Volcanico");
    }

    void Update()
    {
        SelPlaneta();

        if (Gaseoso && !enJuego) {
            c_fieldView(29, 1, false);
            //changePos(new Vector3(-23.45f, 3.11f, -4.59f));
            changePos(new Vector3(PlnGaseoso.transform.position.x, PlnGaseoso.transform.position.y, -4.59f));
        }

        if(Acuatico && !enJuego)
        {
            c_fieldView(45, 1, false);
            //changePos(new Vector3(-15.38f, 1.43f, -4.59f));
            changePos(new Vector3(PlnAcuatico.transform.position.x, PlnAcuatico.transform.position.y, -4.59f));
        }

        if (Volcanico && !enJuego)
        {
            c_fieldView(24.2f, 1, false);
            //changePos(new Vector3(-3.9f, -2.49f, -4.59f));
            changePos(new Vector3(PlnVolcanico.transform.position.x, PlnVolcanico.transform.position.y, -4.59f));
        }

        if (Normal && !enJuego)
        {
            c_fieldView(19, 1, false);
            //changePos(new Vector3(6.71f, -1.53f, -4.59f));
            changePos(new Vector3(PlnNormal.transform.position.x, PlnNormal.transform.position.y, -4.59f));
        }

        if (Default)
        {
            c_fieldView(Default_fieldView, 1, true);
            changePos(Default_Pos);

            Acuatico = false;
            Gaseoso = false;
            Normal = false;
            Volcanico = false;

            CanvasP1.SetActive(true);
            CanvasP2.SetActive(true);
            CanvasP3.SetActive(true);
            CanvasP4.SetActive(true);

            ResetCameras();
        }

        if (enJuego)
        {
            Torrets.SetActive(true);
        } else
        {
            Torrets.SetActive(false);
        }
    }

    void SelPlaneta()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && Input.GetKeyDown(KeyCode.Mouse0) && !enJuego)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                Debug.DrawLine(ray.origin, hit.point);

                if (hit.collider.CompareTag("Gaseoso"))
                {
                    //Debug.Log("Planeta Gaseoso");
                    CanvasP1.SetActive(false);
                    Gaseoso = true;
                    Default = false;
                    Invoke("ChoosePlanet", 1.5f);
                
                }

                if (hit.collider.CompareTag("Acuatico"))
                {
                    //Debug.Log("Planeta Acuatico");
                    CanvasP1.SetActive(false);
                    CanvasP2.SetActive(false);
                    Acuatico = true;
                    Default = false;
                    Invoke("ChoosePlanet", 1.5f);
                }

                if (hit.collider.CompareTag("Normal"))
                {
                    //Debug.Log("Planeta Normal");
                    CanvasP4.SetActive(false);
                    Normal = true;
                    Default = false;
                    Invoke("ChoosePlanet", 1.5f);
                }

                if (hit.collider.CompareTag("Volcanico"))
                {
                    //Debug.Log("Planeta Volcanico");
                    CanvasP3.SetActive(false);
                    Volcanico = true;
                    Default = false;
                    Invoke("ChoosePlanet", 1.5f);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Default = true;
        }
    }

    void c_fieldView(float chgSize, int value, bool MM)
    {
        if (Camera.main != null)
        {
            if (!MM && Camera.main.enabled)
            {
                if (Camera.main.fieldOfView > chgSize)
                {
                    Camera.main.fieldOfView -= value;
                }
            }

            if (MM && Camera.main.enabled)
            {
                if (Camera.main.fieldOfView < chgSize)
                {
                    Camera.main.fieldOfView += value;
                }
            }
        }
    }

    void changePos(Vector3 newPosition)
    {
        if(Camera.main != null)
            Camera.main.transform.position = new Vector3(newPosition.x, newPosition.y, newPosition.z);
    }

    void ChoosePlanet()
    {
        enJuego = true;

        if (Gaseoso) {
            CameraP1.targetTexture = null;

            Default_Camera.gameObject.SetActive(false);
            CameraP2.gameObject.SetActive(false);
            CameraP3.gameObject.SetActive(false);
            CameraP4.gameObject.SetActive(false);
        }

        if(Acuatico)
        {
            CameraP2.targetTexture = null;

            Default_Camera.gameObject.SetActive(false);
            CameraP1.gameObject.SetActive(false);
            CameraP3.gameObject.SetActive(false);
            CameraP4.gameObject.SetActive(false);
        }

        if (Volcanico)
        {
            CameraP3.targetTexture = null;

            Default_Camera.gameObject.SetActive(false);
            CameraP1.gameObject.SetActive(false);
            CameraP2.gameObject.SetActive(false);
            CameraP4.gameObject.SetActive(false);
        }

        if (Normal)
        {
            CameraP4.targetTexture = null;

            Default_Camera.gameObject.SetActive(false);
            CameraP1.gameObject.SetActive(false);
            CameraP2.gameObject.SetActive(false);
            CameraP3.gameObject.SetActive(false);
        }
    }

    void ResetCameras()
    {
        enJuego = false;

        CameraP1.targetTexture = RTCamP1;
        CameraP2.targetTexture = RTCamP2;
        CameraP3.targetTexture = RTCamP3;
        CameraP4.targetTexture = RTCamP4;

        Default_Camera.gameObject.SetActive(true);
        CameraP1.gameObject.SetActive(true);
        CameraP2.gameObject.SetActive(true);
        CameraP3.gameObject.SetActive(true);
        CameraP4.gameObject.SetActive(true);

    }
}
