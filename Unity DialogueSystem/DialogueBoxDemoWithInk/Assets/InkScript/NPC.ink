VAR speakerName = ""
VAR playerName = ""
VAR finshedDialogue = false

=== mianDialouge === 

Hi {playerName}, I am {speakerName}, do you wanna drink a tea with me?
 * [Yes I want it]
    That Great Let's drug -> yesOption
 * [No Thanks]
    Go Away you bitch -> noOption
    
=== yesOption ===
finshedDialogue = false
->DONE

=== noOption === 
finshedDialogue = true
->DONE

-> END
