using UnityEngine;
using System.Collections;
using System.Linq;

public class IocantCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Iocant, the Oracle";
        cardRace = Enums.Race.Light_Bringer;
        cardCiv = Enums.Civilization.Light;
        cardType = Enums.Type.Creature;
        manaCost = 2;
        cardPower = 2000;
        abilities.Add(new Blocker(this));
        cantAttackPlayers = true;
    }

    //while angel command is in battlefield this gets +2000
    void Update()
    {
        BaseUpdate();
        if (HasAngelCommand()) { cardPower = 4000; }
        else cardPower = 2000;
    }

    private bool HasAngelCommand()
    {
        if (owner.isPlayerOne)
        {
            return owner.battlefield.playerOneCards.Any(x => x.cardRace == Enums.Race.Angel_Command);
        }
        else return owner.battlefield.playerTwoCards.Any(x => x.cardRace == Enums.Race.Angel_Command);
    }

}
