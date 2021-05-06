using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 0.4f);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<BombermanPlayerMovement>().Hurt();
        }
        
        if (collision.gameObject.tag == "BreakWall")
        {
            //run code to hurt wall
            collision.gameObject.GetComponent<BreakWallScript>().DamageWall();
        } 

        if(collision.gameObject.tag == "PowerUp")
        {
            
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Bomb")
        {
            collision.gameObject.GetComponent<BombScript>().Explode();
            //Debug.Log("Explosion noises");
        }

        this.transform.Translate(new Vector3(0, 0, -1));
    }
}
