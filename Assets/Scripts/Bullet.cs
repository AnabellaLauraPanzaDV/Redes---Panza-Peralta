using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Bullet : NetworkBehaviour
{
    [SerializeField] float _timeToDestroy = 5f, _speed = 7f, _dmg;
    float _timer = 0f;
    Vector3 _dir;

    public void SetDir(Vector3 dir) { _dir = dir; }

    private void Update()
    {
        _timer += Time.deltaTime;

        if(_timer >= _timeToDestroy)
        {
            Destroy(gameObject);
        }

        transform.position += _dir.normalized * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!Object || !Object.HasStateAuthority) return;

        if(other.TryGetComponent(out Player enemy))
        {
            enemy.TakeDamage(_dmg);
        }

        Runner.Despawn(Object);
    }

}
