using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOver : MonoBehaviour
{
    public AudioClip audioClip;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        audioSource.Play();
    }
}
