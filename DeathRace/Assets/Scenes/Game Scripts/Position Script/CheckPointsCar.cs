using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsCar : MonoBehaviour
{
    // Start is called before the first frame update
    public static int checkpoint;
    public GameObject nextcube,endline;
   // public Play p;
    //public GameObject endcamera, rcc_camera, canvas;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            checkpoint++;
            nextcube.SetActive(true);
            this.gameObject.SetActive(false);
            FindObjectOfType<Play>().Timer = FindObjectOfType<Play>().Timer + 8f;
            if(checkpoint==12)
            {
                endline.SetActive(true);
            }
            if (checkpoint == 26)
            {
                FindObjectOfType<Play>().playcount = 0;
                //canvas.SetActive(false);
                //endcamera.SetActive(true);
                //rcc_camera.SetActive(false);
                Invoke("clearfunc", 8f);

            }

        }

    }
    //public void clearfunc()
    //{
    //    canvas.SetActive(true);
    //    endcamera.SetActive(false);
    //    rcc_camera.SetActive(true);
    //    FindObjectOfType<Play>().ClearCall();
    //}
}
