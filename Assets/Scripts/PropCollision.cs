using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropCollision : MonoBehaviour
{
    private bool activateable;
    public GameObject textBox;
    private GameObject eee;
    public string textString = "UwU";

    void Start()
    {
        activateable = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerView")
        {
            eee = Instantiate(textBox ? textBox : GameObject.Find("TextBox"), this.transform);
            eee.GetComponent<ShowTextBox>().setText(textString);
            activateable = true;
            eee.transform.localScale = new Vector3(1,1,1);
            eee.transform.position = this.transform.position + new Vector3(0,5,0);
            Debug.Log($"---{this.name}--- was hit by ---{col.gameObject.name}--- !");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerView")
        {
            activateable = false;
            GameObject.Destroy(eee);
        }
    }
}
