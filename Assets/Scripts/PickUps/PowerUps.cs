using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PowerUps : NetworkBehaviour
{
    protected Player _pl;

    private void OnTriggerEnter(Collider other)
    {
        if (!Object || !Object.HasStateAuthority) return;
        if (other.TryGetComponent(out _pl))
        {
            PU_Action();
            Runner.Despawn(Object);
        }
    }

    public virtual void PU_Action()
    {

    }
}
