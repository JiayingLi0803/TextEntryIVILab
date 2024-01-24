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
    public TextMeshProUGUI logCanvas;

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
            else if (wordText.text[caretPos-1] == '\n'){
                caretPos = wordText.text.Length - currLineStr.Length;
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
                    if (secondLastStr == ""){
                        caretPos = beforeCaretText.Length - secondLastStr.Length;
                    }
                    else {
                        caretPos = beforeCaretText.Length - currLineStr.Length - 1;
                    }
                }
            }

            directionKey = true;
        }
        else if (caretPos > wordLimit)
        {
            caretPos -= wordLimit;
            directionKey = true;
        }
        else if (wordText.text[caretPos-1] == '\n'){
            caretPos = 1;
            directionKey = true;
        }
        else
        {
            directionKey = false;
        }
        caretPosCanvas.text = caretPos + "";
    }

    // public void upPressed()
    // {
    //     // Get the TextInfo of the TextMeshProUGUI component
    //     caretPos = int.Parse(caretPosCanvas.text);
    //     TMP_TextInfo textInfo = wordText.textInfo;
    //     int characterId = caretPos - 1;

    //     // Calculate the position of the character at the caret position
    //     TMP_CharacterInfo caretCharInfo = textInfo.characterInfo[characterId];
    //     float caretX = (caretCharInfo.bottomLeft.x + caretCharInfo.topRight.x) * 0.5f;
    //     float caretY = (caretCharInfo.bottomLeft.y + caretCharInfo.topRight.y) * 0.5f;

    //     // Calculate the coordinates of the upper line (assuming it's a monospaced font)
    //     float charHeight = wordText.GetPreferredValues().y;
    //     float upperLineY = caretY + charHeight;

    //     int closestCharacterIndex = -1;
    //     float closestDistance = float.MaxValue;

    //     // Iterate through the characters in the text
    //     for (int i = 0; i < textInfo.characterCount; i++)
    //     {
    //         TMP_CharacterInfo charInfo = textInfo.characterInfo[i];

    //         // Calculate the x and y positions of the character's bounds
    //         float minX = wordText.transform.TransformPoint(charInfo.bottomLeft).x;
    //         float maxX = wordText.transform.TransformPoint(charInfo.topRight).x;
    //         float minY = wordText.transform.TransformPoint(charInfo.bottomLeft).y;
    //         float maxY = wordText.transform.TransformPoint(charInfo.topRight).y;

    //         // Calculate the center of the character's bounds
    //         float centerX = (minX + maxX) * 0.5f;
    //         float centerY = (minY + maxY) * 0.5f;

    //         // Check if this character is in the upper line
    //         if (centerY >= upperLineY){

    //             // Calculate the distance from the character at caretPos
    //             float distance = Vector2.Distance(new Vector2(caretX, caretY), new Vector2(centerX, centerY));
    //             logCanvas.text += distance + "; ";

    //             // Check if this character is closer than the previously closest character
    //             if (distance < closestDistance)
    //             {
    //                 closestDistance = distance;
    //                 closestCharacterIndex = i;
    //             }
    //         }
    //     }

    //     caretPos = closestCharacterIndex + 1;
    //     // logCanvas.text = "caret coordinate: (" + caretX + "," + caretY + ";" + "upperLine:" + upperLineY + "carePos: " + caretPos;
    //     caretPosCanvas.text = caretPos + "";
    // }



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

    public void caretUpdate(){
        if (string.IsNullOrEmpty(wordText.text))
        {
            caretText.text = "<mark=#FFFF0080>" + "_" + "</mark>";
            caretPosCanvas.text = "0";
        }
        // else if (wordText.text[wordText.text.Length - 1] == '\n')
        // {
        //     caretText.text = wordText.text + "<mark=#FFFF0080>" + "_" + "</mark>";
        // }
        else
        {
            caretPos = int.Parse(caretPosCanvas.text);
            if (caretPos == wordText.text.Length)
            {
                beforeCaret = wordText.text.Substring(0, wordText.text.Length - 1);
                boldText = wordText.text.Substring(wordText.text.Length - 1);
                if (boldText == " ")
                {
                    caretText.text = beforeCaret + "<mark=#FFFF0080>" + "_" + "</mark>";
                }
                else if (wordText.text[caretPos-1] == '\n'){
                    caretText.text = wordText.text + "<mark=#FFFF0080>" + "_" + "</mark>";
                }
                else
                {
                    caretText.text = beforeCaret + "<mark=#FFFF0080>" + boldText + "</mark>";
                }
            }
            else
            {
                if (wordText.text[caretPos-1] == '\n' && caretPos < wordText.text.Length){
                    beforeCaret = wordText.text.Substring(0, caretPos-1);
                    boldText = "_\n";
                    afterCaret = wordText.text.Substring(caretPos);
                }
                else if (wordText.text[caretPos-1] =='\n'){
                    beforeCaret = wordText.text.Substring(0, caretPos-1);
                    boldText = "_";
                    afterCaret = wordText.text.Substring(caretPos);
                }
                else{
                    beforeCaret = wordText.text.Substring(0, caretPos - 1);
                    boldText = wordText.text.Substring(caretPos - 1, 1);
                    afterCaret = wordText.text.Substring(caretPos);
                }
                
                caretText.text = beforeCaret + "<mark=#FFFF0080>" + boldText + "</mark>" + afterCaret;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
    //     if (string.IsNullOrEmpty(wordText.text))
    //     {
    //         caretText.text = "<mark=#FFFF0080>" + "_" + "</mark>";
    //         caretPosCanvas.text = "0";
    //     }
    //     // else if (wordText.text[wordText.text.Length - 1] == '\n')
    //     // {
    //     //     caretText.text = wordText.text + "<mark=#FFFF0080>" + "_" + "</mark>";
    //     // }
    //     else
    //     {
    //         caretPos = int.Parse(caretPosCanvas.text);
    //         if (caretPos == wordText.text.Length)
    //         {
    //             beforeCaret = wordText.text.Substring(0, wordText.text.Length - 1);
    //             boldText = wordText.text.Substring(wordText.text.Length - 1);
    //             if (boldText == " ")
    //             {
    //                 caretText.text = beforeCaret + "<mark=#FFFF0080>" + "_" + "</mark>";
    //             }
    //             else if (wordText.text[caretPos-1] == '\n'){
    //                 caretText.text = wordText.text + "<mark=#FFFF0080>" + "_" + "</mark>";
    //             }
    //             else
    //             {
    //                 caretText.text = beforeCaret + "<mark=#FFFF0080>" + boldText + "</mark>";
    //             }
    //         }
    //         else
    //         {
    //             if (wordText.text[caretPos-1] == '\n' && caretPos < wordText.text.Length){
    //                 beforeCaret = wordText.text.Substring(0, caretPos-1);
    //                 boldText = "_\n";
    //                 afterCaret = wordText.text.Substring(caretPos);
    //             }
    //             else if (wordText.text[caretPos-1] =='\n'){
    //                 beforeCaret = wordText.text.Substring(0, caretPos-1);
    //                 boldText = "_";
    //                 afterCaret = wordText.text.Substring(caretPos);
    //             }
    //             else{
    //                 beforeCaret = wordText.text.Substring(0, caretPos - 1);
    //                 boldText = wordText.text.Substring(caretPos - 1, 1);
    //                 afterCaret = wordText.text.Substring(caretPos);
    //             }
                
    //             caretText.text = beforeCaret + "<mark=#FFFF0080>" + boldText + "</mark>" + afterCaret;
    //         }

    //     }
    }
}