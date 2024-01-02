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
    public int wordLimit = 33;
    private int caretPos;
    private string beforeCaret;
    private string boldText;
    private string afterCaret;
    void Start()
    {
        caretText.text = wordText.text;
        directionKey = false; // turn off the direction buttons
    }

    public static string ReplaceExceptNewlines(string input)
    {
        string pattern = "[^\n]";
        string result = Regex.Replace(input, pattern, " ");
        return result;
    }

    public void upPressed()
    {
        caretPos = int.Parse(caretPosCanvas.text);
        string beforeCaretText = wordText.text.Substring(0, caretPos - 1);
        if (beforeCaretText.Contains('\n'))
        { // contains \n before the caret position
            string[] linesList = beforeCaretText.Split('\n');
            string currLineStr = linesList[linesList.Length - 1];
            string secondLastStr = linesList[linesList.Length - 2];
            if (currLineStr.Length > wordLimit) {
                    caretPos -= wordLimit;
            }
            else{
                if (currLineStr.Length < secondLastStr.Length){
                    if (secondLastStr.Length > wordLimit){
                        if (secondLastStr.Length - wordLimit <= currLineStr.Length) {
                            caretPos = beforeCaretText.Length - currLineStr.Length - 1;
                        }
                        else{
                            caretPos = beforeCaretText.Length - secondLastStr.Length + wordLimit;
                        }
                    }
                    else{
                        caretPos = beforeCaretText.Length - secondLastStr.Length;
                    }
                }
                else {
                    caretPos = beforeCaretText.Length - currLineStr.Length - 1;
                }
            }

            directionKey = true;
        }
        else if (caretPos > wordLimit)
        {
            caretPos -= wordLimit;
            directionKey = true;
        }
        else
        {
            directionKey = false;
        }
        caretPosCanvas.text = caretPos + "";
    }
    public void downPressed()
    {
        int distLenBefore;
        caretPos = int.Parse(caretPosCanvas.text);
        string afterCaretText = wordText.text.Substring(caretPos);
        string beforeCaretText = wordText.text.Substring(0, caretPos - 1);
        if (beforeCaretText.Contains('\n')){
            string[] linesListBefore = beforeCaretText.Split('\n');
            distLenBefore = linesListBefore[linesListBefore.Length-1].Length;
        }
        else{
            distLenBefore = caretPos;
        }
        if (afterCaretText.Contains('\n')){
            string[] linesList = afterCaretText.Split('\n');
            string currLineStr = linesList[0];
            string secondLastStr = linesList[1];
            if (currLineStr.Length >= wordLimit){
                caretPos += wordLimit;
            }
            else if (currLineStr.Length + distLenBefore > wordLimit){
                if (distLenBefore <= wordLimit) {
                    caretPos += currLineStr.Length;
                }
                else {
                    if (distLenBefore - wordLimit > secondLastStr.Length) {
                        caretPos = caretPos + currLineStr.Length + 1 + secondLastStr.Length;
                    }
                    else {
                        caretPos = caretPos + currLineStr.Length + 2 + distLenBefore - wordLimit;
                    }
                }
            }
            else{
                if (secondLastStr.Length <= distLenBefore) {
                    caretPos = caretPos + currLineStr.Length + 1 + secondLastStr.Length;
                }
                else{
                    caretPos = caretPos + currLineStr.Length + 2 + distLenBefore;
                }
            }
            
            directionKey = true;
        }
        else if (wordText.text.Length - caretPos > wordLimit){
            caretPos += wordLimit;
            directionKey = true;
        }
        else if (wordText.text.Length - caretPos + distLenBefore > wordLimit) {
            caretPos = wordText.text.Length;
            directionKey = true;
        }
        else
        {
            directionKey = false;
        }
        caretPosCanvas.text = caretPos + "";
    }
    public void leftPressed()
    {
        caretPos = int.Parse(caretPosCanvas.text);
        if (caretPos > 0)
        // if (!string.IsNullOrEmpty(wordText.text))
        {
            caretPos -= 1;
            caretPosCanvas.text = caretPos + "";
            directionKey = true;
        }
        else
        {
            directionKey = false;
        }
    }
    public void rightPressed()
    {
        caretPos = int.Parse(caretPosCanvas.text);
        if (caretPos < wordText.text.Length)
        {
            caretPosCanvas.text = caretPos + 1 + "";
        }
        else
        {
            directionKey = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (string.IsNullOrEmpty(wordText.text))
        {
            caretText.text = "<mark=#000000FF>" + "_" + "</mark>";
            caretPosCanvas.text = "0";
        }
        else if (wordText.text[wordText.text.Length - 1] == '\n')
        {
            caretText.text = wordText.text + "<mark=#000000FF>" + "_" + "</mark>";
        }
        else
        {
            caretPos = int.Parse(caretPosCanvas.text);
            if (caretPos == wordText.text.Length)
            {
                beforeCaret = wordText.text.Substring(0, wordText.text.Length - 1);
                boldText = wordText.text.Substring(wordText.text.Length - 1);
                if (boldText == " ")
                {
                    caretText.text = beforeCaret + "<mark=#000000FF>" + "_" + "</mark>";
                }

                else
                {
                    caretText.text = beforeCaret + "<mark=#000000FF>" + boldText + "</mark>";
                }
            }
            else
            {
                if (wordText.text[caretPos-1] == '\n' && caretPos < wordText.text.Length){
                    beforeCaret = wordText.text.Substring(0, caretPos);
                    boldText = wordText.text.Substring(caretPos, 1);
                    afterCaret = wordText.text.Substring(caretPos + 1);
                }
                else{
                    beforeCaret = wordText.text.Substring(0, caretPos - 1);
                    boldText = wordText.text.Substring(caretPos - 1, 1);
                    afterCaret = wordText.text.Substring(caretPos);
                }
                
                caretText.text = beforeCaret + "<mark=#000000FF>" + boldText + "</mark>" + afterCaret;
            }

        }
    }
}