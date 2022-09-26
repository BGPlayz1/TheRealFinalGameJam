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
    Character character;

    BattleState state;
    int currentAction;
    int currentMove;

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

        dialogBox.SetMoveNames(playerUnit.Character.Moves);

        yield return (dialogBox.TypeDialog($"{enemyUnit.Character.Base.Name} has challenged you to a battle."));
        yield return new WaitForSeconds(1);

        PlayerAction();

    }

    void PlayerAction()
    {
        state = BattleState.PlayerAction;
        Debug.Log($"Your new hp is {playerUnit.Character.HP}");
        StartCoroutine(dialogBox.TypeDialog("Choose an action"));
        dialogBox.EnableActionSelector(true);
    }

    void PlayerMove()
    {
        state = BattleState.PlayerMove;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableMoveSelector(true);
    }

    IEnumerator PerformPlayerMove()
    {
        state = BattleState.Busy;

        var move = playerUnit.Character.Moves[currentMove];
        yield return dialogBox.TypeDialog($"{playerUnit.Character.Base.Name} used {move.Base.Name}");
        yield return new WaitForSeconds(1);

        bool isFainted = enemyUnit.Character.TakeDamage(move, playerUnit.Character);
        enemyHud.UpdateHP(enemyUnit.Character);

        if (isFainted)
        {
            yield return dialogBox.TypeDialog($"{enemyUnit.Character.Base.Name} Fainted");
        }
        else
        {
            StartCoroutine(EnemyMove());
        }

        IEnumerator EnemyMove()
        {
            state = BattleState.EnemyMove;

            var move = enemyUnit.Character.GetRandomMove();

            yield return dialogBox.TypeDialog($"{enemyUnit.Character.Base.Name} used {move.Base.Name}");
            yield return new WaitForSeconds(1);

            bool isFainted = playerUnit.Character.TakeDamage(move, enemyUnit.Character);
            playerHud.UpdateHP(playerUnit.Character);

            if (isFainted)
            {
                yield return dialogBox.TypeDialog($"{playerUnit.Character.Base.Name} Fainted");
            }
            else
            {
                PlayerAction();
            }
        }

    }

    private void Update()
    {
        if(state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
        else if (state == BattleState.PlayerMove)
        {
            HandleMoveSelection();
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

        dialogBox.UpdateActionSelection(currentAction);

        if (Input.GetKeyDown(KeyCode.E))
        if (currentAction == 0)
        {
                PlayerMove();
        }
        else if (currentAction == 0)
        {

        }
    }  

   void HandleMoveSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentMove < playerUnit.Character.Moves.Count - 1)
                ++currentMove;
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentMove > 0)
                --currentMove;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentMove < playerUnit.Character.Moves.Count - 2)
                currentMove += 2;
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentMove > 1)
                currentMove -= 2;
        }

        dialogBox.UpdateMoveSelection(currentMove, playerUnit.Character.Moves[currentMove]);     

        if (Input.GetKeyDown(KeyCode.E))
        {
            dialogBox.EnableMoveSelector(false);
            dialogBox.EnableDialogText(true);
            StartCoroutine(PerformPlayerMove());

        }
    }

}
