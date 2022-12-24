using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadDelay = 2f;
    [SerializeField] ParticleSystem yellowFinishEffect;
    [SerializeField] ParticleSystem pinkFinishEffect;
    [SerializeField] ParticleSystem blueFinishEffect;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            yellowFinishEffect.Play();
            pinkFinishEffect.Play();
            blueFinishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", loadDelay);
            
        }
    }

    private void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
