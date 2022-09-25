using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public CharacterBase Base { get; set; }
    public int Level { get; set; }

    public int HP { get; set; }
    public List<Move>Moves { get; set; }
    public Character (CharacterBase pBase, int pLevel)
    {
        Base = pBase;
        Level = pLevel;

        Moves = new List<Move>();
        foreach (var move in Base.ObtainableWeapons)
        {
            if (move.Level <= Level)
                Moves.Add(new Move(move.Base));
        }
    }

   
}


