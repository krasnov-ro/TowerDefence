using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItemScr : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler 
{
    Tower selfTower;
    CellScr selfCell; 
    public Image TowerLogo;
    public Text TowerName, TowerPrice, TowerText;
    public Color BaseColor, CurrColor;

    public void SetStartData(Tower tower, CellScr cell)
    {
        selfTower = tower;
        TowerLogo.sprite = tower.Spr;
        TowerName.text = tower.Name;
        TowerText.text = tower.Text;
        TowerPrice.text = tower.Price.ToString();
        selfCell = cell;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {
        GetComponent<Image>().color = CurrColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = BaseColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(MoneyManagerScr.Instance.GameMoney >= selfTower.Price)
        {
            selfCell.BuildTower(selfTower);
            MoneyManagerScr.Instance.GameMoney -= selfTower.Price;
        }
    }
}
