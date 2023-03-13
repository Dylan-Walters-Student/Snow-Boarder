using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float pause = 0.5f;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioClip crashSFX;
    private bool isPlayed = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && isPlayed)
        {
            isPlayed = false;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", pause);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
