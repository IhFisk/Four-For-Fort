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

    private Vector2 startingPos;
    private Vector2 startingPos2;


    // Start is called before the first frame update
    void Start()
    {
        startingPos.x = tower1.transform.position.x;
        startingPos.y = tower1.transform.position.y;

        startingPos2.x = tower2.transform.position.x;
        startingPos2.y = tower2.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        bool playerInside1 = tower1.GetComponent<DetectPlayer>().getSometinhInside();
        bool playerInside2 = tower2.GetComponent<DetectPlayer>().getSometinhInside();
        Shake();


        if ((playerInside1 && !playerInside2) || (!playerInside1 && playerInside2))
        {
            timer += Time.deltaTime;

            Shake();

            if(timer > coolDown)
            {
                tower1.GetComponent<Rigidbody>().useGravity = true;
                tower2.GetComponent<Rigidbody>().useGravity = true;
                tower1.GetComponent<Rigidbody>().isKinematic = false;
                tower2.GetComponent<Rigidbody>().isKinematic = false;
            }
        }

        if(!playerInside1 && !playerInside2)
        {
            timer = 0.0f;
        }
    }


    void Shake()
    {
        Vector3 v = new Vector3(Mathf.Sin(Time.time * speed) * amount, tower1.transform.position.y, tower1.transform.position.z);

        tower1.transform.position = v;

         v = new Vector3(Mathf.Sin(Time.time * speed) * amount, tower2.transform.position.y, tower2.transform.position.z);

        tower2.transform.position = v;
    }
}
