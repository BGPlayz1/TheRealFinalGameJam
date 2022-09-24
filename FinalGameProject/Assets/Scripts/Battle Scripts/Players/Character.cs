using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    CharacterBase _base;
    int level;

    public Character (CharacterBase pBase, int pLevel)
    {
        _base = pBase;
        level = pLevel;
    }
}


