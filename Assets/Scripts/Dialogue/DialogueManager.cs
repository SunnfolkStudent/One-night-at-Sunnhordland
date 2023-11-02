using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    
    private Queue<string> _sentences;

    public GameObject dialoguwBox;
    
    void Start()
    {
        _sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        
        nameText.text = dialogue.name;
        _sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);   
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            dialoguwBox.SetActive(false);
            if(SceneManager.GetActiveScene().name != "MainOffice") EndDialogue();
            return;
        }

        string sentence = _sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        Debug.Log("End of convo");
        SceneManager.LoadScene("MainOffice");
    }
    
}
