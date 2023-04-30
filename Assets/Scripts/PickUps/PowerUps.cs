using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PowerUps : NetworkBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!Object || !Object.HasStateAuthority) return;
        if (other.tag == "Player")
        {
            PU_Action();
            Runner.Despawn(Object);
        }
    }

    public virtual void PU_Action()
    {

    }
}
