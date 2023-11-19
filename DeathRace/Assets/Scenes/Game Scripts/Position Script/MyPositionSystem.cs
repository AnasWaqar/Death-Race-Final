using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPositionSystem : MonoBehaviour
{
    public GameObject[] getPositions,getpos;
    GameObject temp;
    public Text[] positionText;
    public static int playerwin;
    int z = 0;
    // Start is called before the first frame update
    public void Start()
    {
        
        //   playerwin = 0;
        getPositions[0] = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
     public void Update()
    {
        GetPos();
        SetPos();
    }
    public void GetPos()
    {
       // for(int i = 0; i <= getPositions.Length; i++)
        //{
            for (int j = 0; j < getPositions.Length-1; j++)
            {
                if (getPositions[j].GetComponent<CheckPoints>().raceposition > getPositions[j+1].GetComponent<CheckPoints>().raceposition)
                {
                    temp = getPositions[j];
                    getPositions[j] = getPositions[j + 1];
                    getPositions[j + 1] = temp;
                    
                }

            }

    //   }
    }

    public void SetPos()
    {
        for (int i = 0; i < getPositions.Length; i++)
        {
            z = i + 1;  
            positionText[i].text =getPositions[i].name.ToString();
         //   EndSHowPos[i].text = " " + z + "    " + getPositions[i].name.ToString();

            if (getPositions[i].gameObject.tag == "Player")
            {
                if (i == 0)
                {
                    playerwin = 1;
                    // print("win");
                }
                else
                {
                    playerwin = 0;
                }

            }

        }
    }
}

