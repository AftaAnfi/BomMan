using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerate : MonoBehaviour
{
    public GameObject greenGroundPrefab;
    public GameObject wallPrefab;
    public GameObject playerPref;
    public GameObject breakwallPref;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWallsAndGround();
        SpawnPlayer();
    }


    void Update()
    {
        
    }
   
    void SpawnPlayer()
    {
        Instantiate(playerPref, new Vector3(-11f, -7f, 0), this.transform.rotation) ;
    }


    void SpawnWallsAndGround()
    {
        for (int i = -12; i < 13; i++)
        {
            for (int j = -8; j < 9; j++)
            {
                if (i == 12 || i == -12 || j == 8 || j == -8)
                {
                    Instantiate(wallPrefab, new Vector3(i, j, 0), this.transform.rotation, this.gameObject.transform);
                }
                else
                {


                    if (i % 2 == 0 && j % 2 == 0)
                    {
                        Instantiate(wallPrefab, new Vector3(i, j, 0), this.transform.rotation, this.gameObject.transform);
                    }
                    else
                    {

                        if ((i == -11 && j == -7) || (i == -11 & j == -6) || (i == -10 && j == -7))
                        {
                        } else
                        {

                        switch (Random.Range(1, 10))
                            {
                                case 1:
                                    //nothing
                                    break;
                                default:
                                    //spawn wall

                                     Instantiate(breakwallPref, new Vector3(i, j, 0), this.transform.rotation, this.gameObject.transform);
                                    break;
                            }


                        }

                          Instantiate(greenGroundPrefab, new Vector3(i, j, 1), this.transform.rotation, this.gameObject.transform);

                    }
                }


            }
        }

    }



}
