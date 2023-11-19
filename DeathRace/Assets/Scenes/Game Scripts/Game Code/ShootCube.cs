using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCube : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyShooting ES;
    public bool check;
    public float checktime = 0,checktimemissiel=0;
    public ShootImprovedTracer_Enemy MissileEnemy;
    public int count = 0;
    public int missilelimit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //check = true;
            //// ES.GunShoot();
            //if(check)
            //{
            //    ES.GunShoot();
            //}
            if(checktimemissiel<=0f && count!= missilelimit)
            {
                MissileEnemy.MissileShootEnemy();
                checktimemissiel = 4f;
                count = count + 1;
            }
            else
            {
                checktimemissiel -= Time.deltaTime;
            }
            if (checktime <= 0f)
            {
                ES.GunShoot();
                checktime = 0.5f;
            }
            else
            {
                checktime -= Time.deltaTime;
            }

        }

    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        MissileEnemy.MissileShootEnemy();
    //    }
    //}
    private void OnTriggerExit(Collider other)
    {
        ES.GunStop();
        ES.gun1.transform.Rotate(0, 0, 0);
        ES.gun2.transform.Rotate(0, 0, 0);
    }
}
