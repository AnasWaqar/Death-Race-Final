using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathCount : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemycount,clearvalue;
    //public Play p;
    void Start()
    {
        //p = FindObjectOfType<Play>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemycount==clearvalue)
        {
            Invoke("clearfunc", 5f);
        }
    }
    public void clearfunc()
    {
        FindObjectOfType<Play>().ClearCall();
    }
}
