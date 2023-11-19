using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingforDesert : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public ParticleSystem fire1, fire2;
    public Text bullet;
    public GameObject ImpactEffect, gun, aim, firebtn;
    public EnemyCracked ec;
    public static int firecount;
    public Play p;

    // public Camera fps;

    void Awake()
    {
        fire1.Stop();
        fire2.Stop();

    }
    void Start()
    {
        PlayerPrefs.DeleteKey("TotalEnemies");
        firecount = 50;
        fire1.Stop();
        fire2.Stop();
        bullet.text = firecount.ToString();
    }
    // Update is called once per frame
    void Update()
    {

        gun.transform.LookAt(aim.transform);
        if (PlayerPrefs.GetInt("TotalEnemies").Equals(3))
        {

            Invoke("clearfunc", 5f);
        }
        else if (PlayerPrefs.GetInt("TotalEnemies").Equals(4))
        {

            Invoke("clearfunc", 5f);
        }

        // print(ec.t_enemy);
        if (firecount <= 0)
        {
            firebtn.GetComponent<Button>().interactable = false;
           // firebtn.GetComponent<EventTrigger>().enabled = false;
        }
        else
        {
            firebtn.GetComponent<Button>().interactable = true;
          //  firebtn.GetComponent<EventTrigger>().enabled = true;
        }


        bullet.text = firecount.ToString();
    }

    public void particleOn()
    {
        fire1.Play();
        fire2.Play();
        RaycastHit hit;
        firecount = firecount - 1;
        bullet.text = firecount.ToString();
        print(firecount);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
        {

            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log(hit.transform.name);

            EnemyHealth1 traget = hit.transform.GetComponent<EnemyHealth1>();
            if (traget != null)
            {
                traget.TakeDamage(damage);
            }
            GameObject EffectDestory = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(EffectDestory, 1.5f);
        }

    }
    public void particleOff()
    {
        fire1.Stop();
        fire2.Stop();


    }
    public void clearfunc()
    {
        p.ClearCall();
    }
}
