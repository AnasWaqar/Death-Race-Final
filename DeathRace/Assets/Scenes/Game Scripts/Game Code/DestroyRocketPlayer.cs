using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRocketPlayer : MonoBehaviour
{
    // Start  called before the first frame update
    //public Improved_Tracer IT;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == "Enemy")
        {
            
            //FindObjectOfType<Improved_Tracer>().TimeTillExpire = 0;
            //this.gameObject..TimeTillExpire = 0;
        }
    }
}
