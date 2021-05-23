using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTextBox : MonoBehaviour
{
    public GameObject text;
    
    public void setText(string textString)
    {
        text.GetComponent<UnityEngine.UI.Text>().text = textString;
    }
    void Start() { }
}
