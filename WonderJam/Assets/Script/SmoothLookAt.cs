//SmoothLookAt.cs
//Written by Jake Bayer
//Written and uploaded November 18, 2012
//This is a modified C# version of the SmoothLookAt JS script.  Use it the same way as the Javascript version.

using UnityEngine;
using System.Collections;

///<summary>
///Looks at a target
///</summary>
[AddComponentMenu("Camera-Control/Smooth Look At CS")]
public class SmoothLookAt : MonoBehaviour
{
    public Transform target;        //an Object to lock on to
    public float damping = 6.0f;    //to control the rotation 

    private Transform _myTransform;
    private bool smooth = true;

    void Awake()
    {
        _myTransform = transform;
    }

    void LateUpdate()
    {
        if (target)
        {
            if (smooth)
            {
                Vector3 vecUp = target.position;
                vecUp.y += 1f;
                //Look at and dampen the rotation
                Quaternion rotation = Quaternion.LookRotation(vecUp - _myTransform.position);
                _myTransform.rotation = Quaternion.Slerp(_myTransform.rotation, rotation, Time.deltaTime * damping);
            }
            else
            { //Just look at
                _myTransform.rotation = Quaternion.FromToRotation(-Vector3.forward, (new Vector3(target.position.x, target.position.y, target.position.z) - _myTransform.position).normalized);

            }
        }
        else
        {
            GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject go in gos)
            {
                if (go.GetPhotonView().isMine)
                {
                    Transform[] ts = go.GetComponentsInChildren<Transform>();
                    foreach( Transform t in ts)
                    {
                        if(t.gameObject.name== "PlayerCameraTarget")
                            target =  t;
                    }
                }
            }
        }
    }
}