using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Getpositionnumer : MonoBehaviour
{
    // Start is called before the first frame update
    public int getposition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getposition=GetComponent<Player_Position_Script>().positionn;
        print(getposition);
    }
}
