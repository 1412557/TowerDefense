using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one build manager in scene!");
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject MissileLauncherPrefab;


    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStat.money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStat.money < turretToBuild.cost)
        {
            return;
        }
        PlayerStat.money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.getBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }

    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
