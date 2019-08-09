using System;

namespace Assets.Resources.Scripts.CardScripts.Abilities
{
    [Flags]
    public enum SimpleAbility
    {
        None = 0,
        CantAttackPlayers = 1,
        CantAttack = 2,
        DieOnWin = 4,
        Slayer = 8,
        AttacksEachTurn = 16,
        VulnerableUntapped = 32,
        CanAttackUntapped = 64
        /*
        cantAttackPlayers = false;
        public bool cantAttack = false;
        public bool dieOnWin = false;
        public bool slayer = false;
        public bool attacksEachTurn = false;
        public bool vulnerableUntapped = false;
        public bool canAttackUntapped = false;
    */}
}