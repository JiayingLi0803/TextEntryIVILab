using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Oculus.Interaction.Locomotion;
using TMPro;
using UnityEngine;

public class typingSample : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject typingKeyboard;
    public TextMeshProUGUI sampleGUI;
    public TextMeshProUGUI expGUI;
    public TextMeshPro sizeText;

    public int currExp = 0;
    public int totalExp = 5;
    public int seed = 1;
    public bool largeFlag = true;
    public List<string> sentences = new List<string>
        {
            "How would you explain the difference between the two?",
            "I will call you Monday morning to discuss.",
            "What period does the max rate assumption cover?",
            "Let's have this meeting today/tonight.",
            "Need anything from Target?",
            "We will have some good detail by January 7.",
            "Would you please send runner to get this?",
            "Budget allocation from Glisan has been postponed.",
            "Will you and KB be around this afternoon?",
            "Jane, what about this Thursday for lunch?",
            "What is happening to the stock price?",
            "Shelley Leeds Rickets this AM.",
            "And I can't turn my phone on.",
            "A letter is being sent today.",
            "I might have something at the office.",
            "Presuming we can afford headcount?",
            "I am now officially a Blackberry addict.",
            "Take what you can get.",
            "Boy, I couldn't write too much on this thing!",
            "Should systems manage the migration?",
            "Shelley (making good use of my jury duty time)",
            "Need before board meeting.",
            "I think that is the right answer.",
            "I think your outlined measures sound fine.",
            "I'll presume it is dead until I hear otherwise.",
            "I thought it had gone to all of Enron.",
            "Joel Ephross on issues reacquiring economic interests/swaps from Jedi2/Whitewing.",
            "Chase back office and their restart plan updates individually.",
            "Out of office but have people working on info.",
            "Looking for some gift hints from you.",
            "Lisa Mellencamp on any issues regarding pending litigation.",
            "No sign of Chuck and not responding to messages.",
            "Will let you know how call goes in morning.",
            "Just told them I thought it would be impossible."
        };
    public List<string> shuffledList;
    public List<string> selectedSentences;    
    void Start()
    {
        System.Random random = new System.Random();
        UnityEngine.Random.InitState(seed);

        // Shuffle the sourceList randomly.
        shuffledList = sentences.OrderBy(item => random.Next()).ToList();

        // Take the first 'count' elements from the shuffled list.
        selectedSentences = shuffledList.Take(totalExp).ToList();
    }

    public void switchToNext(){
        if (currExp < 5){
        currExp += 1;
        sampleGUI.text = selectedSentences[currExp-1];
        expGUI.text = "Task 1 - Sentence " + currExp + "";
        }
        else{
            sampleGUI.text = "Your tasks are done!";
        }
    }

    public void keyboardSize(){
        if (largeFlag){
            sizeText.text = "Large";
            typingKeyboard.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            largeFlag = false;
        }
        else{
            sizeText.text = "Small";
            typingKeyboard.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            largeFlag = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
