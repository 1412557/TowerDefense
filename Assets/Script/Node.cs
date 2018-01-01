using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 getBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.getTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStat.money < blueprint.cost)
        {
            return;
        }
        PlayerStat.money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, getBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;
        GameObject effect = (GameObject)Instantiate(buildManager.BuildEffect, getBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }

    public void UpgradeTurret()
    {
        if (PlayerStat.money < turretBlueprint.upgradeCost)
        {
            return;
        }
        PlayerStat.money -= turretBlueprint.upgradeCost;

        Destroy(turret);//pha turret cu
        //build moi
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, getBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.BuildEffect, getBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStat.money += turretBlueprint.getSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, getBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(turret);
        turretBlueprint = null;
    }

	void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
