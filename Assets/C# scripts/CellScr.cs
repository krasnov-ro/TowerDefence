using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellScr : MonoBehaviour
{
    public bool isGround, hasTower = false;
    public Color BaseColor, CurrColor, DestroyColor;
    public GameObject ShopPref, TowerPref;

    public void OnMouseEnter()
    {
        if (!isGround && FindObjectsOfType<ShopScr>().Length == 0)
        {
            GetComponent<SpriteRenderer>().color = CurrColor;
        }
    }

    public void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = BaseColor;
    }

    public void OnMouseDown()
    {
        if (!isGround && FindObjectsOfType<ShopScr>().Length == 0)
        {
            if (!hasTower)
            {
                GameObject shopObj = Instantiate(ShopPref);
                shopObj.transform.SetParent(GameObject.Find("Canvas").transform, false);
                shopObj.GetComponent<ShopScr>().selfCell = this;
            }
        }
    }

    public void BuildTower(Tower tower)
    {
        tower.CurrCooldown = .3f;
        GameObject tmpTower = Instantiate(TowerPref);
        tmpTower.transform.SetParent(transform, false);
        Vector2 towerPos = new Vector2(transform.position.x + tmpTower.GetComponent<SpriteRenderer>().bounds.size.x / 2,
                                       transform.position.y - tmpTower.GetComponent<SpriteRenderer>().bounds.size.y / 2);
        tmpTower.transform.position = transform.position;
        tmpTower.GetComponent<TowerScr>().selfType = (TowerType)tower.type;
        Debug.Log(tower.Cooldown + tower.Name + tower.CurrCooldown);
        hasTower = true;
        FindObjectOfType<ShopScr>().CloseShop();
    }

    public void Start()
    {

    }

    private void Update()
    {

    }
}
