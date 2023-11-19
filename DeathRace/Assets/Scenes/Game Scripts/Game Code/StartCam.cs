using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCam : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Cam,Fcam;
    public virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        Cam.SetActive(true);
        Fcam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCam()
    {
        Cam.SetActive(true);
        Fcam.SetActive(false);
    }
}
