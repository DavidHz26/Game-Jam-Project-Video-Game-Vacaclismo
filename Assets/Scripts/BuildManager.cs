using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Mas de un BuildManager en la escena!");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject francoTurretPrefab;
    public GameObject LaserTurretPrefab;
    public GameObject MissileTurretPrefab;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn (Node node)
    {
        if (PlayerStats.Leche < turretToBuild.cost)
        {
            Debug.Log("No tienes leche suficiente! Muuu...");
            return;
        }

        PlayerStats.Leche -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;


    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
