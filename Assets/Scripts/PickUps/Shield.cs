using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Shield : NetworkBehaviour
{
    public GameObject GO_Shield;
    public float _duration, maxHits, coolDown;

    bool _canUse = true;
    public float hits;

    private void Start()
    {
        GO_Shield.gameObject.SetActive(false);
        GO_Shield.GetComponent<GO_Shield>().shield = this;
    }

    public void ShieldPressed()
    {
        if (!_canUse) return;
        ActivateShield();
    }

    public void ActivateShield()
    {
        RPC_ActivateShield();
        _canUse = false;
        StartCoroutine(StartTimer());
    }

    public void DeactivateShield()
    {
        RPC_DeactivateShield();
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(_duration);
        DeactivateShield();
        yield return new WaitForSeconds(coolDown);
        _canUse = true;
    }    

    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    void RPC_ActivateShield()
    {
        GO_Shield.gameObject.SetActive(true);
    }

    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    void RPC_DeactivateShield()
    {
        GO_Shield.gameObject.SetActive(false);
    }

    
}
