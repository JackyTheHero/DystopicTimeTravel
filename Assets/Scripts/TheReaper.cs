using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheReaper : MonoBehaviour
{
    private static List<GameObject> Leichenplatz;
    GameObject Leiche;

    void Start()
    {
        SetLeichenSpawnPoints();
    }

    public void DiePlayerDie()
    {
        Leiche = Instantiate(this.gameObject,GameObject.Find("Leichenhalle").transform);
        PositionTheLeiche();
        transform.position = GameObject.FindGameObjectWithTag("StartSpawn").transform.position;
    }

    private void SetLeichenSpawnPoints()
    {
        GameObject[] arr;

        arr = GameObject.FindGameObjectsWithTag("Leiche");

        for(var i = 0; i < arr.Length; i++)
        {
            Leichenplatz.Add(arr[i]);
        }
    }

    private void PositionTheLeiche()
    {
        int rnd = (int)Random.value*Leichenplatz.Count;
        Leiche.transform.position = Leichenplatz[rnd].transform.position;
        Leiche.transform.rotation = Leichenplatz[rnd].transform.rotation;
        Leichenplatz.RemoveAt(rnd);
    }
}
