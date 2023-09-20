using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    private int Index = 0;
    public float DialogueSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        // Start the first dialogue automatically when the scene begins.
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        // Add any update logic you need here.
    }

    public void NextSentence()
    {
        if (Index < Sentences.Length - 1)
        {
            DialogueText.text = "";
            StartCoroutine(WriteSentence());
        }
        else
        {
            EndDialogue(); // Call a function to end the dialogue.
        }
    }

    void StartDialogue()
    {
    

        // Reset the index to start from the first sentence.
        Index = 0;

        // Start displaying the first sentence.
        NextSentence();
    }

    void EndDialogue()
    {

     
            SceneManager.LoadScene("LEVEL 1");
        
    }

    IEnumerator WriteSentence()
    {
        foreach (char Character in Sentences[Index].ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(DialogueSpeed);
        }
        Index++;
    }
}
