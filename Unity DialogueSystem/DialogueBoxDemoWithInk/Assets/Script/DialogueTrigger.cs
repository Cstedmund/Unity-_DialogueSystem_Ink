using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{

    [Header ("NPC Ink JSON Script")][SerializeField] private TextAsset inkScript;

    private void Awake()
    {
        //inkScript.
    }

    public void OnClickFunction()
    {
        Debug.Log(inkScript.text);
    }

}
