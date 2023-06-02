using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PU_Manager : NetworkBehaviour
{
    [SerializeField] float _limitX, _limitZ, _varY;
    [SerializeField] Transform _floor;
    [SerializeField] PowerUps _shieldPrefab, _starPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) SpawnShield();
        if (Input.GetKeyDown(KeyCode.O)) SpawnStar();
    }

    IEnumerator TimerSpawnShield()
    {
        yield return new WaitForSeconds(5);
        SpawnShield();
    }

    public void SpawnShield()
    {
        RPC_SpawnShield();
    }

    [Rpc(RpcSources.All, RpcTargets.Proxies)]
    void RPC_SpawnShield()
    {
        var pos = GetRandomPos();
        Runner.Spawn(_shieldPrefab, pos);
    }

    

    public void SpawnStar()
    {
        var pos = GetRandomPos();
        Runner.Spawn(_starPrefab, pos);
    }

    Vector3 GetRandomPos()
    {
        Vector3 spawnPos;

        float posX = Random.Range(_limitX / 2, -_limitX / 2);
        float posZ = Random.Range(_limitZ / 2, -_limitZ / 2);
        spawnPos = new Vector3(posX, _floor.position.y + _varY, posZ);

        return spawnPos;
    }

}
