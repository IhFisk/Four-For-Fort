using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is handling the rotation of a camera around - and making it looking
/// at - a target. The rotation is directly read from mouse and controller
/// inputs and the referencial is placed at the given camera target
/// </summary>
public class CameraController : MonoBehaviour
{
    [Tooltip("The target wich the camera will look and look around.")]
    public GameObject cameraTarget;
    [Tooltip("Camera rotation speed depending on input speed.")]
    public float rotationSpeed = 120.0f;
    [Tooltip("Maximum angle the camera can go around X-axis below 0.")]
    public float maxDropAngle = 40.0f;
    [Tooltip("Sensitivity to be applied on inputs.")]
    public float sensitivity = 150.0f;
    [Tooltip("The max distance travelled by the camera during shaking from cam pos.")]
    public float shakingRange = 0.3f;
    [Tooltip("Speed of the shaking.")]
    public float shakingSpeed = 30.0f;
    [Tooltip("Attenuation speed, the greater it is, the faster it's damping.")]
    public float shakingDampingTime = 3f;
    [Tooltip("Shaking duration in seconds. This is independant from the shaking computing.")]
    public float shakingTime = 3f;
    [Tooltip("Attenuation speed, the greater it is, the faster it's damping.")]
    public float fovDampingTime = 6f;


    private float mouseX;
    private float mouseY;
    private Vector3 followPos;
    private float finalInputX;
    private float finalInputZ;
    private float rotX = 0.0f;
    private float rotY = 0.0f;
    private bool rotLockFlag = false;
    private bool shakeFlag = false;
    private float dampedShakingStartTime;
    private float shakingElapsedTime;
    private float nextFov = 45;
    private bool fovHasToBeenSet = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<CameraCollider>().enabled = true;

        //Init rotation values;
        resetCameraRotation();

        //Lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.G)) rotLockFlag = !rotLockFlag;
        //if (Input.GetKeyDown(KeyCode.E)) initDampedShaking();
        if(!cameraTarget)
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
                            cameraTarget = t.gameObject;
                    }
                }
            }

        }

        lerpFov();

        if (!rotLockFlag)
        {
            GetComponent<SmoothLookAt>().target = null;

            //Get inputs
            float inputX = Input.GetAxis("ControllerHorizontal");
            float inputZ = Input.GetAxis("ControllerVertical");
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");

            //Combine inputs
            finalInputX = inputX + mouseX;
            finalInputZ = inputZ + mouseY;

            //Apply rotation
            rotY += finalInputX * sensitivity * Time.deltaTime;
            rotX += finalInputZ * sensitivity * Time.deltaTime;

            //Avoid elevation to get too high or low
            rotX = Mathf.Clamp(rotX, -maxDropAngle, 90);

            //Convert rotations into a quaternion >> Unity engine computes rotations w/ them better
            Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);

            transform.rotation = localRotation;
        }
    }

    //LateUpdate is called after frames
    private void LateUpdate()
    {
        cameraUpdater();

        //Damped camera shaking
        if (shakeFlag)
        {
            if (Time.time > shakingElapsedTime + shakingTime)
                shakeFlag = !shakeFlag;
            else
                dampedShaking();
        }
    }

    /// <summary>
    /// Initiates or re-initiates a damped shaking process
    /// </summary>
    public void initDampedShaking()
    {
        if (!shakeFlag) shakeFlag = !shakeFlag;

        dampedShakingStartTime = Time.time;
        shakingElapsedTime = Time.time;
    }

    /// <summary>
    /// Places camera at the target's camera target GameObject and makes the camera looking at it.
    /// </summary>
    private void cameraUpdater()
    {
        float step = rotationSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, cameraTarget.transform.position, step);
    }

    /// <summary>
    /// Executes a damped shaking effect on the camera
    /// </summary>
    private void dampedShaking()
    {
        Vector3 pos = transform.position;
        float time = Time.time - dampedShakingStartTime;
        pos.y = pos.y + Mathf.Sin(time * shakingSpeed) * shakingRange * Mathf.Exp(-shakingDampingTime * time);
        transform.position = pos;
    }

    /**
     * @brief reset rot parameters for mouse input
     */
    private void resetCameraRotation()
    {
        //Init rotation values;
        Vector3 rot = transform.eulerAngles;

        Debug.Log("<color=blue>Rotation : " + rot + "</color>");

        rotX = rot.x;
        rotY = rot.y;
    }

    /**
     * @brief Lerp the fov to the next fov value
     * 
     **/
    private void lerpFov()
    {
        if (fovHasToBeenSet)
        {
            float fov = GetComponentInChildren<Camera>().fieldOfView;
            fov = Mathf.Lerp(fov, nextFov, Time.deltaTime * fovDampingTime);
            GetComponentInChildren<Camera>().fieldOfView = fov;
            if (fov >= nextFov - 0.1f && fov <= nextFov + 0.1f)
            {
                fovHasToBeenSet = false;
            }
        }
    }

    /**
     * @brief set the next fov value and prepare the lerpFov() method
     * @params value The fov value 
     **/
    public void setFov(float value)
    {
        nextFov = value;
        fovHasToBeenSet = true;
    }

}
