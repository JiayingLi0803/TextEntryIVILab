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
    // Start is called before the first frame update
    private bool directionKey;
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

        }
    }
        public void rightPressed(){
        
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
                
            }
        }
        
    }
}
