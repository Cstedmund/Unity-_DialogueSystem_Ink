using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    #region Variable Get DisplayUI Reference

    [Header ("Dialogue display area")][SerializeField] private GameObject dialoguePanel;
    [Header("Speaker")] [SerializeField] private TextMeshProUGUI speakerName;
    [Header("Content")] [SerializeField] private TextMeshProUGUI contentDialogue;
    [Header("Option UI")] [SerializeField] private GameObject[] options;
    [Header("Continous Button")] [SerializeField] private GameObject continousButton;

    #endregion

    #region Private Varibale
    private Story currentStory;
    private TextMeshProUGUI[] optionText;
    DialogueTrigger triggerRef;
    #endregion

    #region Public Variable
    public bool dialogueIsPlaying { get; private set;}
    #endregion

    #region Singleton Setting
    private static DialogueManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one dialogue manager in the scene");
        }
        instance = this;
    }
    public static DialogueManager GetInstance()
    {
        return instance;
    }
    #endregion

    #region initialize
    // Start is called before the first frame update
    void Start()
    {
        ToggleDialogueUI(false,"","");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region External Function
    //Enter function for initialize Variable
    public void EnterDialogueMode(TextAsset inkJSON , DialogueTrigger trigger, bool dialogueStateComplete)
    {
        currentStory = new Story(inkJSON.text);
        triggerRef = trigger;

        if (currentStory.canContinue)
        {
            currentStory.variablesState["playerName"] = "Edmund";
            //Check wether the dialogue is complete
            if (dialogueStateComplete)
            {
                currentStory.variablesState["finshedDialogue"] = dialogueStateComplete;
            }
            ContinousStory();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    public void ContinousStory()
    {
        //Check ExitDialog or not 
        if (!currentStory.canContinue && currentStory.currentChoices.Count == 0)
        {
            ExitDialogueMode();
            return;
        }

        //Continous to read next line
        ToggleDialogueUI(true, (string)currentStory.variablesState["speakerName"], currentStory.Continue());

        //Control Continous Button funciton
        if (currentStory.canContinue && currentStory.currentChoices.Count == 0)
        {
            continousButton.SetActive(currentStory.canContinue);
            continousButton.GetComponentInChildren<TextMeshProUGUI>().text = "Continous";
        }
        else
        {
            if (currentStory.currentChoices.Count != 0)
            {
                continousButton.SetActive(currentStory.canContinue);
            }
            else
            {
                continousButton.SetActive(true);
                continousButton.GetComponentInChildren<TextMeshProUGUI>().text = "Close";
            }
        }

        //Tag display test
        if (currentStory.currentTags.Count != 0)
        {
            Debug.Log(currentStory.currentTags[0]);
        }

        //Choices display control setting
        if (currentStory.currentChoices.Count != 0)
        {
            if (currentStory.currentChoices.Count != 2)
            {
                Debug.Log("Warning this Game only support 2 options is each dialog");
            }
            else
            {
                ToggleDisplayOption(true, currentStory.currentChoices[0].text, currentStory.currentChoices[1].text);
            }

        }
        else
        {
            ToggleDisplayOption(currentStory.currentChoices.Count != 0, "", "");
        }
    }

    //On Click Choices Control setting
    public void MakeChoices(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinousStory();
    }

    //Close Dialogue Mode
    public void ExitDialogueMode()
    {
        if ((bool)currentStory.variablesState["finshedDialogue"])
        {
            triggerRef.onDialogueFinshed((bool)currentStory.variablesState["finshedDialogue"]);
        }
        ToggleDialogueUI(false, "", "");
    }

    #endregion

    #region Internal Display Control Function

    private void ToggleDialogueUI(bool toggle, string name, string content)
    {
        if (toggle)
        {
            dialoguePanel.SetActive(true);
            dialogueIsPlaying = true;

            speakerName.SetText(name);
            contentDialogue.SetText(content);
        }
        else
        {
            dialoguePanel.SetActive(false);
            dialogueIsPlaying = false;
        }

    }

    private void ToggleDisplayOption(bool toggle, string option_0, string option_1)
    {
        if (options.Length == 2 && toggle == true)
        {
            options[0].SetActive(true);
            options[0].GetComponentInChildren<TextMeshProUGUI>().SetText(option_0);
            options[1].SetActive(true);
            options[1].GetComponentInChildren<TextMeshProUGUI>().text = option_1;
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
