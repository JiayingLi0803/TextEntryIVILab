using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using TMPro;
using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.Input;

public class outputLog : MonoBehaviour
{
    public TextMeshProUGUI logGUI;
    public TextMeshProUGUI pointerGUI;
    public TextMeshProUGUI CaretGUI;
    public TextMeshProUGUI textGUI;

    int pressNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void showPressedInfo(){
        pressNum += 1;
        logGUI.text = "Canvas is pressed" + pressNum + "";
    }

    public void showInitialPoint(PointerEvent pointOnCanvas){
        HandRef fingerData = (HandRef)pointOnCanvas.Data;
        pointerGUI.text = fingerData + "";


    }
    public void showMovePosition(){
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
