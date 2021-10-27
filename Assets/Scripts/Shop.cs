using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint francoTurret;
    public TurretBlueprint laserTurret;
    public TurretBlueprint missileTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret ()
    {
        //Debug.Log("Torreta Standard seleccionada");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectFrancoTurret()
    {
        //Debug.Log("Torreta de Francotirador seleccionada");
        buildManager.SelectTurretToBuild(francoTurret);
    }

    public void SelectLaserTurret()
    {
        //Debug.Log("Torreta Realentizadora seleccionada");
        buildManager.SelectTurretToBuild(laserTurret);
    }

    public void SelectMissileTurret()
    {
        //Debug.Log("Torreta Cañón seleccionada");
        buildManager.SelectTurretToBuild(missileTurret);
    }
}
