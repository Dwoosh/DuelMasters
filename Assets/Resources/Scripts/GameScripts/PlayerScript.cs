using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> hand = new List<Card>();
    public ShieldZone shieldZone = new ShieldZone();
    public ManaZone manaZone = new ManaZone();
    public Graveyard graveyard = new Graveyard();
    public List<Card> field { get; set; }

    public Battlefield battlefield;
    public EventManager eventManager;
    public bool isPlayerOne;

    private const float cardSizeX = 2f;
    private const float cardSizeY = 0.1f;
    private const float cardSizeZ = 3f;

    void Start()
    {
        FillDeck();
        if (name == "PlayerOne")
        {
            isPlayerOne = true;
            field = battlefield.playerOneCards;
        }
        else
        {
            isPlayerOne = false;
            field = battlefield.playerTwoCards;
            RotateDeck();
        }
        SetUpShields();
        DrawCard(5);
        SetAllPositions();
    }

    public void FillDeck()
    {
        for (int i = 0; i < 40; ++i)
        {
            Card card = Instantiate(Resources.Load<Card>("Prefabs/IereCard"));
            deck.Add(card);
            card.SetOwner(this);
        }
    }

    public void SetUpShields()
    {
        for (int i = 0; i < 5; ++i)
        {
            var card = deck[0];
            deck.RemoveAt(0);
            shieldZone.AddShield(card);
        }
    }

    public void DrawCard(int count = 1)
    {
        if (count < 1)
        {
            return;
        }
        for (int i = 0; i < count; ++i)
        {
            var card = deck[0];
            deck.RemoveAt(0);
            hand.Add(card);
        }
    }

    //TODO: to be removed
    public Card GetCardFromList(ref List<Card> cards, int index)
    {
        var card = cards[index];
        cards.RemoveAt(index);
        return card;
    }
    //TODO: to be removed
    public void AddCardToList(ref List<Card> cards, Card card)
    {
        cards.Add(card);
    }

    /*
    Card control methods
    Abilities needs to be activated from EventManager in these methods
    */
    public void RemoveDeckAddHand(int index)
    {
        var card = deck[index];
        deck.Remove(card);
        hand.Add(card);
        SetDeckPositions();
        SetHandPositions();
    }

    public void RemoveDeckAddMana(int index = 0)
    {
        if(deck.Count == 0) { return; }
        var card = deck[index];
        deck.Remove(card);
        manaZone.AddCardToManaZone(card);
        SetDeckPositions();
        SetManaPositions();
    }
    
    public void RemoveHandAddMana(int index)
    {
        var card = hand[index];
        hand.Remove(card);
        manaZone.AddCardToManaZone(card);
        SetHandPositions();
        SetManaPositions();
    }

    public void RemoveHandAddMana(Card card)
    {
        hand.Remove(card);
        manaZone.AddCardToManaZone(card);
        SetHandPositions();
        SetManaPositions();
    }

    public void RemoveHandAddGraveyard(int index)
    {
        var card = hand[index];
        hand.Remove(card);
        graveyard.AddCardToGraveyard(card);
        SetHandPositions();
        SetGraveyardPositions();
    }

    public void RemoveHandAddField(int index)
    {
        var card = hand[index];
        hand.RemoveAt(index);
        SetHandPositions();
        field.Add(card);
        battlefield.SetPositions();
        card.OnCall();
        eventManager.CallOnCallEvent();
        card.OnAfterCall();
    }

    public void RemoveHandAddField(Card card)
    {
        hand.Remove(card);
        field.Add(card);
        battlefield.SetPositions();
        card.OnCall();
        eventManager.CallOnCallEvent();
        card.OnAfterCall();
    }

    public void RemoveManaAddHand(int index)
    {
        var card = manaZone.RemoveCardFromManaZone(index);
        SetManaPositions();
        hand.Add(card);
        SetHandPositions();
    }

    public void RemoveManaAddGraveyard(int index)
    {
        var card = manaZone.RemoveCardFromManaZone(index);
        graveyard.AddCardToGraveyard(card);
        SetManaPositions();
        SetGraveyardPositions();
    }

    public void RemoveManaAddGraveyard(Card card)
    {
        manaZone.RemoveCardFromManaZone(card);
        graveyard.AddCardToGraveyard(card);
        SetManaPositions();
        SetGraveyardPositions();
    }

    public void RemoveFieldAddHand(Card card)
    {
        field.Remove(card);
        hand.Add(card);
        battlefield.SetPositions();
        SetHandPositions();
    }

    public void RemoveFieldAddGraveyard(Card card)
    {
        field.Remove(card);
        graveyard.AddCardToGraveyard(card);
        battlefield.SetPositions();
        SetGraveyardPositions();
        card.OnDeath();
        eventManager.CallOnDeathEvent();
        card.OnAfterDeath();
    }

    public void RemoveFieldAddMana(Card card)
    {
        field.Remove(card);
        manaZone.AddCardToManaZone(card);
        battlefield.SetPositions();
        SetManaPositions();
    }

    public void RemoveShieldAddHand(int index)
    {
        StageFSM.fightChooseStage.selectedCardToFight.OnShieldAttack();
        eventManager.CallOnShieldAttackEvent();
        StageFSM.fightChooseStage.selectedCardToFight.OnAfterShieldAttack();

        var card = shieldZone.RemoveShield(index);
        hand.Add(card);

        card.OnShieldDestroyed();
        eventManager.CallOnShieldDestroyedEvent();
        card.OnAfterShieldDestroyed();

        SetShieldPositions();
        SetHandPositions();
    }

    public void RemoveGraveyardAddHand(Card card)
    {
        graveyard.RemoveCardFromGraveyard(card);
        SetGraveyardPositions();
        hand.Add(card);
        SetHandPositions();
    }

    public void RemoveGraveyardAddMana(Card card)
    {
        graveyard.RemoveCardFromGraveyard(card);
        SetGraveyardPositions();
        manaZone.AddCardToManaZone(card);
        SetManaPositions();
    }

    /*
    Fields interaction methods 
    */

    public Card GetDeckAt(int index)
    {
        if(index >= GetDeckCount()) { return null; }
        return deck[index];
    }
    
    public int GetDeckCount()
    {
        return deck.Count;
    }

    public Card GetHandAt(int index)
    {
        if (index >= GetHandCount()) { return null; }
        return hand[index];
    }

    public int GetHandCount()
    {
        return hand.Count;
    }

    public Card GetManaAt(int index)
    {
        if (index >= GetManaCount()) { return null; }
        return manaZone.cards[index];
    }

    public int GetManaCount()
    {
        return manaZone.cards.Count;
    }

    public void FinalizeManaTap()
    {
        manaZone.FinalizeManaTap();
    }

    public Card GetShieldAt(int index)
    {
        if (index >= GetShieldCount()) { return null; }
        return shieldZone.shields[index];
    }

    public int GetShieldCount()
    {
        return shieldZone.shields.Count;
    }

    public Card GetFieldAt(int index)
    {
        if (index >= GetFieldCount()) { return null; }
        return field[index];
    }

    public int GetFieldCount()
    {
        return field.Count;
    }

    public bool IsFieldNotEmpty()
    {
        return field.Count != 0;
    }
    
    public Card GetGraveAt(int index)
    {
        if (index >= GetGraveCount()) { return null; }
        return graveyard.cards[index];
    }

    public int GetGraveCount()
    {
        return graveyard.cards.Count;
    }

    public void ActOnField(System.Action<Card> action)
    {
        field.ForEach(action);
    }

    /*
    Other methods 
    */

    //Turn events are active only on current player turn
    public void SubscribeToTurnEvents()
    {
        for (int i = 0; i < GetFieldCount(); ++i)
        {
            GetFieldAt(i).SubscribeToTurnEvents();
        }
    }

    public void UnsubscribeToTurnEvents()
    {
        for (int i = 0; i < GetFieldCount(); ++i)
        {
            GetFieldAt(i).UnsubscribeToTurnEvents();
        }
    }

    //Odd turn events are active only on other player turn
    public void SubscribeToOddTurnEvents()
    {
        for (int i = 0; i < GetFieldCount(); ++i)
        {
            GetFieldAt(i).SubscribeToOddTurnEvents();
        }
    }

    public void UnsubscribeToOddTurnEvents()
    {
        for (int i = 0; i < GetFieldCount(); ++i)
        {
            GetFieldAt(i).UnsubscribeToOddTurnEvents();
        }
    }


    public void SetAllPositions()
    {
        SetDeckPositions();
        SetHandPositions();
        SetShieldPositions();
        SetManaPositions();
        SetGraveyardPositions();
        battlefield.SetPositions();
    }

    public void SetHandPositions()
    {
        var cnt = hand.Count;
        for (int i = 0; i < cnt; ++i)
        {
            if (isPlayerOne)
            {
                hand[i].transform.position = new Vector3(173f + cardSizeX + i * 5f, 155f, 127f + cardSizeZ);
            }
            else
            {
                hand[i].transform.position = new Vector3(239f - cardSizeX - i * 5f, 155f, 173f - cardSizeZ);
            }
        }
    }

    public void SetDeckPositions()
    {
        var cnt = deck.Count;
        for (int i = cnt - 1; i > 0; --i)
        {
            if (isPlayerOne)
            {
                deck[i].transform.position = new Vector3(218f, 155f + i * cardSizeY, 138f);
            }
            else
            {
                deck[i].transform.position = new Vector3(194f, 155f + i * cardSizeY, 162f);
            }
        }
    }

    public void SetShieldPositions()
    {
        shieldZone.SetPositions(isPlayerOne);
    }

    public void SetManaPositions()
    {
        manaZone.SetPositions(isPlayerOne);
    }

    public void SetGraveyardPositions()
    {
        graveyard.SetPositions(isPlayerOne);
    }

    private void RotateDeck()
    {
        var cnt = deck.Count;
        for (int i = 0; i < cnt; ++i)
        {
            deck[i].transform.eulerAngles = deck[i].transform.eulerAngles + 180f * Vector3.up;
        }
    }

}