using System.Collections;
using System.Collections.Generic;
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

    // Update is called once per frame
    void Update()
    {
        caretText.text = wordText.text + "|";
    }
}
