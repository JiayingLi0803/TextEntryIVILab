using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Text.RegularExpressions;

public class keySwitch : MonoBehaviour
{
    public bool capsLock;
    public bool shiftKey;
    public GameObject normalKeys;
    public GameObject capitalKeys;
    public GameObject functionKeys;
    public TextMeshPro capsText;
    public GameObject beforeShiftKeys;
    public GameObject afterShiftKeys;
    public TextMeshPro shiftLeftText;
    public TextMeshPro shiftRightText;
    public TextMeshProUGUI inputCanvas;
    public TextMeshProUGUI caretCanvas;
    public TextMeshProUGUI lineInfoCanvas;
    public TextMeshProUGUI caretPosCanvas;
    public TextMeshProUGUI clipBoardCanvas;
    public TextMeshProUGUI logGUI;

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
        // Find the starting index of "<mark=#FFFF0080>"
        int startIndex = caretCanvas.text.IndexOf("<mark=#FFFF0080>");

        // Find the ending index of "</mark>"
        int endIndex = caretCanvas.text.IndexOf("</mark>");
        if (startIndex != -1 && endIndex != -1 && endIndex > startIndex)
        {
            // Extract the beforeCaret, boldText, and afterCaret strings
            string beforeCaret = caretCanvas.text.Substring(0, startIndex);
            string boldText = caretCanvas.text.Substring(startIndex + "<mark=#FFFF0080>".Length, endIndex - startIndex - "<mark=#FFFF0080>".Length);
            string afterCaret = caretCanvas.text.Substring(endIndex + "</mark>".Length);

            
            inputCanvas.text = beforeCaret + afterCaret;
            caretPosCanvas.text = startIndex + "";
        }
        // else
        // {
        //     charNum = int.Parse(caretPosCanvas.text); // caret position
        //     if (charNum > 1) {
        //         // if (inputCanvas.text[charNum-1] == '\n'){
        //         //     lineNum = int.Parse(lineInfoCanvas.text.Substring(lineInfoCanvas.text.Length-1).ToString());
        //         //     lineNum -= 1;
        //         //     lineInfoCanvas.text = "Lines: " + lineNum + "";
        //         // }
        //         string beforeCaret = inputCanvas.text.Substring(0, charNum-1);
        //         string afterCaret = inputCanvas.text.Substring(charNum);
        //         inputCanvas.text =  beforeCaret + afterCaret;

        //         charNum -= 1;
                
        //     }
        //     else if (charNum == 1){
        //         inputCanvas.text =  inputCanvas.text.Substring(1);
        //     }
        //     caretPosCanvas.text = charNum + "";
        // }
        
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

    public void clearPressed(){
        lineInfoCanvas.text = "Lines: " + 1 + "";
        inputCanvas.text = "";
        caretPosCanvas.text = 0 + "";
        functionKeys.SetActive(false);
    }

    public void copyPressed(){
        string wordtext = caretCanvas.text;
        string pattern = "<mark=#FFFF0080>(.*?)</mark>";
        // Use Regex to find matches
        MatchCollection matches = Regex.Matches(wordtext, pattern);

        // Initialize a string to store the combined boldChars
        string boldChars = "";

        // Extract and concatenate the boldChars from matches
        foreach (Match match in matches)
        {
            boldChars += match.Groups[1].Value;
        }
        clipBoardCanvas.text = boldChars;
        functionKeys.SetActive(false);
    }

    public void pastePressed(){
        string copiedText = clipBoardCanvas.text;
        charNum = int.Parse(caretPosCanvas.text); // caret position
        string wordtext = inputCanvas.text;
        inputCanvas.text = wordtext.Substring(0, charNum) + copiedText + wordtext.Substring(charNum);
        charNum += copiedText.Length;
        caretPosCanvas.text = charNum + "";
        functionKeys.SetActive(false);
    }

    public void cutPressed(){
        string wordtext = caretCanvas.text;
        string openingTag = "<mark=#FFFF0080>";
        string closingTag = "</mark>";
        string beforeBold = "";
        string boldChars = "";
        string afterBold = "";

        // Find the index of the opening tag for the first occurrence
        int openingIndex = wordtext.IndexOf(openingTag);

        if (openingIndex != -1)
        {
            // Find the index of the closing tag for the first occurrence
            int closingIndex = wordtext.IndexOf(closingTag, openingIndex);

            if (closingIndex != -1)
            {
                // Extract beforeBold, boldChars, and afterBold based on the indices
                beforeBold = wordtext.Substring(0, openingIndex);
                boldChars = wordtext.Substring(openingIndex + openingTag.Length, closingIndex - openingIndex - openingTag.Length);
                afterBold = wordtext.Substring(closingIndex + closingTag.Length);

            }
        }

        clipBoardCanvas.text = boldChars;
        inputCanvas.text = beforeBold + afterBold;
        caretCanvas.text = inputCanvas.text;
        caretPosCanvas.text = beforeBold.Length + 1 + "";
        functionKeys.SetActive(false);

    }

    public void closePressed(){
        functionKeys.SetActive(false); // set to invisible
    }


    // Update is called once per frame
    void Update()
    {
        lineNum = inputCanvas.text.Split('\n').Length;
        lineInfoCanvas.text = "Lines: " + lineNum + "";
    }
}
