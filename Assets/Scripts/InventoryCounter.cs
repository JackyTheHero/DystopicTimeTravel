using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCounter : MonoBehaviour
{
    private static int counter;

    private void Start()
    {
        counter = 0;
    }

    public void CountUp()
    {
        ++counter;
        this.GetComponent<Text>().text = counter.ToString();
    }

    public void CountDown()
    {
        --counter;
        this.GetComponent<Text>().text = counter.ToString();
    }

    public int GetCount()
    {
        return counter;
    }
}
