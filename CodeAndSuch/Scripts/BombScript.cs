using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public GameObject blastPref;
    public int blastRadius;
    GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");

        blastRadius = FindObjectOfType<BombermanPlayerMovement>().bombermanBlastRadius;
        //Destroy(this.gameObject, 2f);
        StartCoroutine("BombBlast");
    }
    

    // Update is called once per frame
    void Update()
    {

        if (blastRadius > 8) {
            blastRadius = 8;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") {
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    IEnumerator BombBlast()
    {
        yield return new WaitForSeconds(2f);

        Explode();

    }

    public void Explode() {

        this.GetComponent<SpriteRenderer>().enabled = false;

        //spawn one at bomb origin
        Instantiate(blastPref, new Vector3(this.transform.position.x, this.transform.position.y, 0f), this.transform.rotation);

        //if wall above and below
        if ((transform.position.x % 2 == 0)) {

            for (int i = 1; i < (blastRadius + 1); i++) {

                //spawn right
                if((this.transform.position.x + i < 12)) {

                    Instantiate(blastPref, new Vector3(this.transform.position.x + i, this.transform.position.y, 0f), this.transform.rotation);
                }

                if ((this.transform.position.x - i > -12)) {

                    Instantiate(blastPref, new Vector3(this.transform.position.x - i, this.transform.position.y, 0f), this.transform.rotation);
                }
            }

        //if wall is to the left and right
        } else if ((transform.position.y % 2 == 0)) {

            for (int i = 1; i < (blastRadius + 1); i++) {

                 //up
                if ((this.transform.position.y + i < 8)) {

                    Instantiate(blastPref, new Vector3(this.transform.position.x, this.transform.position.y + i, 0f), this.transform.rotation);
                }

                //down
                if ((this.transform.position.y - i > -8)) {

                    Instantiate(blastPref, new Vector3(this.transform.position.x, this.transform.position.y - i, 0f), this.transform.rotation);
                }
            }
        }

        else {
             
            //all 4
            for (int i = 1; i < (blastRadius + 1); i++) {
                
                //right
                if ((this.transform.position.x + i < 12)) {

                    Instantiate(blastPref, new Vector3(this.transform.position.x + i, this.transform.position.y, 0f), this.transform.rotation);
                }

                //left
                if ((this.transform.position.x - i > -12)) {

                    Instantiate(blastPref, new Vector3(this.transform.position.x - i, this.transform.position.y, 0f), this.transform.rotation);
                }

                //up 
                if ((this.transform.position.y + i < 8)) {

                    Instantiate(blastPref, new Vector3(this.transform.position.x, this.transform.position.y + i, 0f), this.transform.rotation);
                }

                //down
                if ((this.transform.position.y - i > -8)) {

                    Instantiate(blastPref, new Vector3(this.transform.position.x, this.transform.position.y - i, 0f), this.transform.rotation);
                }
            }
        }

        playerObj.GetComponent<BombermanPlayerMovement>().placedBombs--;

        Destroy(this.gameObject);
        StopCoroutine("BombBlast");
    }

}
