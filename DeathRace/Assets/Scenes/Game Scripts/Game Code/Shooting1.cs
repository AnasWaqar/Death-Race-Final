using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shooting1 : MonoBehaviour
{
    public float damage = 10f;
    public float range = 200f;
    public ParticleSystem fire1,fire2;
    public Text bullet;
    public GameObject ImpactEffect,firebtn, cross;
    public int firecount;
    //public Play p;

    public Transform gun1,gun2;
    public LockOnTarget LT;
    //public Rigidbody projectile;
    //GameObject rayPos;
    

    // public Camera fps;

    void Awake()
    {
       
        fire1.Stop();
        fire2.Stop();
        
    }
    void Start()
    {
        
        fire1.Stop();
        fire2.Stop();
        bullet.text = firecount.ToString();
    }
    // Update is called once per frame
    void Update()
    {

        //gun.transform.LookAt(crossfire.transform);
        //gun.transform.rotation = Quaternion.LookRotation(cross);
        bullet.text = firecount.ToString();
        if (firecount<=0)
        {
            firebtn.GetComponent<Button>().interactable = false;
            print("hi");
            fire1.Stop();
            fire2.Stop();
        }
       else
        {
            print("by");
            firebtn.GetComponent<Button>().interactable = true;
        }

        if(FindObjectOfType<Play>().fire)
        {
            
            print(firecount);
            fire1.Play();
            fire2.Play();
            RaycastHit hit;
            firecount --;
            bullet.text = firecount.ToString();
            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, range))
            {
                Debug.DrawRay(this.transform.position, this.transform.forward * hit.distance, Color.yellow);
                Debug.Log(hit.transform.name);
                EnemyHealth1 traget = hit.transform.GetComponent<EnemyHealth1>();
                if (traget != null)
                {
                    traget.TakeDamage(damage);
                }
                GameObject EffectDestory = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(EffectDestory, 1.5f);
            }

            FindObjectOfType<Play>().fire = false;
        }
        else
        {
            fire1.Stop();
            fire2.Stop();
        }
        
        
        
    }
    
    //public void particleOn()
    //{
    //    fire1.Play();
    //    fire2.Play();
    //    RaycastHit hit;
    //    firecount = firecount - 1;
    //    bullet.text = firecount.ToString();
    //    print(firecount);
    //    //Ray rayorigin = Camera.main.ScreenPointToRay(cross.transform.position);
    //    ////Rigidbody clone;
    //    ////clone = Instantiate(projectile, point.transform.position, point.transform.rotation);
    //    ////clone.velocity = transform.TransformDirection(Vector3.forward * 100);
    //    ////gun1.transform.LookAt(LT.enemiesOnScreen[LT.index].transform.position);
    //    ////gun2.transform.LookAt(LT.enemiesOnScreen[LT.index].transform.position);


    //    if (Physics.Raycast(this.transform.position,this.transform.forward, out hit, range))
    //    //if (Physics.Raycast(rayorigin.origin,rayorigin.direction*100, out hit))
    //    //if (Physics.Raycast(rayorigin.origin,rayorigin.direction, out hit,range))
    //    {
    //        //Vector3 direction = hit.point - gun1.position;
            
    //        //Debug.DrawRay(this.transform.position, this.transform.forward * hit.distance, Color.yellow);
    //        Debug.DrawRay(this.transform.position, this.transform.forward * hit.distance, Color.yellow);
    //        Debug.Log(hit.transform.name);
    //        EnemyHealth1 traget = hit.transform.GetComponent<EnemyHealth1>();
    //        if (traget != null)
    //        {
    //            traget.TakeDamage(damage);
    //        }
    //        GameObject EffectDestory = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
    //        Destroy(EffectDestory, 1.5f);

    //    }


    //}
    public void particleOff()
    {
        fire1.Stop();
        fire2.Stop();
    }
}
