using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScr : MonoBehaviour
{
    public GameObject ItemPref;
    public Transform ItemGridLayoutGroup;

    GameCtrlScr gcs;

    public CellScr selfCell;

    // Start is called before the first frame update
    void Start()
    {
        gcs = FindObjectOfType<GameCtrlScr>();

        foreach(Tower tower in gcs.AllTowers)
        {
            GameObject tmpItme = Instantiate(ItemPref);
            tmpItme.transform.SetParent(ItemGridLayoutGroup, false);
            tmpItme.GetComponent<ShopItemScr>().SetStartData(tower, selfCell);
        }
    }

    public void CloseShop()
    {
        Destroy(gameObject); 
    }
    // Update is called once pe r frame
    void Update()
    {
        
    }
}
