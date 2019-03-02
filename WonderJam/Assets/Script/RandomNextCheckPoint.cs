using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNextCheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nextCheckpoint;
    public GameObject baseCheckPoint;

    private pressureAnim[] listPressurePlates;

    void Start()
    {
        listPressurePlates = GetComponentsInChildren<pressureAnim>();
        foreach (pressureAnim ps in listPressurePlates)
        {
            ps.setGameObject(baseCheckPoint);
        }

        listPressurePlates[Random.Range(0, listPressurePlates.Length - 1)].setGameObject(nextCheckpoint);
    }
    
}
