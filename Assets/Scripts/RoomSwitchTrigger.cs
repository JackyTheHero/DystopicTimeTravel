using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitchTrigger : MonoBehaviour
{
    public List<Vector3> spawnPoints;

    public GameObject[] cameras;

    void Start()
    {
        SetSpawnPoints();
        SetCineCamera(0);

        //if there are no Spawn points set in the scene, the only spawnpoint will be set to the current player position
        if(spawnPoints.Count == 0)
        {
            float x = GameObject.FindGameObjectWithTag("Player").transform.position.x;
            float y = GameObject.FindGameObjectWithTag("Player").transform.position.y;
            spawnPoints.Add(new Vector2(x,y));
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //col.GetComponent<TheReaper>().DiePlayerDie();
            
            col.transform.position = GetSpawnPoint();
            int roomNumber = GameObject.Find("RoomWatcher").GetComponent<RoomWatcher>().roomNumber;

            SetCineCamera(roomNumber);
            
        }
    }

    private void SetSpawnPoints()
    {
        GameObject[] arr = GameObject.FindGameObjectsWithTag("PlayerSpawn");

        for(var i = 0; i < arr.Length; i++)
        {
            spawnPoints.Add(arr[i].transform.position);
        }
    }

    private Vector3 GetSpawnPoint()
    {
        switch (name)
        {
            case "doorSwitcher1to2":
                GameObject.Find("RoomWatcher").GetComponent<RoomWatcher>().SetRoomNumber(1);
                return spawnPoints[0];

            case "doorSwitcher2to1":
                GameObject.Find("RoomWatcher").GetComponent<RoomWatcher>().SetRoomNumber(0);
                return spawnPoints[1];

            case "doorSwitcher2to3":
                GameObject.Find("RoomWatcher").GetComponent<RoomWatcher>().SetRoomNumber(2);
                return spawnPoints[2];

            default:
                return GameObject.FindGameObjectWithTag("Player").transform.position;
        }
    }

    private void SetCineCamera(int roomNumber)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].SetActive(i == roomNumber);
        }
    }
}
