using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMineBomb : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody projectile;
    public GameObject point;
    Rigidbody clone;

    public float checktime = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {

            if (checktime <= 0f)
            {
                ChangeCollider();
                 checktime = 1.5f;
            }
            else
            {
                checktime -= Time.deltaTime;
            }
        }
    }
    public void ChangeCollider()
    {
        clone = Instantiate(projectile, point.transform.position, point.transform.rotation);
       // clone.GetComponent<SphereCollider>().isTrigger = true;
    }
}
