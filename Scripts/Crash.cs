using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    [SerializeField] float sceneReload = 0.5f;
    [SerializeField] ParticleSystem bonkHead;
    [SerializeField] ParticleSystem bonkBoard;
    [SerializeField] AudioClip bonkAudio;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground")  
        {
            FindObjectOfType<PlayerController>().DisableControls();
            Invoke("ReloadScene" , sceneReload );
            bonkHead.Play();
            GetComponent<AudioSource>().PlayOneShot(bonkAudio);
        }
        else if(other.tag == "Rock")
        {
            Invoke("ReloadScene" , sceneReload );
            bonkBoard.Play();
            GetComponent<AudioSource>().PlayOneShot(bonkAudio);
        }
    }

  
    
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
         
        
}
