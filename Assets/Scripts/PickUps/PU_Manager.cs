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
        if (Input.GetKeyDown(KeyCode.P)) StartCoroutine(TimerSpawnShield());
        if (Input.GetKeyDown(KeyCode.O)) SpawnStar();
    }

    IEnumerator TimerSpawnShield()
    {
        yield return new WaitForSeconds(5);
        SpawnShield();
    }

    public void SpawnShield()
    {
        var pos = GetRandomPos();

        var shield = Runner.Spawn(_shieldPrefab);
        shield.transform.position = pos;
    }

    public void SpawnStar()
    {
        var pos = GetRandomPos();

        var star = Runner.Spawn(_starPrefab);
        star.transform.position = pos;
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
