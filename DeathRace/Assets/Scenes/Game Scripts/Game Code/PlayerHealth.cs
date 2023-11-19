using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 50f;
    public GameObject player;
    public PlayerCracked pc;
    public Image healthbar;
    //public Play p;
    public float HealthBarDamage;
    public float CollideHealth;
    public float CollideHealthBar;
    public float MissileHealth;
    public float MissileHealthBar;
    public int count;
    public int check;
    public void TakeDamage(float amount)
    {
        health -= amount;
        healthbar.fillAmount = healthbar.fillAmount - HealthBarDamage;
        if (health <= 0f)
        {
            pc.cracked_player_robot();
            player.SetActive(false);
            Invoke("failfunc", 1f);
        }
    }
    public void failfunc()
    {
        FindObjectOfType<Play>().FailCall();
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            print("Collide");
            health -= CollideHealth;
            healthbar.fillAmount = healthbar.fillAmount - CollideHealthBar;
            if (health <= 0f)
            {
                pc.cracked_player_robot();
                player.SetActive(false);
                Invoke("failfunc", 1f);
            }
        }
        if(other.gameObject.tag=="MissileEnemy")
        {
            if (count == 0)
            { 
                if (check == 0)
                {
                    health -= MissileHealth;
                    healthbar.fillAmount = healthbar.fillAmount - MissileHealthBar;
                    check++;
                    Invoke("Change", 0.5f);
                    if (health <= 0f)
                    {
                        count++;
                        pc.cracked_player_robot();
                        player.SetActive(false);
                        Invoke("failfunc", 1f);
                    }
                }
            }
            //FindObjectOfType<Improved_Tracer_Enemy>().TimeTillExpire = 0;
            
        }
    }
    void Change()
    {
        check = 0;
    }
}
