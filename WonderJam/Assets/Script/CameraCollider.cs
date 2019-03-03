using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used with CameraController for a Camera GameObject and
/// prevent this camera to go through other GameObjects, except GameObjects
/// with the given tags.
/// </summary>
public class CameraCollider : MonoBehaviour
{
    [Tooltip("The min distance the camera can travel from target")]
    public float minDistance = 0.5f;
    [Tooltip("The max distance the camera can travel from target")]
    public float maxDistance = 3.0f;
    [Tooltip("Camera movement smoothing to be applied")]
    public float smooth = 15.0f;
    [Tooltip("Offset to be applied between the camera and a collider")]
    public float collisionDistanceOffset = 1f;
    [Tooltip("Distance between cam and target in which hide target rendering")]
    public float clippingDistance = 0.5f;
    [Tooltip("Camera target")]
    public GameObject target;
    [Tooltip("Tags to be ignored by the collider")]
    public string[] ignoreTags;

    private Vector3 dollyDirection;
    private float distance;
    private bool hitten;
    private ArrayList ignoredTagsList;
    private Renderer[] renderers;

    void Awake()
    {
        //Init vars
        dollyDirection = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;

        //Construct an ArrayList from ingoreTags for a more efficient handling
        ignoredTagsList = new ArrayList();
        for (int i = 0; i < ignoreTags.Length; i++)
        {
            ignoredTagsList.Add(ignoreTags[i]);
        }

        if (!target)
        {
            GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject go in gos)
            {
                if (go.GetPhotonView().isMine)
                {
                    Transform[] ts = go.GetComponentsInChildren<Transform>();
                    foreach (Transform t in ts)
                    {
                        if (t.gameObject.name == "PlayerCameraTarget")
                            target = t.gameObject;
                    }
                }
            }

        }
        renderers = target.GetComponentsInChildren<Renderer>();
    }

    //cat.GetComponent<Renderer>().enabled = false;

    void FixedUpdate()
    {
        //Get desired cam pos
        Vector3 desiredCamPos = transform.parent.TransformPoint(dollyDirection * (maxDistance + collisionDistanceOffset));

        //Check if there's something between camera and camera referential
        RaycastHit hit;
        hitten = Physics.Linecast(transform.parent.position, desiredCamPos, out hit);
        if (hitten)
        {
            if (hit.collider && !ignoredTagsList.Contains(hit.collider.tag)) //Check if hitten object is ignored
            {
                distance = Mathf.Clamp(hit.distance - collisionDistanceOffset, minDistance, maxDistance);
                Debug.DrawLine(transform.parent.position, hit.point, Color.red);
            }
        }
        else
            distance = maxDistance;

        //Apply camera position correction
        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDirection * distance, smooth * Time.deltaTime);

        //Disable rendering if too close
        if (distance <= clippingDistance)
            targetRender(false);
        else
            targetRender(true);

        //Debug lines
        if (hitten)
            Debug.DrawLine(hit.point, transform.position, Color.yellow);
        else
            Debug.DrawLine(transform.position, transform.parent.position, Color.green);
    }

    void targetRender(bool enabled)
    {
        for (int i = 0; i < renderers.Length; i++)
            renderers[i].enabled = enabled;
    }
}