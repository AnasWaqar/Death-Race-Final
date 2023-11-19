using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject [] Cars;
    
    void Start()
    {
        
    }
    public void Awake()
    {
        //PlayerPrefs.SetInt("Car_Select", 0);

        for (int i=0; i<Cars.Length;i++)
        {
            if (i == PlayerPrefs.GetInt("Car_Select"))
            {
                Cars[i].SetActive(true);
            }
            else
            {
                Cars[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
