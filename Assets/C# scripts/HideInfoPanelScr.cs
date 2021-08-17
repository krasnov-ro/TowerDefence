using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideInfoPanelScr : MonoBehaviour
{
    public Color BaseColor, CurrColor;
    public RectTransform InfoPanel;
    public Image InfoPanelImg;

    // Start is called before the first frame update
    public void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = CurrColor;
    }

    public void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = BaseColor;
    }
}
