using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] float _speed = 5f, _jumpForce;
    [SerializeField] Bullet _bulletPrefab;
    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Bullet b = Instantiate(_bulletPrefab);
            b.transform.position = transform.position;
            b.SetDir(transform.forward);
        }


    }

    private void FixedUpdate()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0f, v);

        _rb.velocity = dir * _speed;

        if(dir != Vector3.zero) transform.forward = dir.normalized;
    }
}
