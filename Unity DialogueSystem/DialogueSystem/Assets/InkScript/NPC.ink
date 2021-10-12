VAR speakerName = "NPCName"
VAR playerName = ""
VAR finshedDialogue = false

{finshedDialogue: ->CompleteDialogue|-> mianDialouge}
->mianDialouge
=== mianDialouge === 
Hi {playerName}, I am {speakerName}, do you wanna drink a tea with me? #Tage1
Otherwise please go aways #Tage2
 * [Yes I want it]
    That Great Let's drug -> yesOption
 * [No Thanks]
    Go Away you bitch -> noOption
    
=== yesOption ===
~  finshedDialogue = false
->DONE

=== noOption === 
~ finshedDialogue = true
->DONE

=== CompleteDialogue ===
You Have Already tea the tea

-> END
