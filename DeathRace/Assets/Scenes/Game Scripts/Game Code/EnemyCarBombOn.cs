﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarBombOn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject minebomb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="BombOn")
        {
            this.minebomb.SetActive(true);
        }
    }
}
