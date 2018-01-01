using System;
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
    public GameObject BuildEffect;
    public GameObject sellEffect;
    public NodeUI nodeUI;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStat.money >= turretToBuild.cost; } }


    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectedNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.setTarget(node);
    }

    public void DeselectedNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectedNode();
    }

    public TurretBlueprint getTurretToBuild()
    {
        return turretToBuild;
    }
}
