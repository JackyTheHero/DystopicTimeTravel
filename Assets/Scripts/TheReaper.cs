using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheReaper : MonoBehaviour
{
    private List<GameObject> Leichenplatz;
    GameObject Leiche;

    void Start()
    {
        Leichenplatz = new List<GameObject>();
        SetLeichenSpawnPoints();
    }

    public void DiePlayerDie()
    {
        Leiche = Instantiate(GameObject.Find("PrefabLeiche"), GameObject.Find("Leichenhalle").transform);
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
        int rnd = (int)Random.Range(0,Leichenplatz.Count);
        Leiche.transform.position = Leichenplatz[rnd].transform.position;
        Leiche.transform.rotation = Leichenplatz[rnd].transform.rotation;
        Leichenplatz.RemoveAt(0);
    }
}
