using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerView")
        {
            Debug.Log($"---{this.name}--- was hit by ---{col.gameObject.name}--- !");
        }
    }
}
