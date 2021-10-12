using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    [Header ("NPC Ink JSON Script")][SerializeField] private TextAsset inkScript;

    public bool dialogueStateComplete;

    private void Awake()
    {
        //inkScript.
    }

    public void OnClickFunction()
    {
        //Debug.Log(inkScript.text);
        DialogueManager.GetInstance().EnterDialogueMode(inkScript,this, dialogueStateComplete);
    }

    public void onDialogueFinshed(bool status)
    {
        dialogueStateComplete = status;
    }
}
