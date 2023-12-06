using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class countShow : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    int numberCount;
    // Start is called before the first frame update
    public void ButtonPressed(){
        numberCount ++ ;
        numberText.text = "Press Count: " + numberCount + "";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
