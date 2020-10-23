using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePlatform : MonoBehaviour
{
    AudioSource aud;
    public AudioClip force;
    public float forcethis = 10;

    Vector3 dir;

    void Start(){
        aud = GameObject.Find("AudioSource").GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            if (other.transform.gameObject.GetComponent<Rigidbody>() !=null) {
                Rigidbody rb = other.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;                
                rb.AddRelativeForce(transform.up * forcethis, ForceMode.Impulse);
                aud.PlayOneShot(force);
            }
        }
    }
}
