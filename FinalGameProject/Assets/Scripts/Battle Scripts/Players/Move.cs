using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move
{
    public MoveBase Base { get; set; }

    public Move(MoveBase wBase)
    {
        Base = wBase;
    }

}
