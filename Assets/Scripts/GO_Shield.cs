using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class GO_Shield : NetworkBehaviour, IDamageable
{
    public Shield shield;

    public void TakeDamage(float dmg)
    {
        RPC_GetHit();
    }

    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    void RPC_GetHit()
    {
        shield.hits++;

        if (shield.hits >= shield.maxHits)
        {
            shield.hits = 0;
            shield.DeactivateShield();
        }
    }
}
