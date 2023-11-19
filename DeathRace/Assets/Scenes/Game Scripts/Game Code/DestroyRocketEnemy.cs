using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRocketEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Improved_Tracer_Enemy ITE;
    void Start()
    {
        ITE = FindObjectOfType<Improved_Tracer_Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            print("MissileEnemy");
            Destroy(this.gameObject, 0.2f);
            //this.ITE.TimeTillExpire = 0;
            //this.gameObject..TimeTillExpire = 0;
        }
    }
}
