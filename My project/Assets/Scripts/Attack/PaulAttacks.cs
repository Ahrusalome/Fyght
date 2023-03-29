using UnityEngine;

public class PaulAttacks : Attack
{
    public bool OnJuice = false;
    public bool Drunk = false;
    private Stats stats;
    public override void DownDownMD() {
        stats = playerAttack.GetComponent<Stats>();
        base.DownDownMD();
        if (OnJuice == true) {
            stats.speed = 12;
            stats.attack = 14;
            stats.defense = 15;
            stats.dexterity = 10;
            OnJuice = false;
        } else {
            stats.speed = 14;
            stats.attack = 11;
            stats.defense = 13;
            stats.dexterity = 13;
            OnJuice = true;
        }
        Drunk = false;
    }
    public override void DownDownLD()
    {
        base.DownDownLD();
        if (Drunk == true) {
            stats.speed = 12;
            stats.attack = 14;
            stats.defense = 15;
            stats.dexterity = 10;
            Drunk = false;
        } else {
            stats.speed = 10;
            stats.attack = 18;
            stats.defense = 15;
            stats.dexterity = 8;
            Drunk = true;
        }
        OnJuice = false;
    }
}

