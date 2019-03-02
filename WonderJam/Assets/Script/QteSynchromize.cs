using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QteSynchromize : MonoBehaviour
{

    private Activate active;
    private float fillAmount = 0.0f;

    public Image fillImage;
    public Image otherImage;

    public moveBarriere door;

    private float cooldown = 0.2f;
    private float time = 0.0f;

    private bool terminate = false;

    // Start is called before the first frame update
    void Start()
    {
        active = GetComponent<Activate>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (!terminate)
        {
            time += Time.deltaTime;

            if (active.getActive())
            {
                GetComponentInParent<Canvas>().enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    incFillAmount(0.15f);
                }
            }
            else
            {
                GetComponentInParent<Canvas>().enabled = false;
            }


            if (time > cooldown)
            {
                incFillAmount(-0.1f);
                time = 0.0f;
            }
            fillImage.fillAmount = fillAmount;


            if(fillImage.fillAmount > 0.95 && otherImage.fillAmount > 0.95)
            {
                terminate = true;
                fillImage.fillAmount = 1.0f;
                otherImage.fillAmount = 1.0f;
                door.setTheDoorMovement(true);
            }

        }

    }


    void incFillAmount(float new_value)
    {
        fillAmount += new_value;

        if(fillAmount > 1)
        {
            fillAmount = 1.0f;
        }

        if (fillAmount < 0)
        {
            fillAmount = 0.0f;
        }
    }
    


}
