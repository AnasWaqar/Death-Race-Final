using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAdd : MonoBehaviour
{
    // Start is called before the first frame update
    public static int fireamountadd;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 15, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag=="Player")
        {
            print("Add");
            FindObjectOfType<Shooting1>().firecount += + 10;
            this.gameObject.SetActive(false);
        }
    }
}
