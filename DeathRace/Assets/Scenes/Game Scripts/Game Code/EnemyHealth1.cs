using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth1 : MonoBehaviour
{
    public float health = 50f;
    public EnemyCracked ec;
    public Image healthbar;
    public float amt;
    public float DamagHealthBar;
    public float CollisionHealth;
    public float CollisionHealthBar;
    public float MissileHealth;
    public float MissileHealthBar;
    public float BombHealth;
    public float BombHealthBar;
    public int check;
    //public  int t_enemy;

    void Start()
    {
        check = 0;
    }

    public void TakeDamage(float amount)
    {
        print(amount);
        health -= amount;

        healthbar.fillAmount = healthbar.fillAmount - DamagHealthBar;
        if (health <= 0f)
        {
            print("Enemyhealth");
            ec.cracked_enemy_robot();
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player")
        {
            //print("Waleed");
            health = health - CollisionHealth;
            healthbar.fillAmount = healthbar.fillAmount - CollisionHealthBar;
            if (health <= 0f)
            {

                ec.cracked_enemy_robot();
                //Destroy(this.gameObject);
                this.gameObject.SetActive(false);
            }
        }
        if (other.gameObject.tag == "Missile")
        {
            if (amt == 0)
            {
                if (check == 0)
                {
                    print("EnemyhealthMissile");
                    health = health - MissileHealth;
                    print(health);
                    healthbar.fillAmount = healthbar.fillAmount - MissileHealthBar;
                    check++;
                    Invoke("Change", 0.5f);
                    if (health <= 0f)
                    {
                        amt += 1;
                        print("destory");
                        ec.cracked_enemy_robot();
                        //Destroy(this.gameObject);
                        this.gameObject.SetActive(false);
                    }

                }

            }

        }

    }
    void Change()
    {
        check = 0;
    }
        private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Bombs")
        {
            print("EnemyhealthBomb");
            health = health - BombHealth;
            healthbar.fillAmount = healthbar.fillAmount - BombHealthBar;
            if (health <= 0f)
            {

                ec.cracked_enemy_robot();
                //Destroy(this.gameObject);
                this.gameObject.SetActive(false);
            }
        }

    }
}
