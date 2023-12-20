using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class caretPosition : MonoBehaviour
{
    public TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        inputField.caretBlinkRate = 1;
        inputField.caretWidth = 10;
    }

    public void caretUp(){
        inputField.caretPosition += 14;
    }

    public void caretDown(){
        inputField.caretPosition += 14;
    }

    public void caretLeft(){
        inputField.caretPosition += 14;
    }

    public void caretRight(){
        inputField.caretPosition += 14;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
