using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    public int e_count,p_count,pos;
    //public Play p;
    public GameObject endcamera, rcc_camera,canvas;
    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            e_count += 1;
            //FindObjectOfType<Death_AICarController>().enabled = false;
            other.gameObject.GetComponent<Enemy_Car_Position_Script>().enabled = false;
            other.gameObject.GetComponent<CheckPoints>().enabled = false;
            other.gameObject.GetComponent<Death_AICarController>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().drag = 2;
            //other.gameObject.GetComponent<Improved_Tracer_Enemy>().enabled = false;
        }
        //else if (other.gameObject.tag == "Enemy2")
        //{
        //    e_count += 1;
        //    other.gameObject.GetComponent<DeathRace_AI>().enabled = false;
        //    other.gameObject.GetComponent<Enemy_Car_Position_Script>().enabled = false;
        //    other.gameObject.GetComponent<Rigidbody>().drag = 1;
        //}
        //else if (other.gameObject.tag == "Enemy3")
        //{
        //    e_count += 1;
        //    other.gameObject.GetComponent<DeathRace_AI>().enabled = false;
        //    other.gameObject.GetComponent<Enemy_Car_Position_Script>().enabled = false;
        //    other.gameObject.GetComponent<Rigidbody>().drag = 1;
        //}
        //else if (other.gameObject.tag == "Enemy4")
        //{
        //    e_count += 1;
        //    other.gameObject.GetComponent<DeathRace_AI>().enabled = false;
        //    other.gameObject.GetComponent<Enemy_Car_Position_Script>().enabled = false;
        //    other.gameObject.GetComponent<Rigidbody>().drag = 1;
        //}
        else if(other.gameObject.tag=="Player")
        {
            FindObjectOfType<Death_Race_Camera>().TPSDistance = 15f;
            FindObjectOfType<Death_Race_Camera>().TPSHeight = 5f;
            FindObjectOfType<Play>().playcount = 0;
            canvas.SetActive(false);
            //endcamera.SetActive(true);
            //rcc_camera.SetActive(false);
            if (e_count>1)
            {
                print("lose");
                Invoke("failfunc", 6f);
            }
            else
            {
                print("won");
                Invoke("clearfunc", 6f);
                
               
            }
            other.gameObject.GetComponent<Death_Race_CarControllerV3>().enabled = false;
            other.gameObject.GetComponent<Player_Position_Script>().enabled = false;
            other.gameObject.GetComponent<CheckPoints>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().drag = 2;
        }
    }

   public void failfunc()
    {
        canvas.SetActive(true);
        FindObjectOfType<Play>().FailCall();
        endcamera.SetActive(false);
        //rcc_camera.SetActive(true);
    }
    public void clearfunc()
    {
        canvas.SetActive(true);
        endcamera.SetActive(false);
        //rcc_camera.SetActive(true);
        FindObjectOfType<Play>().ClearCall();
    }
}
