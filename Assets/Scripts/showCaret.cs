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
    void Start()
    {
        caretText.text = wordText.text + "|";
    }

    public static string ReplaceExceptNewlines(string input){
        string pattern = "[^\n]";
        string result = Regex.Replace(input, pattern, " ");
        return result;
    }

    // Update is called once per frame
    void Update()
    {
        string beforeCaret = wordText.text.Substring(0, wordText.text.Length-1);
        caretText.text = ReplaceExceptNewlines(beforeCaret)+ wordText.text.Substring(wordText.text.Length - 1);
    }
}
