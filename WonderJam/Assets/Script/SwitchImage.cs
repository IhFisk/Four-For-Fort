using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SwitchImage : MonoBehaviour
{


    public float deltaTime = 0.2f;
    public Sprite baseSprite;
    public Sprite spriteToSwitch;

    private Image imageComponent;

    private float currentTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        imageComponent = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= deltaTime)
        {
            imageComponent.sprite = spriteToSwitch;
            currentTime = 0.0f;
        }
        else
        {
            imageComponent.sprite = baseSprite;
        }
    }
}
