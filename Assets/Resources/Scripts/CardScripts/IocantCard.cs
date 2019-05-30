using UnityEngine;
using System.Collections;
using System.Linq;

public class IocantCard : Card
{

    void Start()
    {
        BaseStart();
        cardName = "Iocant, the Oracle";
        cardRace = Race.Light_Bringer;
        cardCiv = Civilization.Light;
        cardType = Type.Creature;
        cardCost = 2;
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
        return owner.field.Any(x => x.cardRace == Race.Angel_Command);
    }

}
