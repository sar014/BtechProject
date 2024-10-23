using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare1 : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    private void Start() 
    {
        animator = this.GetComponent<Animator>();
        audioSource = this.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Reach")) 
        {
            audioSource.PlayOneShot(audioSource.clip);
            animator.SetTrigger("Play");  // Start the animation
            StartCoroutine(StopAnimation());  // Call coroutine to stop after 5 seconds
        }
    }

    IEnumerator StopAnimation() 
    {
        yield return new WaitForSeconds(10f);  
        animator.SetTrigger("Stop");  // Stop the animation after waiting
    }
}
