using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playOver : MonoBehaviour
{
    public Sprite over;
    private Image imagePlay;
    private Sprite notOver;
    public bool isOvered = false;

    // Start is called before the first frame update
    void Start()
    {
        imagePlay = GetComponent<Image>();
        notOver = imagePlay.sprite;
    }
        

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        isOvered = true;
        imagePlay.sprite = over;
    }

    private void OnMouseExit()
    {
        isOvered = false;
        imagePlay.sprite = notOver;
    }
}
