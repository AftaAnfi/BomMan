using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWallScript : MonoBehaviour
{
    public GameObject[] powerUpArray;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageWall()
    {

        StartCoroutine("SpawnPowerup");
    }


    IEnumerator SpawnPowerup()
    {
        yield return new WaitForSeconds(0.4f);

        switch (Random.Range(1, 10))
        {
            case 1:
                //spawn powerup
                Instantiate(powerUpArray[0], this.transform.position, this.transform.rotation);
                break;
            case 2:
                Instantiate(powerUpArray[1], this.transform.position, this.transform.rotation);
                break;
            case 3:
                Instantiate(powerUpArray[2], this.transform.position, this.transform.rotation);
                break;
            default:

                break;

        }


        Destroy(this.gameObject);


    }
}
