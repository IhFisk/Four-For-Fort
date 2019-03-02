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

    private float cooldown = 0.25f;
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
                foreach(GameObject go in active.activatingGos)
                {
                    if (go.GetComponent<PhotonView>())
                    {
                        if (go.GetPhotonView().isMine)
                        {
                            if (Input.GetKeyDown(KeyCode.E))
                            {
                                PhotonView photonView = PhotonView.Get(this);
                                photonView.RPC("incFillAmount", PhotonTargets.AllViaServer, 0.15f);
                                //incFillAmount(0.15f);
                            }
                        }
                    }
                }

            }
            else
            {
                GetComponentInParent<Canvas>().enabled = false;
            }


            if (time > cooldown)
            {
                PhotonView photonView = PhotonView.Get(this);
                photonView.RPC("incFillAmount", PhotonTargets.AllViaServer, -0.1f);
                time = 0.0f;
            }
            fillImage.fillAmount = fillAmount;


            if (fillImage.fillAmount > 0.95 && otherImage.fillAmount > 0.95)
            {
                terminate = true;
                fillImage.fillAmount = 1.0f;
                otherImage.fillAmount = 1.0f;
            }

        }
        else
        {
            if (active.getActive())
            {
                foreach (GameObject go in active.activatingGos)
                {
                    if (go.GetComponent<PhotonView>())
                    {
                        if (go.GetPhotonView().isMine)
                        {
                            if (Input.GetKeyDown(KeyCode.E))
                            {
                                door.incDoorPosition();
                            }
                        }
                    }
                }
            }
        }

    }

    [PunRPC]
    void incFillAmount(float new_value)
    {
        fillAmount += new_value;

        if (fillAmount > 1)
        {
            fillAmount = 1.0f;
        }

        if (fillAmount < 0)
        {
            fillAmount = 0.0f;
        }
    }



}
