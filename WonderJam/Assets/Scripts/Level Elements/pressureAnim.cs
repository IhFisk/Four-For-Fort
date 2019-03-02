using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressureAnim : MonoBehaviour
{
    Material[] plateMat;
    BoxCollider plateCollider;
    Color defaultColor;
    bool isPressured;

    public GameObject objectToActive;

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
        PlatePressured();
    }

    private void OnTriggerExit(Collider other)
    {
        isPressured = false;
        PlateDepressured();
    }

    void PlatePressured()
    {
        transform.localScale += new Vector3(0, -0.1f, 0);
        plateMat[0].color = Color.green;
        plateMat[1].color = Color.green;

        activeGameObject();
        // ajouter un petit son d'activation sympathique
    }

    void PlateDepressured()
    {
        transform.localScale += new Vector3(0, 0.1f, 0);
        plateMat[0].color = defaultColor;
        plateMat[1].color = defaultColor;

        // ajouter (peut-etre) un petit son de désactivation sympathique
    }

    void activeGameObject()
    {
        objectToActive.GetComponent<Activate>().setActive(true);
    }
}
