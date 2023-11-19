using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    //public Transform other;
    public float damage = 0.5f;
    //public float checktime;
    public float range = 60f;
    public ParticleSystem fire1, fire2;
    public GameObject ImpactEffect, gun1,gun2, player;
    // public GameObject gun, player;
    // Start is called before the first frame update
    void Awake()
    {
        fire1.Stop();
        fire2.Stop();

    }
    void Start()
    {
        //other = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        fire1.Stop();
        fire2.Stop();
        //checktime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //if(checktime<=0f)
        //{
        //    Check(); 
        //    checktime = 5f;
        //}
        //else
        //{
        //    checktime  -=Time.deltaTime;
        //}


        //if (other)
        //{

        //    dist = Vector3.Distance(other.position, transform.position);
        //    print("Distance to other: " + dist);
        //}
        //if (dist < 20f)
        //{
        // gun.transform.LookAt(player.transform);
        //    Invoke("GunShoot", 1f);

        //}
        //else
        //{
        //    fire1.Play();
        //    fire2.Play();
        //}
    }

    public void GunShoot()
    {
        fire1.Play();
        fire2.Play();
        RaycastHit hit;
       // print("Enemyyyyyyyyyy");
        gun1.transform.LookAt(player.transform);
        gun2.transform.LookAt(player.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
        {
            
            //Debug.Log(hit.transform.name);
            PlayerHealth P_health = hit.transform.GetComponent<PlayerHealth>();
            if (P_health != null)
            {
                P_health.TakeDamage(damage);
            }

            GameObject EffectDestory = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(EffectDestory, 1f);
        }
    }
    public void GunStop()
    {
        fire1.Stop();
        fire2.Stop();
    }
}
