using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapSytem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] lapcubes;
    public static int val;
    public GameObject end;
    void Start()
    {
        end.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerCube.lap == 2)
        {
            print("Clear");
            end.SetActive(true);
            //clear.SetActive(true);
            //Time.timeScale = 0;
        }
    }
    public  void lapcount()
    {
        if(TriggerCube.lap==2)
        {
            print("Clear");
            end.SetActive(true);
            //clear.SetActive(true);
            //Time.timeScale = 0;
        }
    }
    
}
