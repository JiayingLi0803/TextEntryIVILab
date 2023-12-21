using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI numberText;
    public void displayNumber(){
        numberText.text += gameObject.name;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
