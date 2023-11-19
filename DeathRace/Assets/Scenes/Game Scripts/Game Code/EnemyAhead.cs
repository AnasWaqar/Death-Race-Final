using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyAhead : MonoBehaviour
{
    // Start is called before the first frame update
    public LockOnTarget LT;
    public Shooting1 Shoot;
    public GameObject gunrotation1, gunrotation2;
    public bool gunrotate;
    //public GameObject fire, missile;
    //public GameObject gun;

    void Start()
    {
        gunrotate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gunrotate)
        {
            //missile.GetComponent<Button>().interactable= true;
            Shoot.gun1.transform.LookAt(LT.enemiesOnScreen[LT.index].transform.position);
            Shoot.gun2.transform.LookAt(LT.enemiesOnScreen[LT.index].transform.position);
        }
        else
        {

            //missile.GetComponent<Button>().interactable = false;
            //Shoot.gun1.transform.rotation.
            //Shoot.gun2.transform.LookAt(gunrotation.transform.position);
                Shoot.gun1.transform.LookAt(gunrotation1.transform.position);
            Shoot.gun2.transform.LookAt(gunrotation2.transform.position);

        }
        
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            ///notenemy = false;
            //fire.interactable = true;
            gunrotate = true;
            if (!LT.locked && LT.enemiesOnScreen.Count > 0)
            {

                LT.index = 0;
                LT.locked = true;
                LT.CrossHair.SetActive(true);
            }
            
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        //notenemy = true;
        //fire.interactable = false;
        gunrotate = false;
        if (other.gameObject.tag == "Enemy")
        {
            if (LT.locked)
            {
                
                LT.locked = false;
                LT.Target = null;
                LT.CrossHair.SetActive(false);
            }
        }
    }
}
