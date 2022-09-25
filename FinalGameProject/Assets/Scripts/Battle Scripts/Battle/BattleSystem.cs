using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum BattleState { Start, PlayerAction, PlayerMove, EnemyMove, Busy}


public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;
    [SerializeField] BattleDialogBox dialogBox;

    BattleState state;
    int currentAction;

    private void Start()
    {   
        StartCoroutine (SetupBattle());
    }

    public IEnumerator SetupBattle()
    {
        playerUnit.Setup();
        enemyUnit.Setup();
        playerHud.SetData(playerUnit.Character);
        enemyHud.SetData(enemyUnit.Character);

        yield return (dialogBox.TypeDialog($"{enemyUnit.Character.Base.Name} has challenged you to a battle."));
        yield return new WaitForSeconds(1);

        PlayerAction();

    }

    void PlayerAction()
    {
        state = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Choose an action"));
        dialogBox.EnableActionSelector(true);
    }

    private void Update()
    {
        if(state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
    }

    void HandleActionSelection()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAction < 1)
            ++currentAction;
        }
        
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAction > 0)
                --currentAction;
        }



    }  

}
