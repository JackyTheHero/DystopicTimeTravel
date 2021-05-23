using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomWatcher : MonoBehaviour
{
    public int roomNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void SetRoomNumber(int rmNmbr)
    {
        roomNumber = rmNmbr;
    }
}
