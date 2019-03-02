using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressureAnim : MonoBehaviour
{
    Material[] plateMat;
    BoxCollider plateCollider;
    GameObject activatingGo;
    Color defaultColor;
    bool isPressured;

    public GameObject[] objectsToActive;

    private GameObject thisObject;

    // Start is called before the first frame update
    void Start()
    {
        plateCollider = GetComponent<BoxCollider>();
        isPressured = false;
        plateMat = GetComponent<Renderer>().materials;
        defaultColor = plateMat[0].color;
    }

    public bool GetStatePressure()
    {
        return isPressured;
    }

    private void OnTriggerEnter(Collider other)
    {
        isPressured = true;
        activatingGo = other.gameObject;
        PlatePressured();
        thisObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        isPressured = false;
        //retirer le Go qui a activé ?? 
        PlateDepressured();
    }

    void PlatePressured()
    {
        transform.localScale += new Vector3(0, -0.1f, 0);
        plateMat[0].color = Color.green;
        plateMat[1].color = Color.green;

        //activeGameObject(true);
        activeGameObject(true);
        // ajouter un petit son d'activation sympathique
    }

    void PlateDepressured()
    {
        transform.localScale += new Vector3(0, 0.1f, 0);
        plateMat[0].color = defaultColor;
        plateMat[1].color = defaultColor;

        //activeGameObject(false);
        activeGameObject(false);
        // ajouter (peut-etre) un petit son de désactivation sympathique
    }

    void activeGameObject(bool new_active)
    {
        foreach (GameObject go in objectsToActive)
        {
            Activate acv = go.GetComponent<Activate>();
            acv.setActive(new_active);

            if (thisObject)
            {
                acv.setPlayer(thisObject);
            }
        }
    }

    public void setGameObject(GameObject objectToActive)
    {
        objectsToActive[0] = objectToActive;
    }
    
}