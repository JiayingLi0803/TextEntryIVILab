using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI numberText;
    int number;
    public void displayNumber(){
        number ++ ;
        numberText.text = "Count: " + number + "";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
