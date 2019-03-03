using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOver : MonoBehaviour
{
    public AudioClip audioClip;
    public Sprite playOver;

    private AudioSource audioSource;
    private Canvas playCanvas;
    private Image playImage;
    private Sprite notOver;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        playCanvas = GetComponentInChildren<Canvas>();
        playImage = playCanvas.GetComponentInChildren<Image>();
        notOver = playImage.sprite;
    }

    private void OnMouseEnter()
    {
        audioSource.Play();
        playImage.sprite = playOver;
    }

    private void OnMouseExit()
    {
        playImage.sprite = notOver;
    }
}
