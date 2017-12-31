using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeam;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
	public void PurchaseStandardTurret()
    {
        buildManager.SetTurretToBuild(standardTurret);
    }

    public void PurchaseMissileLauncher()
    {
        buildManager.SetTurretToBuild(missileLauncher);
    }

    public void PurchaseLaserBeam()
    {
        buildManager.SetTurretToBuild(laserBeam);
    }
}
