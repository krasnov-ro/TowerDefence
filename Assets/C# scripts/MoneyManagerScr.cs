using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManagerScr : MonoBehaviour
{
    public static MoneyManagerScr Instance;
    public Text MoneyTxt;
    public int GameMoney;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoneyTxt.text = GameMoney.ToString();
    }
}
