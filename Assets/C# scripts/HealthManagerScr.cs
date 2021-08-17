using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class HealthManagerScr : MonoBehaviour
{
    public static HealthManagerScr Instance;
    public Text HealthTxt;
    public int Health;
    public RectTransform LooserPanel;

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
        if (Health <= 0)
        {
            GameOver();
        }
        else
        {
            HealthTxt.text = Health.ToString();
        }
    }

    public void GameOver()
    {
        HealthTxt.text = "0";
        LooserPanel.gameObject.SetActive(true);
        FindObjectOfType<EnemySpawnScr>().gameOver = true;
    }
}
