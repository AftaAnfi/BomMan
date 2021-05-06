using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombermanPlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public GameObject bombPref;
    public int bombermanBlastRadius;
    public int bombAmount;
    public int placedBombs;
    public GameObject bombAmountUI;
    public GameObject bombRadiusUI;
    public GameObject movementSpeedUI;

    // Start is called before the first frame update
    void Start()
    {
        bombAmountUI = GameObject.Find("BombAmountUI");
        bombRadiusUI = GameObject.Find("BombRadiusUI");
        movementSpeedUI = GameObject.Find("MovementSpeedUI");

        bombAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        bombAmountUI.GetComponent<Text>().text = ("x" + bombAmount.ToString());
        bombRadiusUI.GetComponent<Text>().text = ("x" + bombermanBlastRadius.ToString());
        movementSpeedUI.GetComponent<Text>().text = ("x" + Mathf.RoundToInt(((movementSpeed - 3) / 0.6f)).ToString());
       


        if (bombermanBlastRadius > 8)
        {
            bombermanBlastRadius = 8;
        }

        if (movementSpeed > 6)
        {
            movementSpeed = 6;
        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(Time.deltaTime * movementSpeed, 0, 0));
        } else if (Input.GetKey (KeyCode.A))
        {
            transform.Translate(new Vector3(Time.deltaTime * -movementSpeed, 0, 0));
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, Time.deltaTime * movementSpeed, 0));
        } else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, Time.deltaTime * -movementSpeed, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if(placedBombs < bombAmount)
            {
                Instantiate(bombPref, new Vector3(Mathf.RoundToInt(this.transform.position.x), Mathf.RoundToInt(this.transform.position.y), 0.5f), this.transform.rotation);
                placedBombs++;
            }
        }
        
    }

    public void Hurt()
    {
        Debug.Log("Ouch!");
    }

}
