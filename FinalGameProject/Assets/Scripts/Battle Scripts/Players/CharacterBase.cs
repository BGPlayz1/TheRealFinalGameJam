using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Character", menuName = "Character/Create new character")]
public class CharacterBase : ScriptableObject
{
    [SerializeField] new string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;
    [SerializeField] Sprite backSprite;
    [SerializeField] Sprite frontSprite;




    [SerializeField] List<ObtainableWeapon> obtainableWeapons;
    public string Name
    {
        get { return name; }
    }
    public int Defense
    {
        get { return defense; }
    }
    public int SpAttack
    {
        get { return spAttack; }
    }
    public int SpDefense
    {
        get { return spDefense; }
    }
    public int Speed
    {
        get { return speed; }
    }

    public string Description
    {
        get { return description; }
    }

    public int Attack
    {
        get { return attack; }
    }

    public int MaxHp
    {
        get { return maxHp; }
    }
    public Sprite BackSprite
    {
        get { return backSprite; }
    }
    public Sprite FrontSprite
    {
        get { return frontSprite; }
    }





    public List<ObtainableWeapon> ObtainableWeapons
    {
        get { return obtainableWeapons; }
    }



    [System.Serializable]

    public class ObtainableWeapon
    {
        [SerializeField] MoveBase moveBase;
        [SerializeField] int level;

        public int Level
        {
            get { return level; }
        }

        public MoveBase Base
        {
            get { return moveBase ; }
        }
    }


}
