using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{
    public Dialouge thisDialouge;

    //Finds the Dialouge Manager and starts reading the imputted dialouge
    public void TriggerDialouge()
    {
        FindObjectOfType<DialougeManager>().ReadDialouge(thisDialouge);
    }    
}
