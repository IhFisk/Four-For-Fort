using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayUi : MonoBehaviour
{
    public TextMeshPro textMesh;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("PlayBtn"))
                {
                    textMesh = hit.collider.gameObject.GetComponent<TextMeshPro>();
                    StartGame();
                }
            }

        }
    }

    public void StartGame()
    {
        textMesh.color = Color.blue;
    }
}
