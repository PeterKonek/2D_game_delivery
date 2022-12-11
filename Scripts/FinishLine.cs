using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour


{
    [SerializeField] float sceneReload = 1f;
    [SerializeField] ParticleSystem finishEffect;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<PlayerController>().DisableControls();
            finishEffect.Play();
            Invoke("ReloadScene", sceneReload);
            GetComponent<AudioSource>().Play();
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
