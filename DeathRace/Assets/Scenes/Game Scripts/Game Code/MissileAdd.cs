using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileAdd : MonoBehaviour
{
    // Start is called before the first frame update
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
        if (other.gameObject.tag == "Player")
        {
            print("Add");
            FindObjectOfType<MissileCount>().missile += 3;
            this.gameObject.SetActive(false);
        }
    }
}
