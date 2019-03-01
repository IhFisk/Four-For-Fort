using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressureAnim : MonoBehaviour
{
    public bool isPressured;

    SphereCollider plateCollider;

    // Start is called before the first frame update
    void Start()
    {
        plateCollider = GetComponent<SphereCollider>();
        isPressured = false;
        Debug.Log("enyter");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        isPressured = true;
        Debug.Log("enyter");
        PlatePressured();
    }

    private void OnTriggerExit(Collider other)
    {
        isPressured = false;
        PlateDepressured();
    }

    void PlatePressured()
    {
        transform.localScale += new Vector3(0, -0.2f, 0);
        // ajouter un petit son d'activation sympathique
    }

    void PlateDepressured()
    {
        transform.localScale += new Vector3(0, 0.2f, 0);
        // ajouter (peut-etre) un petit son de désactivation sympathique
    }
}
