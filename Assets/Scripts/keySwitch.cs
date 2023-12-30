using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class keySwitch : MonoBehaviour
{
    public bool capsLock;
    public bool shiftKey;
    public GameObject normalKeys;
    public GameObject capitalKeys;
    public TextMeshPro capsText;
    public GameObject beforeShiftKeys;
    public GameObject afterShiftKeys;
    public TextMeshPro shiftLeftText;
    public TextMeshPro shiftRightText;
    public TextMeshProUGUI inputCanvas;
    public TextMeshProUGUI lineInfoCanvas;
    public TextMeshProUGUI caretPosCanvas;
    int lineNum;
    int charNum;

    // Start is called before the first frame update
    void Start()
    {
        capsLock = false;
        capitalKeys.SetActive(false);
        normalKeys.SetActive(true);

        shiftKey = false;
        afterShiftKeys.SetActive(false);
        beforeShiftKeys.SetActive(true);
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

        public void shiftPressed(){
        if (!shiftKey) {
            beforeShiftKeys.SetActive(false);
            afterShiftKeys.SetActive(true);
            shiftKey = true;
            shiftLeftText.text = "SHIFT";
            shiftRightText.text = "SHIFT";
        }
        else {
            afterShiftKeys.SetActive(false);
            beforeShiftKeys.SetActive(true);
            shiftKey = false;
            shiftLeftText.text = "shift";
            shiftRightText.text = "shift";
        }
    }

    public void delPressed(){
        charNum = int.Parse(caretPosCanvas.text); // caret position
        if (charNum > 1) {
            if (inputCanvas.text[charNum-1] == '\n'){
                lineNum = int.Parse(lineInfoCanvas.text.Substring(lineInfoCanvas.text.Length-1).ToString());
                lineNum -= 1;
                lineInfoCanvas.text = "Lines: " + lineNum + "";
            }
            string beforeCaret = inputCanvas.text.Substring(0, charNum-1);
            string afterCaret = inputCanvas.text.Substring(charNum);
            inputCanvas.text =  beforeCaret + afterCaret;

            charNum -= 1;
            
        }
        else if (charNum == 1){
            inputCanvas.text =  inputCanvas.text.Substring(1);
        }
        caretPosCanvas.text = charNum + "";
    }
    public void returnPressed(){
        charNum = int.Parse(caretPosCanvas.text);

        inputCanvas.text = inputCanvas.text.Insert(charNum, "\n");
        

        lineNum = int.Parse(lineInfoCanvas.text.Substring(lineInfoCanvas.text.Length-1).ToString());
        lineNum += 1;
        lineInfoCanvas.text = "Lines: " + lineNum + "";
        
        charNum += 1;
        caretPosCanvas.text = charNum + "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
