using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class getKeyName : MonoBehaviour
{
    public string keyName;
    TextMeshProUGUI buttonkey;
    // Start is called before the first frame update
    public void getButton(){
        buttonkey = GetComponentInChildren<TextMeshProUGUI>();
        keyName = buttonkey.text;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
