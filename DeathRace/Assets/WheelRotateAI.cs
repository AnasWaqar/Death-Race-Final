using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotateAI : MonoBehaviour
{
    // Start is called before the first frame update
    public WheelCollider targerwheel;
    public Vector3 wheelpos = new Vector3();
    public Quaternion wheelrotate = new Quaternion();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targerwheel.GetWorldPose(out wheelpos, out wheelrotate);
        transform.position = wheelpos;
        transform.rotation = wheelrotate;
    }
}
