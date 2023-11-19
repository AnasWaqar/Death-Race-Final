using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class storage : MonoBehaviour
{
    public int part;
    public int nexttouse;
    public float halfheight;
    public GameObject playercar;
    public Player_Position_Script playercarscript;
    public GameObject enemycar;
    public Enemy_Car_Position_Script enemycarscript;
    public Enemy_Car_Position_Script[] allcomputercars;
    public bool allcomputercars_ElementsExpand;
    public int allcomputercars_ElementsSize;
   // public GameObject lapsystemobject;
    //public lap_script lapscript;
    public int menucamefrom;
    public virtual void Start()
    {
    }

    public virtual void Update()
    {
    }

    public storage()
    {
        this.part = 5;
        this.halfheight = 1f;
        this.allcomputercars_ElementsExpand = true;
        this.allcomputercars_ElementsSize = 1;
    }

}