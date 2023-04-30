using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PU_Manager : NetworkBehaviour
{
    [SerializeField] float _limitX, _limitZ, _varY;
    [SerializeField] Transform _floor;
    [SerializeField] PowerUps _shieldPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) SpawnShield();
    }

    public void SpawnShield()
    {
        float posX = Random.Range(_limitX / 2, -_limitX / 2);
        float posZ = Random.Range(_limitZ / 2, -_limitZ / 2);
        var pos = new Vector3(posX, _floor.position.y + _varY, posZ);

        var shield = Runner.Spawn(_shieldPrefab);
        shield.transform.position = pos;

    }

}
