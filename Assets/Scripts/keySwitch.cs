using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class keySwitch : MonoBehaviour
{
    public bool capsLock;
    public GameObject normalKeys;
    public GameObject capitalKeys;
    public TextMeshPro capsText;
    public TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        capsLock = false;
        capitalKeys.SetActive(false);
        normalKeys.SetActive(true);
    }

    public void capsPressed(){
        if (!capsLock) {
            normalKeys.SetActive(false);
            capitalKeys.SetActive(true);
            capsLock = true;
            capsText.text = "CAPS LOCK";
        }
        else {
            capitalKeys.SetActive(false);
            normalKeys.SetActive(true);
            capsLock = false;
            capsText.text = "caps lock";
        }
    }

    public void delPressed(){
        if (inputField.text.Length > 0) {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }
    }
    public void returnPressed(){
        inputField.text += "\n";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
