using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomWatcher : MonoBehaviour
{
    public int roomNumber;
    public List<GameObject> nearProps;
    public int textCounter;

    // Start is called before the first frame update
    void Start()
    {
        roomNumber = 0;
        nearProps = new List<GameObject>();
        textCounter = 0;

        GameObject.Find("PuzzleCanvas").GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    public void SetRoomNumber(int rmNmbr)
    {
        roomNumber = rmNmbr;
    }

    public void AddToNearProps(GameObject gameObj)
    {
        nearProps.Add(gameObj);
    }

    public void DeleteFromNearProps(GameObject gameObj)
    {
        nearProps.Remove(nearProps.Find(obj=>obj.name == gameObj.name));
    }

    public bool IsNearestProp(GameObject gameObj)
    {
        int index = nearProps.IndexOf(nearProps.Find(obj => obj.name == gameObj.name));

        if (index == -1)
        {
            return false;
        }

        float x = nearProps[index].transform.position.x;
        float playerPosX = GameObject.FindGameObjectWithTag("Player").transform.position.x;

        

        for (var i = 0; i < nearProps.Count; i++)
        {
            if (i != index)
            {
                if (Mathf.Abs(nearProps[i].transform.position.x - playerPosX) < Mathf.Abs(x - playerPosX))
                {
                    return false;
                }
            }
        }
        return true;
    }

    void Update()
    {
        if (PuzzleManager.getSolvedPuzzle())
        {
            GameObject.Find("WinScreen").GetComponent<Canvas>().enabled = true;
        }
    }
}
