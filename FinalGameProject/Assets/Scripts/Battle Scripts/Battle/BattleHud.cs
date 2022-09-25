using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] HPBar hpBar;

    public void SetData(Character character)
    {
        nameText.text = character.Base.Name;
        hpBar.SetHP((float)character.HP);
    }
}
