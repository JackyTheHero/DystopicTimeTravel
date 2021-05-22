using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    RaycastHit2D hit;
    Ray ray;

    public float playerSpeed;

    Collider2D viewingCone;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 0.05f;

        viewingCone = this.GetComponentInChildren<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            keyActionSelector();
        }

        //Not used right now, no point and click
        /*
        if (Input.GetMouseButtonUp(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);

            if (hit.transform.tag == "mouseInteractive")
            {
                Debug.Log($"hit {hit.transform.name}");
            }
        }
        */
    }

    private void RotateViewingCone(Quaternion direction)
    {
        this.transform.GetChild(0).transform.rotation = direction;
    }

    private void keyActionSelector()
    {
        if (Input.GetKey("d"))
        {
            this.transform.position += new Vector3(playerSpeed, 0, 0);
            RotateViewingCone(Quaternion.Euler(0, 0, 180));
        }

        if (Input.GetKey("a"))
        {
            this.transform.position += new Vector3(-playerSpeed, 0, 0);
            RotateViewingCone(Quaternion.Euler(0, 0, 0));
        }

        //search for other solution, cone is deformed
        if (Input.GetKey("w"))
        {
            RotateViewingCone(Quaternion.Euler(0, 0, -90));
        }

        //search for other solution, cone is deformed
        if (Input.GetKey("s"))
        {
            RotateViewingCone(Quaternion.Euler(0, 0, 90));
        }
    }
}
