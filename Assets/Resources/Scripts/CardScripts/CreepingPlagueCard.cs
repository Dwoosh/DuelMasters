using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreepingPlagueCard : SpellCard
{
    //Whenever any of your creatures becomes blocked this turn, it gets "slayer" until the end of the turn. 
    //(When a creature that has "slayer" loses a battle, destroy the other creature.)
    void Start()
    {
        SpellStart();
        cardName = "Creeping Plague";
        cardCiv = Civilization.Darkness;
        cardCost = 1;
    }

    public override void SpellAbility()
    {
        StartCoroutine(AbilityCoroutine(owner));
    }
    
    public IEnumerator AbilityCoroutine(PlayerScript currentPlayer)
    {
        StageFSM stageFSM = GameStage.stageFSM;
        List<Card> cards = new List<Card>();
        Card chosenCard = null;
        while (true)
        {
            if (stageFSM.currentGameStage == StageFSM.fightChooseStage && cards.Count == 0)
            {
                currentPlayer.field.ForEach(x => { if (!x.slayer) { cards.Add(x); } }); //get cards that doesnt have slayer
            }
            if(stageFSM.currentGameStage == StageFSM.blockerStage)
            {
                if (StageFSM.blockerStage.wasBlocked) { chosenCard.slayer = true; } //give slayer if card was blocked
            }
            if(stageFSM.currentGameStage == StageFSM.endStage) //undo slayers at the end of the turn
            {
                cards.ForEach(x => x.slayer = false);
                break;
            }
            yield return null;
        }
    }
}
