using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tab2Script : MonoBehaviour
{
    public GameObject tab1;
    public GameObject tab2;
    public GameObject keyboard;
    public TextMeshProUGUI textGUI;

    public TextMeshPro sizeText;

    public bool largeFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void openTab1(){
        tab1.SetActive(true);
        tab2.SetActive(false);
        keyboard.SetActive(true);
    }
    public void openTab2(){
        tab1.SetActive(false);
        tab2.SetActive(true);
        keyboard.SetActive(false);
        textGUI.text = "Paste here: ";
    }

    public void keyboardSize(){
        if (largeFlag){
            sizeText.text = "Large";
            keyboard.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            largeFlag = false;
        }
        else{
            sizeText.text = "Small";
            keyboard.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            largeFlag = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
