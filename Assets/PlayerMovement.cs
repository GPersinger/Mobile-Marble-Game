using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool phoneIsConnected = false;
    [HideInInspector]
    public Vector3 dir;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(phoneIsConnected){
            dir.x = Input.acceleration.x;
            dir.z = Input.acceleration.y;

        }else{
            dir.x = Input.GetAxis("Horizontal");
            dir.z = Input.GetAxis("Vertical");
        }
        rb.AddForce(dir * 10);
    }
}
