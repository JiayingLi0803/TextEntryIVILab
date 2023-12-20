using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class showCaret : MonoBehaviour
{
    public TextMeshProUGUI wordText;
    public TMP_InputField inputField;
    private int wordLength;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wordLength = inputField.text.Length;
        wordText.text = string.Empty.PadLeft(wordLength, ' ') + '|';
    }
}
