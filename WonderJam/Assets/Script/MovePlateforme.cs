using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlateforme : MonoBehaviour
{

    [SerializeField]
    Transform platform;

    [SerializeField]
    Transform startTransform;

    [SerializeField]
    Transform endTransform;

    [SerializeField]
    float plateformSpeed;

    Vector3 direction;
    Transform destination;
    


    // Start is called before the first frame update
    void Start()
    {
        SetDestination(startTransform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        platform.GetComponent<Rigidbody>().MovePosition(platform.position + direction * plateformSpeed * Time.fixedDeltaTime);

        if (Vector3.Distance(platform.position, destination.position) < plateformSpeed * Time.fixedDeltaTime)
        {
            SetDestination(destination == startTransform ? endTransform : startTransform);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Vector3 size = platform.GetComponent<BoxCollider>().size;
        Vector3 localSize = platform.localScale;
        Vector3 trueSize = new Vector3(size.x * localSize.x, size.y * localSize.y, size.z * localSize.z);

        Gizmos.DrawWireCube(startTransform.position, trueSize);


        Gizmos.color = Color.red;



        Gizmos.DrawWireCube(endTransform.position, trueSize);
    }

    void SetDestination(Transform dest)
    {
        destination = dest;
        direction = (destination.position - platform.position).normalized;
    }
}
