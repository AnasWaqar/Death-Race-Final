using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MissileCount : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject missilebtn;
    public int missile;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (missile <= 0)
        {
            missilebtn.GetComponent<Button>().interactable = false;
        }
        else
        {

            missilebtn.GetComponent<Button>().interactable = true;
        }
    }
}
