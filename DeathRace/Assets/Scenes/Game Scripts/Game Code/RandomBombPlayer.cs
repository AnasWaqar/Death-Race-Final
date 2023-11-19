using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBombPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bombeffect, bomb;
    public float power = 20f;
    public float radius = 5f;
    public float upforce = 1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 7f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
         
            GameObject Bomb = Instantiate(bombeffect, this.transform.position, this.transform.rotation);
            CarExpolsion(); 
            Destroy(Bomb, 2f);
        }
    }
   
    public void CarExpolsion()
    {
      
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
        this.GetComponent<BoxCollider>().enabled = false;
    }
}
