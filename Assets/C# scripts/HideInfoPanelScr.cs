using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HideInfoPanelScr : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color BaseColor, CurrColor, CurrEffectColor, BaseEffectColor;
    public RectTransform InfoPanel;
    public Image InfoPanelImg;

    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().color = CurrColor;
        GetComponent<Outline>().effectColor = CurrColor;
        GetComponent<Shadow>().effectColor = CurrColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = BaseColor;
        GetComponent<Outline>().effectColor = BaseEffectColor;
        GetComponent<Shadow>().effectColor = BaseEffectColor;
        
    }
}
