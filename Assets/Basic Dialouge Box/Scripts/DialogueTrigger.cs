using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue thisDialogue;

    //Finds the Dialouge Manager and starts reading the imputted dialouge
    public void TriggerDialouge()
    {
        FindObjectOfType<DialogueManager>().ReadDialouge(thisDialogue);
    }    
}
