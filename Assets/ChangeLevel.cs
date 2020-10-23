using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeLevel : MonoBehaviour
{
    AudioSource aud;
    public AudioClip goal;

    void Start(){
        aud = GameObject.Find("AudioSource").GetComponent<AudioSource>();
    }

    [Tooltip("The Name of the scene you want to go to.")]
    public string destination;
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            other.GetComponent<PlayerMovement>().ResetPlayer();
            aud.PlayOneShot(goal);
            GoToNextLevel();
        }
    }

    public void GoToNextLevel(){
        if(destination =="") destination = "Main Menu";
        UnityEngine.SceneManagement.SceneManager.LoadScene(destination);

    }
}
