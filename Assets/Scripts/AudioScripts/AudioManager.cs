using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    private void Update() {
        if(SceneManager.GetActiveScene().buildIndex==2)
        {
            audioSource.Stop(); 
        }
    }
}
