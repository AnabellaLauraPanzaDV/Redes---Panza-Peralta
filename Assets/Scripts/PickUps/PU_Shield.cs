using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_Shield : PowerUps
{
    [SerializeField] Shield _shield;

    public override void PU_Action()
    {
        _shield.ActivateShield();
    }

}
