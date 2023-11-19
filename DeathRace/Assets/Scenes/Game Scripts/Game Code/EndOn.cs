using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject start, end,endline,firstsensor,lastsensor;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag=="Enemy")
        {
            start.SetActive(false);
            end.SetActive(true);
            endline.SetActive(true);
            firstsensor.SetActive(false);
            lastsensor.SetActive(true);
        }
    }
}
