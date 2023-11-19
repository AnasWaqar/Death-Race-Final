using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{

    public  int raceposition;

 
    // Start is called before the first frame update
    void Start()
    {
       
       


    }

    // Update is called once per frame
    void Update()
    {

        if (this.gameObject.tag == "Player")
        {
            this.raceposition = this.GetComponent<Player_Position_Script>().raceposition;
        }
        else
        {
            this.raceposition = this.GetComponent<Enemy_Car_Position_Script>().raceposition;
        }

    }
}
