using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class showCaret : MonoBehaviour
{
    public TextMeshProUGUI wordText;
    public TextMeshProUGUI caretText;
    public TextMeshProUGUI lineInfoCanvas;
    public TextMeshProUGUI caretPosCanvas;
    // Start is called before the first frame update
    public bool directionKey;
    private int caretPos;
    void Start()
    {
        caretText.text = wordText.text;
        directionKey = false; // turn off the direction buttons
    }

    public static string ReplaceExceptNewlines(string input){
        string pattern = "[^\n]";
        string result = Regex.Replace(input, pattern, " ");
        return result;
    }

    public void upPressed(){

    }
    public void downPressed(){
        
    }
    public void leftPressed(){
        if (!string.IsNullOrEmpty(wordText.text)){
            caretPosCanvas.text = int.Parse(caretPosCanvas.text.Substring(caretPosCanvas.text.Length-1).ToString()) - 1 + "";
            directionKey = true;
        }
        else{
            directionKey = false;
        }
    }
        public void rightPressed(){
            caretPos = int.Parse(caretPosCanvas.text.Substring(caretPosCanvas.text.Length-1).ToString());
        if (caretPos < wordText.text.Length){
            caretPosCanvas.text = caretPos + 1 + "";
        }
        else{
            directionKey = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (string.IsNullOrEmpty(wordText.text))
        {
            caretText.text = "<mark=#000000FF>" + "_" + "</mark>"; 
        }
        else if (wordText.text[wordText.text.Length - 1] == '\n')
        {
            caretText.text = wordText.text + "<mark=#000000FF>" + "_" + "</mark>";
        }
        else
        {
            if (!directionKey){
                string beforeCaret = wordText.text.Substring(0, wordText.text.Length-1);
                string boldText = wordText.text.Substring(wordText.text.Length - 1);
                if (boldText == " "){
                    caretText.text = beforeCaret + "<mark=#000000FF>" + "_" + "</mark>"; 
                }
                
                else{
                    caretText.text = beforeCaret + "<mark=#000000FF>" + boldText + "</mark>"; 
                }
            }
            else{
                caretPos = int.Parse(caretPosCanvas.text.Substring(caretPosCanvas.text.Length-1).ToString());
                string beforeCaret = wordText.text.Substring(0, caretPos-1);
                string boldText = wordText.text.Substring(caretPos-1, 1);
                string afterCaret = wordText.text.Substring(caretPos);
                caretText.text = beforeCaret + "<mark=#000000FF>" + boldText + "</mark>" + afterCaret; 
        }
        
        }
    }
}