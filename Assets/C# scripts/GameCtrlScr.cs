using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameCtrlScr : MonoBehaviour
{
    public int cellCount;
    public int enemyStartPos;
    public GameObject cellPref;
    public Transform cellGroup;
    public int[] PathId = { 
            23, 24, 25, 26, 48, 70, 92, 114,
            113, 135, 157, 158, 159, 160, 138, 126, 
            127, 128, 129, 130, 131, 132 };
    public List<CellScr> AllCells = new List<CellScr>();

    // Start is called before the first frame update
    void Start()
    {
        CreateCells();
        CreatePath();
    }

    void CreateCells()
    {
        for (int i = 0; i <= cellCount; i++)
        {
            GameObject tmpCell = Instantiate(cellPref);
            tmpCell.transform.SetParent(cellGroup, false);
            tmpCell.GetComponent<CellScr>().id = i + 1;
            tmpCell.GetComponent<CellScr>().SetState(0);
            AllCells.Add(tmpCell.GetComponent<CellScr>());
        }
    }

    void CreatePath()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
