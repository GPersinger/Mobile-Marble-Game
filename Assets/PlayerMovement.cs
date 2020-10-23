using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public bool phoneIsConnected = false;
    [HideInInspector]
    public Vector3 dir, startPosition, calibrateDir;
    Rigidbody rb;
    public float jumpForce = 5;
    AudioSource aud;
    //public AudioClip mainMusic;
    public AudioClip jump;
    public AudioClip jumpCap;
    public AudioClip coin;
    
    public Button jumpButton;

    public TextMeshProUGUI scoreText;
    int score = 0;
    int coinScore = 250;

    bool isGrounded = true;
    bool canJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        startPosition = this.transform.position;
        aud = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        //aud.PlayOneShot(mainMusic);
        CalibrateTilt();
        
    }

    void Update(){
        if(this.transform.position.y < -2) ResetPlayer();
        //if(!phoneIsConnected && Input.GetKeyDown(KeyCode.Space)) Jump();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(phoneIsConnected){
            dir.x = Input.acceleration.x - calibrateDir.x;
            dir.z = Input.acceleration.y - calibrateDir.z;

        }else{
            dir.x = Input.GetAxis("Horizontal");
            dir.z = Input.GetAxis("Vertical");
        }
        rb.AddForce(dir * 10);
    }

    public void ResetPlayer(){
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        this.transform.position = startPosition;
    }

    public void Jump()
    {
        if(isGrounded && canJump) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            aud.PlayOneShot(jump);
        }
    }

    public void CalibrateTilt(){
        Debug.Log("Calibrate");

        calibrateDir.x = Input.acceleration.x;
        calibrateDir.z = Input.acceleration.y;
    }

    
        

    
     private void OnCollisionEnter(Collision other) 
        {
            if(other.gameObject.CompareTag("Ground")){
                isGrounded=true;
                if(canJump) jumpButton.interactable = true;
            }
            
        }
    

     void OnCollisionExit(Collision other) 
     {
         if(other.gameObject.CompareTag("Ground")){
                isGrounded=false;
                jumpButton.interactable = false;
            }
         
     }
    

     void OnTriggerEnter(Collider other) {
         {
             if(other.gameObject.CompareTag("Coin")){
                 score += coinScore;
                 scoreText.text = "Score: " + score;
                 aud.PlayOneShot(coin);
                 Destroy(other.gameObject);
             }
         }
         if (other.gameObject.CompareTag("Jump")){
             canJump = true;
             aud.PlayOneShot(jumpCap);
             Destroy(other.gameObject);
         }
     }
}   
    
