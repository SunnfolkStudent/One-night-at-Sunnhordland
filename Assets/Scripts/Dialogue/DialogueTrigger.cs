using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject lineGenerator;

    public void TriggerDialogue()
    {
        lineGenerator = null;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void DisableElement()
    {
        if (lineGenerator == null)
        {
            lineGenerator.SetActive(false);
        }
    }
}
