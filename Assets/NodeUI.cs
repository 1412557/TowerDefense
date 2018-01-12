using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

    public GameObject UI;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;
    private Node target;

    public void setTarget(Node _target)
    {
        this.target = _target;

        transform.position = target.getBuildPosition();
        if (!target.isUpgraded)
        {
            upgradeCost.text = "-" + target.turretBlueprint.upgradeCost.ToString();
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "MAXED";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "+" + target.turretBlueprint.getSellAmount().ToString();
        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectedNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectedNode();
    }
}
