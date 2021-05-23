using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropCollision : MonoBehaviour
{
    private bool activateable;
    public GameObject textBox;
    private GameObject eee;
    private GameObject eeeIn;
    public string textString = "UwU";
    private bool wasActivatedOnce;
    private bool eIn;
    private bool isNearest;

    void Start()
    {
        wasActivatedOnce = false;
        eIn = false;
        activateable = false;
        isNearest = false;

        eee = Instantiate(GameObject.Find("EEE"), this.transform);
        eee.transform.localScale = new Vector3(1, 1, 1);
        eee.transform.position = this.transform.position + new Vector3(0, 5, 0);
        eee.SetActive(false);

        eeeIn = Instantiate(textBox ? textBox : GameObject.Find("TextBox"), this.transform);
        eeeIn.GetComponent<ShowTextBox>().setText(textString);
        eeeIn.transform.localScale = new Vector3(1, 1, 1);
        eeeIn.transform.position = this.transform.position + new Vector3(0, 5, 0);
        eeeIn.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerView")
        {
            GameObject.Find("RoomWatcher").GetComponent<RoomWatcher>().AddToNearProps(this.gameObject);
            //Debug.Log($"---{this.name}--- was hit by ---{col.gameObject.name}--- !");
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerView")
        {
            if (GameObject.Find("RoomWatcher").GetComponent<RoomWatcher>().IsNearestProp(this.gameObject))
            {
                isNearest = true;
                activateable = true;

                if (!eIn)
                {
                    eee.SetActive(true);
                }
            }
            else
            {
                isNearest = false;
                eee.SetActive(false);
                eeeIn.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (isNearest)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (activateable && !eIn && this.tag == "PuzzleTree") {
                    Debug.Log("Hello Tree!");
                    eee.SetActive(false);
                    eIn = true;

                    GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;

                    if(this.name == "baum Auﬂenbereich")
                    {
                        GameObject.Find("PuzzleCanvas").GetComponent<Canvas>().enabled = true;
                    }

                    if (this.name == "baum Labor")
                    {
                        GameObject.Find("PuzzleCanvas2").GetComponent<Canvas>().enabled = true;
                    }

                    if (this.name == "Yggdrasil")
                    {
                        GameObject.Find("PuzzleCanvas3").GetComponent<Canvas>().enabled = true;
                    }

                }
                else if (eIn && this.tag == "PuzzleTree")
                {
                    eeeIn.SetActive(false);

                    activateable = true;

                    eee.SetActive(true);

                    eIn = false;

                    GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;

                    if (this.name == "baum Auﬂenbereich")
                    {
                        GameObject.Find("PuzzleCanvas").GetComponent<Canvas>().enabled = false;
                    }

                    if (this.name == "baum Labor")
                    {
                        GameObject.Find("PuzzleCanvas2").GetComponent<Canvas>().enabled = false;
                    }

                    if (this.name == "Yggdrasil")
                    {
                        GameObject.Find("PuzzleCanvas3").GetComponent<Canvas>().enabled = false;
                    }
                }


                if (activateable && !eIn && this.tag == "Leiche")
                {
                    eee.SetActive(false);

                    if (!wasActivatedOnce)
                    {
                        eeeIn.GetComponent<ShowTextBox>().setText(
                                GameObject.Find("Player").GetComponent<TheReaper>().text[
                                    GameObject.Find("RoomWatcher").GetComponent<RoomWatcher>().textCounter++]);
                            
                        GameObject.Find("InvCounter").GetComponent<InventoryCounter>().CountUp();
                    }
                    
                    eIn = true;

                    eeeIn.SetActive(true);

                    
                    if (!wasActivatedOnce)
                    {
                        wasActivatedOnce = true;
                    }
                }

                else if (eIn && this.tag == "Leiche")
                {
                    eeeIn.SetActive(false);

                    activateable = true;

                    eee.SetActive(true);

                    eIn = false; 
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        GameObject.Find("RoomWatcher").GetComponent<RoomWatcher>().DeleteFromNearProps(this.gameObject);

        if (col.gameObject.tag == "PlayerView")
        {
            activateable = false;
            eIn = false;

            eee.SetActive(false);
            eeeIn.SetActive(false);
        }
    }
}
