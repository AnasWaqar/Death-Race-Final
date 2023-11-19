using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CrossHair;
    public bool locked,oncrossbtn,oncrosschangebtn;
    public Transform Target;
    public List<GameObject> enemiesInGame = new List<GameObject>();
    public List<GameObject> enemiesOnScreen = new List<GameObject>();
    public int index = 0;
    void Start()
    {
        
        CrossHair.SetActive(false);
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject en in allEnemies)
        {
            enemiesInGame.Add(en);
        }
        oncrossbtn = true;
        oncrosschangebtn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesInGame.Count>0)
        {
            for(int i=0; i<enemiesInGame.Count;i++)
            {
                Vector3 enemyposition = Camera.main.WorldToViewportPoint(enemiesInGame[i].transform.position);

                bool isOnScreen = (enemyposition.z > 0 && enemyposition.x > 0 && enemyposition.x < 1 && enemyposition.y > 0 && enemyposition.y < 1) ? true : false;

                if (isOnScreen && !enemiesOnScreen.Contains(enemiesInGame[i]))
                {
                    
                    enemiesOnScreen.Add(enemiesInGame[i]);
                }
                else if(enemiesOnScreen.Contains(enemiesInGame[i]) && !isOnScreen)
                {
                    locked = false;
                    enemiesOnScreen.Remove(enemiesInGame[i]);
                    
                }
            }
        }

        //if (Input.GetKeyDown(KeyCode.Space) && !locked && enemiesOnScreen.Count > 0)
        //{
            
        //    index = 0;
        //    locked = true;
        //    CrossHair.SetActive(true);
        //}

        //else if (Input.GetKeyDown(KeyCode.Space) && locked)
        //{
        //    locked = false;
        //    Target = null;
        //    CrossHair.SetActive(false);
        //}

        //if (Input.GetKeyDown(KeyCode.X) && locked)
        //{
        //    if (enemiesOnScreen.Count > 0)
        //    {
        //        index++;
        //        if (index >= enemiesOnScreen.Count)
        //        {
        //            index = 0;
        //        }
        //    }
        //}


        if (locked)
        {
            Target = enemiesOnScreen[index].transform;
            CrossHair.transform.position = Camera.main.WorldToScreenPoint(Target.position);
        }
    }
    public void OnCrossHair()
    {
        if(oncrossbtn)
        {
            if (!locked && enemiesOnScreen.Count > 0)
            {
                index = 0;
                locked = true;
                CrossHair.SetActive(true);
            }
            oncrossbtn = false;
        }
        else
        {
            if(locked)
            {
                print("En");
                locked = false;
                Target = null;
                CrossHair.SetActive(false);
            }
            oncrossbtn = true;
        }
    }

    public void CrossHairChange()
    {
        
            if (enemiesOnScreen.Count > 0)
            {
               // print(enemiesOnScreen[index].name);
                index++;
                if (index >= enemiesOnScreen.Count)
                {
                    index = 0;
                }
            //enemiesOnScreen[index]
            
            }
        
    }
}
