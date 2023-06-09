using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Player : NetworkBehaviour, IDamageable
{
    [SerializeField] float _speed = 5f, _jumpForce, _maxLife;
    [SerializeField] Bullet _bulletPrefab;
    [SerializeField] ParticleSystem _shootParticle;
    [SerializeField] ParticleSystem _shootParticle2;
    [SerializeField] Transform _shootPos;
    

    bool _canJump;

    [Networked(OnChanged = nameof(LifeChangedCallback))]
    float _currentLife { get; set; }

    Shield _shield;
    NetworkRigidbody _rb;

    NetworkInputData _networkInputData;

    float _lastFireTime;
    [Networked(OnChanged = nameof(ShootChangedCallback))] bool isFiring { get; set; }

    private void Start()
    {
        _currentLife = _maxLife;
        _rb = GetComponent<NetworkRigidbody>();
        _shield = GetComponent<Shield>();
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out _networkInputData))
        {
            Movement(_networkInputData.movementInputH, _networkInputData.movementInputV);

            if (_networkInputData.isJumpPessed)
            {
                Jump();
            }

            if (_networkInputData.isFirePessed)
            {
                Shoot();
            }

            if (_networkInputData.isShieldPressed)
            {
                UseShield();
            }
        }
        
    }

    void Movement(float _h, float _v)
    {
        Vector3 dir = Vector3.forward * _v + Vector3.right * _h;

        _rb.Rigidbody.MovePosition(transform.position + dir * _speed * Time.fixedDeltaTime);

        if (dir != Vector3.zero)
        {
            transform.forward = dir.normalized;
        }
    }

    void Jump()
    {
        if (!_canJump) return;
        _rb.Rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
        _canJump = false;
    }


    void Shoot()
    {
        if (Time.time - _lastFireTime < 0.15f) return;

        _lastFireTime = Time.time;

        StartCoroutine(ShootCD());

        Bullet b = Runner.Spawn(_bulletPrefab , _shootPos.position , transform.rotation);
        b.GetPlayer(this);
    }

    void UseShield()
    {
        _shield.ShieldPressed();
    }

    public void TakeDamage(float dmg)
    {
        RPC_GetHit(dmg);
    }


    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    void RPC_GetHit(float dmg)
    {
        _currentLife -= dmg;

        if (_currentLife <= 0) Dead();
    }

    static void LifeChangedCallback(Changed<Player> changed)
    {

    }

    void Dead()
    {
        Runner.Shutdown();
    }

    IEnumerator ShootCD()
    {
        isFiring = true;        

        yield return new WaitForSeconds(0.15f);

        isFiring = false;
    }

    static void ShootChangedCallback(Changed<Player> changed)
    {
        bool _currentFire = changed.Behaviour.isFiring;

        changed.LoadOld();

        bool previousFire = changed.Behaviour.isFiring;

        if(!previousFire && _currentFire)
        {
            changed.Behaviour._shootParticle.Play();
            changed.Behaviour._shootParticle2.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor") _canJump = true;
    }

}
