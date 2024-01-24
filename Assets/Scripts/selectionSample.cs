using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class selectionSample : MonoBehaviour
{
    // Start is called before the first frame update
    public string sampleSentence = "This is a text selection sample scene. Please notice that only index finger can be used in this text selection task.\nPress on this text surface and move to select. The selected words will highlighted with black background color.";
    public TextMeshProUGUI sampleGUI;
    public TextMeshProUGUI sampleFrontGUI;
    public TextMeshProUGUI expGUI;
    public TextMeshProUGUI textGUI;
    public TextMeshProUGUI caretGUI;
    public GameObject surfaceGUI;

    public TextMeshPro modeText;

    public bool modeFlag = true; //initial right handed mode


    public int currExp = 1;
    public int totalExp = 5;
    void Start()
    {
        
    }

    public void generatePattern(){
        if (currExp < totalExp){
            int id1, id2;
            do
            {
                id1 = UnityEngine.Random.Range(0, sampleSentence.Length);
                id2 = UnityEngine.Random.Range(0, sampleSentence.Length);
            }
            while (id1 == id2);

            // Ensure that id1 is less than id2
            if (id1 > id2)
            {
                int temp = id1;
                id1 = id2;
                id2 = temp;
            }
            sampleGUI.text = sampleSentence.Substring(0,id1) + "<mark=#000000FF>" + sampleSentence.Substring(id1, id2-id1+1) + "</mark>" + sampleSentence.Substring(id2+1);
            currExp += 1;
            expGUI.text = "Task 2 - Selection " + currExp + "";
        }
        else{
            sampleGUI.text = "Your tasks are done!";
            sampleFrontGUI.text = "Your tasks are done!";
        }
        textGUI.text = sampleSentence;
    }

    public void swapCanvas(){
        Vector3 rightPosition = textGUI.transform.position;
        Vector3 leftPosition = sampleGUI.transform.position;

        // Swap the positions of the canvases
        textGUI.transform.position = leftPosition;
        caretGUI.transform.position = leftPosition;
        surfaceGUI.transform.position = leftPosition;
        sampleGUI.transform.position = rightPosition;
        sampleFrontGUI.transform.position = rightPosition;

        if (modeFlag){
            modeText.text = "Right";
            modeFlag = false;
        }
        else{
            modeText.text = "Left";
            modeFlag = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
