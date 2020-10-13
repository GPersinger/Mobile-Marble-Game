using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeLevel : MonoBehaviour
{
    [Tooltip("The Name of the scene you want to go to.")]
    public string destination;
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            if(destination == "") destination = "Main Menu";
            UnityEngine.SceneManagement.SceneManager.LoadScene(destination);
        }
    }
}
