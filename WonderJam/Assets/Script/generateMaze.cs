/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateMaze : MonoBehaviour
{
    public GameObject objectToInstance;
    public int lines;
    public int columns;
    public Vector3 direction;
    
    private Vector3 baseTransform = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        baseTransform = transform.position;

        for (int i = 0; i < lines; i++)
        {
            transform.position = new Vector3(baseTransform.x, baseTransform.y, baseTransform.z);
            for (int j = 0; j < columns; j++)
            {
                Instantiate(objectToInstance, transform.position, Quaternion.identity);
                transform.position += new Vector3(direction.x, 0, 0);
            }
            transform.position += new Vector3(0, 0, direction.z);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateMaze : MonoBehaviour
{
    public int lines = 1;
    public int columns = 1;

    public int[,] matrice;

    // Start is called before the first frame update
    void Start()
    {
        matrice = new int[lines, columns];
        generateMazeRand();

    }

    public void generateMazeRand()
    {
   
        // si on est à l'extrémité gauche [j(min)] ou droite [j(max)], on vérifie la case [i-1][j]
        // si on est entre j(min) et j(max), on vérifie les cases [i-1][j-1]
        // on ne doit pas avoir plus de deux voisins [i+1][j] ou [i][j+1] / [i][j-1]
        // il faut au moins une case visible par ligne
        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrice[i, j] = 0;
            }
        } // fin des lignes


        int savecol = 0, savelines = 0;
        bool init = false;

        int count = 0;


        while (savelines != lines - 1)
        {
            Debug.Log("<color=red>" + savelines + "</color> " + lines);

            if (!init)
            {
                savecol = Random.Range(0, columns);
                matrice[savelines, savecol] = 1; // initialisation premiere case
                savelines++;
                matrice[savelines, savecol] = 1; // initialisation premiere case
                init = true;
            }
            int choixchemin = Random.Range(0, 3);
            switch (choixchemin)
            {
                case 0:
                    // gauche
                    if (savecol != 0 && matrice[savelines, savecol - 1] != 1 && matrice[savelines-1, savecol - 1] != 1)
                    {
                        savecol--;
                        matrice[savelines, savecol] = 1;
                    }
                    break;
                case 1:
                    // haut
                        savelines++;
                        matrice[savelines, savecol] = 1;
                    break;
                case 2:
                    // droite
                    if (savecol < columns - 1 && matrice[savelines, savecol + 1] != 1 && matrice[savelines - 1, savecol + 1] != 1)
                    {
                        savecol++;
                        matrice[savelines, savecol] = 1;
                    }
                    break;
                default:
                    Debug.Log("Erreur dans le choix du chemin");
                    break;
            } // fin choix chemin

            count++;
            if(count > 100)
            {
                savelines = lines;
            }            

        }

        /*string s = "\n";
        for (int i = 0; i < lines; i++)
        {
            s = "";

            for (int j = 0; j < columns; j++)
            {
                s += matrice[i, j] + " ";
                matrice[i, j] = 0;
            }

            Debug.Log(s);
        } // fin des lignes*/
        
    }

    public int[,] getMaze()
    {
        return matrice;
    }
}