using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpgradeScr : MonoBehaviour
{
    public GameObject UpgradeItemPref;
    public Image ItemImg;
    public Text ItemText;
   

    GameCtrlScr gcs;
    public CellScr selfCell;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpgradeTower()
    {
        var currentTowerPref = selfCell.transform.GetChild(0);
        //GameObject tmpTower = Instantiate(TowerPref);
        //tmpTower.transform.SetParent(transform, false);
        //Vector2 towerPos = new Vector2(transform.position.x + tmpTower.GetComponent<SpriteRenderer>().bounds.size.x / 2,
        //                               transform.position.y - tmpTower.GetComponent<SpriteRenderer>().bounds.size.y / 2);
        //tmpTower.transform.position = transform.position;
        //tmpTower.GetComponent<TowerScr>().selfType = (TowerType)tower.type;
        ////Debug.Log(tower.Cooldown + tower.Name + tower.CurrCooldown);
        //hasTower = true;
        //FindObjectOfType<ShopScr>().CloseShop();
    }

    public void CloseUpgradeMenu()
    {
        Destroy(gameObject);
    }
}
