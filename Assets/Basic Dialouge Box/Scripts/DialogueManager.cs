using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameTxt;
    public TMP_Text dialougeTxt;
    public Animator boxAnimation;

    private Queue<string> _pages;
    private Queue<float> _txtSpeed;

    void Start()
    {
        _pages = new Queue<string>();
        _txtSpeed = new Queue<float>();
    }

    //Reads the imputted pages of dialouge and updates the queue with what it read.
    //Also sets the Text Speed for each page of the dialouge.
    public void ReadDialouge(Dialogue dialouge)
    {
        boxAnimation.SetBool("IsOpen", true);
        nameTxt.text = dialouge.name;
        Time.timeScale = 0;

        _pages.Clear();
        foreach (string page in dialouge.page)
        {
            _pages.Enqueue(page);
        }

        _txtSpeed.Clear();
        foreach (float txtSpeed in dialouge.txtSpeedForEachPage)
        {
            _txtSpeed.Enqueue(txtSpeed);
        }
        OnDialougeOpen();
    }

    /*
    OnDialougeOpen() and/or OnDialougeClose() can be called in the animator if using a custom animation. 

    OnDialougeOpen() is currently being automatically called when the text box animation starts.
    If you want to change this, just remove the OnDialougeOpen() call 
    from the ReadDialouge() function above. Then call it instead in your animation 
    at the point you want the dialouge to start showing.
    */

    public void OnDialougeOpen()
    {
        DisplayNextSentance();
    }

    public void OnDialougeClose()
    {
        StopAllCoroutines();
        dialougeTxt.text = "";
        nameTxt.text = "";
    }

    //The process of ending the dialouge.
    void EndDialouge()
    {
        OnDialougeClose();
        boxAnimation.SetBool("IsOpen", false);
        Time.timeScale = 1;
    }

    //Removes the pages/type speeds from the queue and sends them to be typed out
    //If called when there are no more pages in the queue, it ends the Dialouge.
    public void DisplayNextSentance()
    {
        if (_pages.Count == 0)
        {
            EndDialouge();
            return;
        }

        string currentPage = _pages.Dequeue();
        float currentTypeSpeed = _txtSpeed.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentance(currentPage, currentTypeSpeed));
    }

    //Handles the typing effects for the pages and updates the visuals
    IEnumerator TypeSentance(string page, float txtSpeed)
    {
        dialougeTxt.text = "";
        string originalText = page;

        int i = 0;
        foreach (char letter in page.ToCharArray())
        {
            i++;
            dialougeTxt.text = originalText;
            string displayedText = dialougeTxt.text.Insert(i, "<color=#00000000>");
            dialougeTxt.text = displayedText;
            yield return new WaitForSecondsRealtime(txtSpeed);
        }
    }
}
