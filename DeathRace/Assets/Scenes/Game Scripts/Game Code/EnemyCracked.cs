using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCracked : MonoBehaviour
{
    public GameObject crackedcar, bombs, CrackedEnemy, Explosion;
    public float power = 30.0f;
    public float radius = 5.0f;
    public float upforce = 1.0f;
    public int t_enemy;
    public int count;

   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void cracked_enemy_robot()
    {
        CrackedEnemy = Instantiate(crackedcar, transform.position, transform.rotation);
        this.gameObject.SetActive(false);
        Detonatesss();
    }
    public void Detonatesss()
    {
            FindObjectOfType<EnemyDeathCount>().enemycount += 1;
            GameObject EffectDestory = Instantiate(Explosion, this.transform.position, this.transform.rotation);
            Destroy(EffectDestory, 2f);
            Vector3 expolsionposition = bombs.transform.position;
            Collider[] colliders = Physics.OverlapSphere(expolsionposition, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody r1 = hit.GetComponent<Rigidbody>();
                if (r1 != null)
                {
                    r1.AddExplosionForce(power, expolsionposition, radius, upforce, ForceMode.Impulse);
                }

            }
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 20);
            PlayerPrefs.SetInt("TotalEnemies", PlayerPrefs.GetInt("TotalEnemies") + 1);

            ;
            //print(FindObjectOfType<EnemyDeathCount>().enemycount);
            Destroy(CrackedEnemy, 4f);
        //gameObject.SetActive(true);
        //Invoke("off", 3f);
    }
 
}
