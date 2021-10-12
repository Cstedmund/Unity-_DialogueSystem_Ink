using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    #region Get DisplayUI Reference

    [Header ("Dialogue display area")][SerializeField] private GameObject dialogueArea;
    [Header("Speaker")] [SerializeField] private TextMeshProUGUI speakerName;
    [Header("Content")] [SerializeField] private TextMeshProUGUI contentDialogue;
    [Header("Option")] [SerializeField] private GameObject[] options;

    #endregion

    private void Awake()
    {
        DisableAllDialogueUI();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Internal Display Control Function

    private void DisableAllDialogueUI()
    {
        dialogueArea.SetActive(false);
        foreach (GameObject option in options)
        {
            option.SetActive(false);
        }
    }

    private void DisplayDialogueBox(string name, string content)
    {
        dialogueArea.SetActive(true);
        speakerName.SetText(name);
        contentDialogue.SetText(content);
    }

    private void ToggleDisplayOption(bool toggle, string option_0, string option_1)
    {
        if (options.Length == 2 && toggle == true)
        {
            options[0].SetActive(true);
            options[0].GetComponentInChildren<TextMeshProUGUI>().SetText(option_0);
            options[1].SetActive(true);
            options[1].GetComponentInChildren<TextMeshProUGUI>().SetText(option_0);
        }
        else {
            foreach (GameObject option in options)
            {
                option.SetActive(false);
            }
        }
    }

    #endregion


}
