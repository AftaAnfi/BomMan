using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{

    private void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //give player powerup
        if (collision.gameObject.tag == "Player")
        {

            if(this.gameObject.name == "RadiusPowerup(Clone)")
            {
                if (collision.gameObject.GetComponent<BombermanPlayerMovement>().bombermanBlastRadius < 8)
                {
                     collision.gameObject.GetComponent<BombermanPlayerMovement>().bombermanBlastRadius++;
                     Destroy(this.gameObject);
                }
                else
                {
                    this.transform.Translate(new Vector3(0f, 0f, 0.2f));
                }




            } else if (this.gameObject.name == "MovementPowerup(Clone)")
            {
                if (collision.gameObject.GetComponent<BombermanPlayerMovement>().movementSpeed < 6)
                {
                    collision.gameObject.GetComponent<BombermanPlayerMovement>().movementSpeed += 0.6f;
                    Destroy(this.gameObject);
                } else
                {

                    this.transform.Translate(new Vector3(0f, 0f, 0.2f));
                }
            } else if (this.gameObject.name == "BombPowerup(Clone)")
            {
                if(collision.gameObject.GetComponent<BombermanPlayerMovement>().bombAmount < 8)
                {

                collision.gameObject.GetComponent<BombermanPlayerMovement>().bombAmount++;
                Destroy(this.gameObject);

                }

                this.transform.Translate(new Vector3(0f, 0f, 0.2f));
            }
                

           
        }
    }

    

}
