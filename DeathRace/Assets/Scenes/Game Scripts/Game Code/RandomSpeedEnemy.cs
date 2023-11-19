using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpeedEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedtime;
    void Start()
    {
        speedtime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (speedtime <= 0)
        {
            //other.gameObject.GetComponent<RCC_CarControllerV3> ().speedsss(startspped,endspeed);
            this.gameObject.GetComponent<Death_Race_CarControllerV3>().maxspeed += Random.Range(-10f, 20.0f);
            speedtime = 10;
        }
        else
        {
            speedtime -= Time.deltaTime;
        }
    }
   
}
