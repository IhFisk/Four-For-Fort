using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawnRandom : MonoBehaviour
{

    public GameObject[] crated;

    public GameObject[] plates;


    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0, 2);
        int j = Random.Range(0, 2);        

        plates[i].GetComponent<pressureAnim>().setGameObject(crated[j]);

        i = i == 0 ? 1 : 0;
        j = j == 0 ? 1 : 0;

        plates[i].GetComponent<pressureAnim>().setGameObject(crated[j]);


    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject go in crated)
        {
            if (go.GetComponent<Activate>().getActive())
            {
                foreach (GameObject plate in plates)
                {
                    plate.GetComponent<pressureAnim>().setGameObject(null);
                }
            }
        }
    }
}
