using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class buttonText : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField inputField;
    public void buttonPressed(){
        inputField.text += gameObject.name;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
