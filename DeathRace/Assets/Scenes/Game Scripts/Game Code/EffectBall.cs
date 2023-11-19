using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBall : MonoBehaviour
{
    public GameObject ImpactEffect;
    public float damage = 10f;
    //public Image healthbar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 3f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {

        }
        else
        {
             print("Fire");

            //healthbar.fillAmount = healthbar.fillAmount - 0.2f;
            //if (health <= 0f)
            //{

            //    ec.cracked_enemy_robot();
            //    //Destroy(this.gameObject);
            //    this.gameObject.SetActive(false);
            //}
            //EnemyHealth1 traget = this.transform.GetComponent<EnemyHealth1>();
            //    if (traget != null)
            //    {
            //        traget.TakeDamage(damage);
            //    }
            GameObject EffectDestory = Instantiate(ImpactEffect, this.transform.position, this.transform.rotation);
            Destroy(EffectDestory, 1.5f);



            Destroy(this.gameObject, 0.1f);

        }
    }
}
