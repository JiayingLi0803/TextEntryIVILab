using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class keySwitch : MonoBehaviour
{
    public bool capsLock;
    public bool shiftLeft;
    public bool shiftRight;
    public GameObject normalKeys;
    public GameObject capitalKeys;
    public TextMeshPro capsText;
    public GameObject beforeShiftKeys;
    public GameObject afterShiftKeys;
    public TextMeshPro shiftLeftText;
    public TextMeshPro shiftRightText;
    public TextMeshProUGUI inputCanvas;
    // Start is called before the first frame update
    void Start()
    {
        capsLock = false;
        capitalKeys.SetActive(false);
        normalKeys.SetActive(true);

        shiftLeft = false;
        shiftRight = false;
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

        public void shiftLeftPressed(){
        if (!shiftLeft && !shiftRight) {
            beforeShiftKeys.SetActive(false);
            afterShiftKeys.SetActive(true);
            shiftLeft = true;
            shiftRight = true;
            shiftLeftText.text = "SHIFT";
            shiftRightText.text = "SHIFT";
        }
        else {
            afterShiftKeys.SetActive(false);
            beforeShiftKeys.SetActive(true);
            shiftLeft = false;
            shiftRight = false;
            shiftLeftText.text = "shift";
            shiftRightText.text = "shift";
        }
    }
    public void shiftRightPressed(){
        if (!shiftLeft && !shiftRight) {
            beforeShiftKeys.SetActive(false);
            afterShiftKeys.SetActive(true);
            shiftLeft = true;
            shiftRight = true;
            shiftLeftText.text = "SHIFT";
            shiftRightText.text = "SHIFT";
        }
        else {
            afterShiftKeys.SetActive(false);
            beforeShiftKeys.SetActive(true);
            shiftLeft = false;
            shiftRight = false;
            shiftLeftText.text = "shift";
            shiftRightText.text = "shift";
        }
    }

    public void delPressed(){
        if (inputCanvas.text.Length > 0) {
            inputCanvas.text = inputCanvas.text.Substring(0, inputCanvas.text.Length - 1);
        }
    }
    public void returnPressed(){
        inputCanvas.text += "\n";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
