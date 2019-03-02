using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class moveBarriere : MonoBehaviour
{


    public Image fillBar1;
    public Image fillBar2;

    private bool moveTheDoor = false;

    private float cooldown = 0.05f;
    private float time = 0.0f;

    private Vector3 basePostion = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        basePostion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.y >= basePostion.y)
        {
            time += Time.deltaTime;
            if (time > cooldown )
            {
                transform.position -= new Vector3(0.0f, 0.05f, 0.0f);
                time = 0.0f;
            }
        }
    }

    public void incDoorPosition()
    {
        if (transform.position.y <= basePostion.y + 4.0f)
        {
            transform.position += new Vector3(0.0f, 0.3f, 0.0f);
        }
        else
        {
            fillBar1.fillAmount = 0;
            fillBar2.fillAmount = 0;
        }
    } 
}
