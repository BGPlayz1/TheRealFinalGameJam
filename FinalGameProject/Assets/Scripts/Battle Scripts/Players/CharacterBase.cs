using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Character", menuName = "Character/Create new character")]
public class CharacterBase : ScriptableObject
{
    [SerializeField] new string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] int health;
    [SerializeField] Sprite sprite;

    public bool obtainedSword = false;


    [SerializeField] List<ObtainableWeapon> obtainableWeapons;
    public string Name
    {
        get { return name; }
    }

    public string Description
    {
        get { return description; }
    }

    public int Health
    {
        get { return health; }
    }
    public Sprite Sprite
    {
        get { return sprite; }
    }

    public bool ObtainedSword
    {
        get { return obtainedSword; }
        set
        {
            obtainedSword = value;
        }
    }



    public List<ObtainableWeapon> ObtainableWeapons
    {
        get { return obtainableWeapons; }
    }



    [System.Serializable]

    public class ObtainableWeapon { }

}
