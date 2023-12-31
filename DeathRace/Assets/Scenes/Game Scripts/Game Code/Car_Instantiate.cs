﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Instantiate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject robot1prefab, robot1prefabclone, rightbtn, leftbtn;
    public GameObject[] Robotspreb;
    public GameObject[] Robotclone;
    public GameObject[] Box;
    public bool onrobot, num, on1robot, check;
    public int count, rotate,boxnum;
    public AudioSource btn_selection;
    public AudioClip btnsnd1;
    void Start()
    {
        onrobot = false;
        num = false;
        count = -1;
        on1robot = false;
        check = false;
        rotate = 0;
        boxnum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //robot1prefabclone.transform.Rotate(0, 100, 0);
        if (count == 6)
        {
            rightbtn.SetActive(false);
        }
        else
        {
        
            rightbtn.SetActive(true);
        }
        if (count == -1)
        {
           
            leftbtn.SetActive(false);
        }
        else
        {
      
            leftbtn.SetActive(true);
        }
        if (on1robot == false)
        {
            robot1prefabclone = Instantiate(robot1prefab, transform.position, Quaternion.identity) as GameObject;
            // robot1prefabclone.transform.Rotate(0, 100, 0);
            // robot1prefabclone.transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
            on1robot = true;
        }
        if (rotate == 0)
        {
            //robot1prefabclone.transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
        }


        for (int i = 0; i < Box.Length; i++)
        {
            if(i==boxnum)
            {
                Box[i].SetActive(true);
            }
            else
            {
                Box[i].SetActive(false);
            }
        }

            for (int i = 0; i < Robotspreb.Length; i++)
        {

            //Robotclone[i].transform.Rotate(0, 100, 0);
            if (i == count)
            {

                if (onrobot)
                {

                    Robotclone[i] = Instantiate(Robotspreb[i], transform.position, Quaternion.identity) as GameObject;
                    //Robotclone[i].transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
                    onrobot = false;
                }
                else
                {
                    // Robotclone[i].transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);

                    if (check)
                    {
                        Destroy(Robotclone[count - 1]);
                    }

                }
            }

        }

    }

    public void OnClickfwd()
    {
        boxnum++;
        btn_selection.PlayOneShot(btnsnd1, 1f);
        //Robot_Menu.value_count++;
        //Robotvalue_count++;
        onrobot = true;
        count++;
        rotate++;
        Destroy(robot1prefabclone);
        if (count == 1)
        {
            check = true;
        }


    }
    public void OnClickbwd()
    {
        boxnum--;
        btn_selection.PlayOneShot(btnsnd1, 1f);
        //Robot_Menu.value_count--; 
        boxnum--;
        rotate--;
        num = true;
        count--;

        if (count == 0)
        {
            check = false;
        }

        for (int i = 0; i < Robotspreb.Length; i++)
        {
            if (i == count)
            {
                Destroy(Robotclone[count + 1]);
                Robotclone[count] = Instantiate(Robotspreb[count], transform.position, Quaternion.identity) as GameObject;
                //Robotclone[count].transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);

            }
        }
        if (count == -1)
        {
            robot1prefabclone = Instantiate(robot1prefab, transform.position, Quaternion.identity) as GameObject;
            //robot1prefabclone.transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
            Destroy(Robotclone[count + 1]);
        }

    }
}
