using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Bullet : NetworkBehaviour
{
    [SerializeField] NetworkRigidbody _rgbd;
    [SerializeField] float _timeToDestroy = 5f, _speed = 7f, _dmg;
    float _timer = 0f;
    IDamageable _pl;
    GameObject _GO_Shield;

    private void Start()
    {
        _rgbd.Rigidbody.AddForce(transform.forward * 10f, ForceMode.VelocityChange);
    }

    public void GetPlayer(Player pl) { _pl = pl; _GO_Shield = pl.GetComponent<Shield>().GO_Shield; }


    private void Update()
    {
        _timer += Time.deltaTime;

        if(_timer >= _timeToDestroy)
        {
            Runner.Despawn(Object);
        }

        //transform.position += transform.forward.normalized * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!Object || !Object.HasStateAuthority) return;

        if (other.gameObject == _GO_Shield) return;

        if(other.TryGetComponent(out IDamageable damageable))
        {
            if (damageable == _pl) return;
            damageable.TakeDamage(_dmg);
        }

        Runner.Despawn(Object);
    }

}
