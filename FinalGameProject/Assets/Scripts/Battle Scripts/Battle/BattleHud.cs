using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] HPBar hpBar;

    Character _character;

    public void SetData(Character character)
    {

        _character = character;
        Debug.Log($"Your HP is {character.HP}");
        nameText.text = character.Base.Name;
        hpBar.SetHP((float) character.HP / character.Base.MaxHp);
    }
        
    public void UpdateHP(Character character)
    {
       
        hpBar.SetHP((float) character.HP / character.Base.MaxHp);
    }
}
