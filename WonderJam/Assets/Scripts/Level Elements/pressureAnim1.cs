using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressureAnim1 : MonoBehaviour
{
    Material[] plateMat;
    BoxCollider plateCollider;
    ArrayList activatingGos;
    Color defaultColor;
    bool isPressured;

    public GameObject[] objectsToActive;

    // Start is called before the first frame update
    void Start()
    {
        plateCollider = GetComponent<BoxCollider>();
        isPressured = false;
        plateMat = GetComponent<Renderer>().materials;
        defaultColor = plateMat[0].color;
        activatingGos = new ArrayList();
    }


    public bool GetStatePressure()
    {
        return isPressured;
    }

    private void OnTriggerEnter(Collider other)
    {
        isPressured = true;
        activatingGos.Add(other.gameObject);
        PlatePressured();
    }

    private void OnTriggerExit(Collider other)
    {
        isPressured = false;
        foreach(GameObject go in activatingGos)
        {
            if (go == other.gameObject)
            {
                activatingGos.Remove(go);
                if (activatingGos.Count == 0)
                    PlateDepressured();
                break;
            }
                
        }
        //retirer le Go qui a activé ?? 
        
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
            acv.setActiveWithMultipleRef(new_active, activatingGos);
        }
    }

    public void setGameObject(GameObject objectToActive)
    {
        objectsToActive[0] = objectToActive;
    }
    
}