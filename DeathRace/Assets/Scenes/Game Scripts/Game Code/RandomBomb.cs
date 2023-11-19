using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBomb : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bombeffect,bomb,player;
    public float power=20f;
    public float radius=5f;
    public float upforce=1f;
    public float RandomBombDamage;
    public float Health;
   // public PlayerHealth ph;
   // public PlayerCracked pc;
   // public Play p;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       // Destroy(this.gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
            GameObject Bomb = Instantiate(bombeffect, this.transform.position, this.transform.rotation);
            CarExpolsion();
            FindObjectOfType<PlayerHealth>().health -= RandomBombDamage;
            FindObjectOfType<PlayerHealth>().healthbar.fillAmount = FindObjectOfType<PlayerHealth>().healthbar.fillAmount - Health;
            if (FindObjectOfType<PlayerHealth>().health <= 0f)
            {
                FindObjectOfType<PlayerCracked>().cracked_player_robot();
                player.SetActive(false);
                Invoke("failfunc", 1f);
            }
            //Destroy(Bomb, 2f);
        }
    }

    public void CarExpolsion()
    {
        player.GetComponent<Death_Race_CarControllerV3>().speed -= 50;
        Vector3 expolsionposition = bomb.transform.position;

        Collider[] colliders = Physics.OverlapSphere(expolsionposition, radius);

        foreach (Collider hit in colliders)
        {

            Rigidbody r1 = hit.GetComponent<Rigidbody>();
            if (r1 != null)
            {

                r1.AddExplosionForce(power, expolsionposition, radius, upforce, ForceMode.Impulse);

            }
        }
    }
    public void failfunc()
    {
        
        FindObjectOfType<Play>().FailCall();
    }
}
