using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropCollision : MonoBehaviour
{
    private bool activateable;
    private GameObject eee;

    void Start()
    {
        eee = new GameObject();
        activateable = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerView")
        {
             eee = Instantiate(GameObject.Find("EEE"),this.transform);
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
