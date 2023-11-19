using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Thomas")
        {
            //other.gameObject.GetComponent<RCC_CarControllerV3> ().speedsss(startspped,endspeed);
            other.gameObject.GetComponent<Death_Race_CarControllerV3>().maxspeed += Random.Range(-15.0f, 35.0f);
        }

    }
}
