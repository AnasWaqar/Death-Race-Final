using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMineBomb : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody projectile;
    public GameObject point;
    Rigidbody clone;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MineBomb()
    {
        clone = Instantiate(projectile, point.transform.position, point.transform.rotation);
    }
}
