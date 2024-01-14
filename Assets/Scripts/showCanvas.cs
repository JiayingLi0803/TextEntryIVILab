using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI numberText;// word text
    public TextMeshProUGUI caretPosCanvas;
    // public AudioSource typingAudio;
    public void displayNumber(){
        // typingAudio.Play();
        int currentCaretValue = int.Parse(caretPosCanvas.text);
        
        numberText.text = numberText.text.Insert(currentCaretValue, gameObject.name);
        
        currentCaretValue += 1;
        caretPosCanvas.text = currentCaretValue + "";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
