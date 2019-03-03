using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTowerTogether : MonoBehaviour
{


    public GameObject tower1;
    public GameObject tower2;

    public float coolDown = 3.0f;
    private float timer = 0.0f;


    public float speed = 1.0f;
    public float amount = 1.0f;

    public float valueTpY = 10.0f;

    private Vector3 startingPos;
    private Vector3 startingPos2;


    // Start is called before the first frame update
    void Start()
    {
        startingPos.x = tower1.transform.position.x;
        startingPos.y = tower1.transform.position.y;
        startingPos.z = tower1.transform.position.z;

        startingPos2.x = tower2.transform.position.x;
        startingPos2.y = tower2.transform.position.y;
        startingPos2.z = tower2.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        bool playerInside1 = tower1.GetComponent<DetectPlayer>().getSometinhInside();
        bool playerInside2 = tower2.GetComponent<DetectPlayer>().getSometinhInside();

        if ((playerInside1 && !playerInside2) || (!playerInside1 && playerInside2))
        {
            timer += Time.deltaTime;

            Shake();

            if(timer > coolDown)
            {
                setComponent(tower1, true);
                setComponent(tower2, true);
            }
        }

        if(!playerInside1 && !playerInside2)
        {
            timer = 0.0f;
        }


        if(tower1.transform.position.y < startingPos.y - valueTpY)
        {
            timer = 0.0f;

            setComponent(tower1, false);
            setComponent(tower2, false);

            tower1.transform.position = startingPos;
            tower2.transform.position = startingPos2;
        }

    }


    void Shake()
    {
        float shakeValue = Mathf.Sin(Time.time * speed) * amount;


        Vector3 v = new Vector3(startingPos.x + shakeValue, tower1.transform.position.y, tower1.transform.position.z);

        tower1.transform.position = v;


        Vector3 v2 = new Vector3(startingPos2.x + shakeValue, tower2.transform.position.y, tower2.transform.position.z);

        tower2.transform.position = v2;
    }


    private void setComponent(GameObject go, bool new_value)
    {
        go.GetComponent<Rigidbody>().useGravity = new_value;
        go.GetComponent<Rigidbody>().isKinematic = !new_value;
    }
}
