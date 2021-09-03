using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlManagerScr : MonoBehaviour
{
    public int fieldWidth, fieldHeight;
    public GameObject cellPref;
    public Transform cellParent;
    public Sprite[] tileSpr = new Sprite[2];
    public List<GameObject> wayPoints = new List<GameObject>();
    GameObject[,] allCells = new GameObject[13, 24];
    //List<List<GameObject>> allCells = new List<List<GameObject>>();
    int currWayX, currWayY;
    GameObject firstCell;
    GameObject firstNoGroundCell;
    public GameObject towerPref;

    // Start is called before the first frame update
    void Start() 
    {
        CreateLvl();
        LoadWaypoints();
    }
        
    void CreateLvl()
    {
        Vector3 worldVec = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));

        for (int i = 0; i < fieldHeight; i++)
            for (int k = 0; k < fieldWidth; k++)
            {
                int sprIndex = int.Parse(LoadLvlText(1)[i].ToCharArray()[k].ToString());
                Sprite spr = tileSpr[sprIndex];

                bool isGround = spr == tileSpr[1] ? true : false;
                CreateCell(isGround, spr, k, i, worldVec);
            }
    }
    
    void CreateCell(bool isGround, Sprite spr, int x, int y, Vector3 wV)
    {
        var uitransform = spr.rect;

        GameObject tmpCell = Instantiate(cellPref);
        tmpCell.transform.SetParent(cellParent, false);

        tmpCell.GetComponent<SpriteRenderer>().sprite = spr;

        float sprSizeX = tmpCell.GetComponent<SpriteRenderer>().bounds.size.x;
        float sprSizeY = tmpCell.GetComponent<SpriteRenderer>().bounds.size.y;

        tmpCell.transform.position = new Vector3(wV.x + (sprSizeX * x), wV.y + (sprSizeY * -y));
        if(firstNoGroundCell == null && !isGround)
        {
            firstNoGroundCell = tmpCell;
        }

        if(isGround)
        {
            tmpCell.GetComponent<CellScr>().isGround = true;
            if(firstCell == null && tmpCell.transform.position.x == firstNoGroundCell.transform.position.x)
            {
                firstCell = tmpCell;
                currWayX = x;
                currWayY = y;
            }
        }

        allCells[y, x] = tmpCell;
    }

    string[] LoadLvlText(int i)
    {
        TextAsset tmpTxt = Resources.Load<TextAsset>($"Lvl{i}Ground");
        string tmpSpr = tmpTxt.text.Replace(Environment.NewLine, string.Empty);
        string[] returnSpr = tmpSpr.Split('!');

        return returnSpr;
    }

    void LoadWaypoints()
    {
        GameObject currWayGo;

        wayPoints.Add(firstCell);

        while(true)
        {
            currWayGo = null;

            if (currWayX > 0 && allCells[currWayY, currWayX - 1].GetComponent<CellScr>().isGround &&
                !wayPoints.Exists(x => x == allCells[currWayY, currWayX - 1]))
            {
                currWayGo = allCells[currWayY, currWayX - 1];
                currWayX--;
                Debug.Log("Next Cell is Left");
            }
            else if (currWayX < (fieldWidth - 1) && allCells[currWayY, currWayX + 1].GetComponent<CellScr>().isGround &&
                !wayPoints.Exists(x => x == allCells[currWayY, currWayX + 1]))
            {
                currWayGo = allCells[currWayY, currWayX + 1];
                currWayX++;
                Debug.Log("Next Cell is Right");
            }
            else if (currWayY > 0 && allCells[currWayY - 1, currWayX].GetComponent<CellScr>().isGround &&
                !wayPoints.Exists(x => x == allCells[currWayY - 1, currWayX]))
            {
                currWayGo = allCells[currWayY - 1, currWayX];
                currWayY--;
                Debug.Log("Next Cell is Up");
            }
            else if (currWayY < (fieldHeight - 1) && allCells[currWayY + 1, currWayX].GetComponent<CellScr>().isGround &&
                !wayPoints.Exists(x => x == allCells[currWayY + 1, currWayX]))
            {
                currWayGo = allCells[currWayY + 1, currWayX];
                currWayY++;
                Debug.Log("Next Cell is Down");
            }
            else
                break;

            wayPoints.Add(currWayGo);
        }
    } 
}
