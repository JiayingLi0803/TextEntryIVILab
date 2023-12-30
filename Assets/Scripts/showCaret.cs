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
            int lastNewLine = beforeCaretText.LastIndexOf('\n', caretPos); //the \n position before the caret
            int distCaretNewLine = caretPos - lastNewLine; // distance from the beginning of the new line to the caret position
            if (distCaretNewLine > 33)
            {
                caretPos -= 33;
            }
            else
            {
                string beforeNewLineText = beforeCaretText.Substring(0, lastNewLine);
                int secondLastNewLine = beforeNewLineText.LastIndexOf('\n'); // the second last \n position before caret position
                if (secondLastNewLine == -1)
                {
                    secondLastNewLine = 0;
                }
                int distSecondNewLine = lastNewLine - secondLastNewLine;
                if (distSecondNewLine >= distCaretNewLine)
                {
                    caretPos = secondLastNewLine + distCaretNewLine;
                }
                else
                {
                    caretPos = secondLastNewLine - 1;
                }
            }
            directionKey = true;
        }
        else if (caretPos > 33)
        {
            caretPos -= 33;
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