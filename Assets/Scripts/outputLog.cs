using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using TMPro;
using UnityEngine;
using Oculus.Interaction.Input;

public class outputLog : MonoBehaviour
{
    public OVRCameraRig ovrCameraRig;
    private Camera ovrCamera;
    public GameObject functionKeys;
    public TextMeshProUGUI logGUI;
    public TextMeshProUGUI initPointGUI;
    public TextMeshProUGUI pointerGUI;
    public TextMeshProUGUI finalPointGUI;
    public TextMeshProUGUI CaretGUI;
    public TextMeshProUGUI textGUI;
    public TextMeshProUGUI caretPositionGUI;

    public Vector3 initCaretPosition;
    public Vector3 finalCaretPosition;

    public int characterIndex;
    public int finalCharIndex;

    private string beforeBold;
    private string boldChars;
    private string afterBold;

    public bool selectedFlag = false;

    int pressNum = 0;
    // Start is called before the first frame update
    void Start(){
        CaretGUI.text = textGUI.text;
        ovrCamera = ovrCameraRig.centerEyeAnchor.GetComponent<Camera>();
    }

    public void showPressedInfo(){
        pressNum += 1;
        logGUI.text = "Canvas is pressed: x" + pressNum + "";
    }

    public void showInitialPoint(PointerEvent pointOnCanvas){
        Pose p = pointOnCanvas.Pose;
        initCaretPosition = p.position;
        string initialPosition = $"Position: {initCaretPosition}";
        initPointGUI.text = initialPosition;

    }
    public void showMovePosition(PointerEvent moveCanvas){
        Pose lp = moveCanvas.Pose;
        finalCaretPosition = lp.position;
        string movePosition = $"Position: {finalCaretPosition}";
        pointerGUI.text = movePosition;
    }
    public void showFinalPosition(PointerEvent leaveCanvas){
        Pose fp = leaveCanvas.Pose;
        finalCaretPosition = fp.position;
        string finalPosition = $"Position: {finalCaretPosition}";
        finalPointGUI.text = finalPosition;
    }

    public void setSelectedFlagTrue(){
        selectedFlag = true;
    }

    public void setSelectedFlagFalse(){
        selectedFlag = false;
    }

    // private int locateCaret(Vector3 currPos){
    //     RectTransform textRectTransform = textGUI.GetComponent<RectTransform>();
    //     Vector3[] corners = new Vector3[4];
    //     textRectTransform.GetWorldCorners(corners);
    //     Vector3 bottomLeftCorner = corners[0];
    //     Vector3 topLeftCorner = corners[1];
    //     Vector3 topRightCorner = corners[2];
    //     Vector3 bottomRightCorner = corners[3];
    //     float xLeftBound = bottomLeftCorner.x;
    //     float xRightBound = bottomRightCorner.x;
    //     float yTopBound = topLeftCorner.y;
    //     float yBottomBound = bottomLeftCorner.y;


    //     float xPos = currPos.x;
    //     float yPos = currPos.y;
    //     return 0;
    // }

// public int FindCharacterIndexAtWorldPoint(Vector3 worldPoint)
//     {
//         Vector3 localPoint;
//         RectTransformUtility.ScreenPointToWorldPointInRectangle(
//             textGUI.rectTransform, worldPoint, null, out localPoint
//         );

//         // Get the TextInfo of the TextMeshProUGUI component
//         TMP_TextInfo textInfo = textGUI.textInfo;

//         // Iterate through the characters in the text
//         for (int i = 0; i < textInfo.characterCount; i++)
//         {
//             TMP_CharacterInfo charInfo = textInfo.characterInfo[i];

//             // Calculate the x and y positions of the character's bounds
//             float minX = textGUI.transform.TransformPoint(charInfo.bottomLeft).x;
//             float maxX = textGUI.transform.TransformPoint(charInfo.topRight).x;
//             float minY = textGUI.transform.TransformPoint(charInfo.bottomLeft).y;
//             float maxY = textGUI.transform.TransformPoint(charInfo.topRight).y;

//             // Check if the provided x and y coordinates are within the bounds of the character
//             if (localPoint.x >= minX && localPoint.x <= maxX &&
//                 localPoint.y >= minY && localPoint.y <= maxY)
//             {
//                 // Return the index of the character in the text string
//                 return i;
//             }
//         }

//         // Return -1 if no character is found at the provided x and y coordinates
//         return -1;
//     }

public int FindClosestCharacterIndexAtWorldPoint(Vector3 worldPoint)
{
    Vector3 localPoint;
    RectTransformUtility.ScreenPointToWorldPointInRectangle(
        textGUI.rectTransform, worldPoint, null, out localPoint
    );

    // Get the TextInfo of the TextMeshProUGUI component
    TMP_TextInfo textInfo = textGUI.textInfo;

    int closestCharacterIndex = -1;
    float closestDistance = float.MaxValue;

    // Calculate the size of one character (assuming it's monospaced)
    float charWidth = textGUI.GetPreferredValues().x / textGUI.text.Length; // Character width
    float charHeight = textGUI.GetPreferredValues().y; // Character height

    // Iterate through the characters in the text
    for (int i = 0; i < textInfo.characterCount; i++)
    {
        TMP_CharacterInfo charInfo = textInfo.characterInfo[i];

        // Calculate the x and y positions of the character's bounds
        float minX = textGUI.transform.TransformPoint(charInfo.bottomLeft).x;
        float maxX = textGUI.transform.TransformPoint(charInfo.topRight).x;
        float minY = textGUI.transform.TransformPoint(charInfo.bottomLeft).y;
        float maxY = textGUI.transform.TransformPoint(charInfo.topRight).y;

        // Calculate the center of the character's bounds
        float centerX = (minX + maxX) * 0.5f;
        float centerY = (minY + maxY) * 0.5f;

        // Calculate the distance from the click point to the center of the character's bounds
        float distance = Vector2.Distance(new Vector2(localPoint.x, localPoint.y), new Vector2(centerX, centerY));

        // Check if this character is closer than the previously closest character
        if (distance < closestDistance)
        {
            closestDistance = distance;
            closestCharacterIndex = i;
        }
    }

    // Check if the closest distance is less than or equal to one character size
    if (closestDistance <= Mathf.Max(charWidth, charHeight))
    {
        // Return the index of the closest character in the text string
        return closestCharacterIndex;
    }
    else
    {
        // Return -1 if the closest character is too far away
        return -1;
    }
}


    // Helper function to check if a point is inside a quad defined by its four corners

    public void showCharacter(){
        // characterIndex = FindCharacterIndexAtWorldPoint(initCaretPosition);
        characterIndex = FindClosestCharacterIndexAtWorldPoint(initCaretPosition);
        if (characterIndex != -1)
        {
            logGUI.text = "Character at index " + characterIndex + ": " + textGUI.text[characterIndex];
        }
        else
        {
            logGUI.text = "No character found at the clicked point.";
        }
    }

    public void finalCharacter(){
        if (selectedFlag){
            // finalCharIndex = FindCharacterIndexAtWorldPoint(finalCaretPosition);
            finalCharIndex = FindClosestCharacterIndexAtWorldPoint(finalCaretPosition);
            initPointGUI.text = "Initial character at index" + characterIndex + ": " + textGUI.text[characterIndex];

            if (finalCharIndex != -1)
            {
                beforeBold = textGUI.text.Substring(0, characterIndex);
                
                boldChars = textGUI.text.Substring(characterIndex, finalCharIndex - characterIndex + 1);
                logGUI.text = boldChars;
                afterBold = textGUI.text.Substring(finalCharIndex + 1);
                
                finalPointGUI.text = "Final character at index " + finalCharIndex + ": " + textGUI.text[finalCharIndex];

                
                CaretGUI.text = beforeBold + "<mark=#000000FF>" + boldChars + "</mark>" + afterBold;
                caretPositionGUI.text = finalCharIndex + 1 + "";

                functionKeys.transform.position = finalCaretPosition;
                functionKeys.SetActive(true);
            }
            else
            {
                logGUI.text = "No character found at the clicked point.";
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
