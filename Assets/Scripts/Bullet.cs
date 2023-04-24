using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _timeToDestroy = 5f, _speed = 7f;
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

}
