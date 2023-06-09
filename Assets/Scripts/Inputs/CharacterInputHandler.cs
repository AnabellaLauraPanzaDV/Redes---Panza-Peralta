using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputHandler : MonoBehaviour
{
    Player _pl;

    NetworkInputData _inputData;

    float _moveInputH, _moveInputV;
    bool _isFirePressed, _isJumpPressed, _isShieldPressed;

    private void Start()
    {
        _pl = GetComponent<Player>();
        _inputData = new NetworkInputData();
    }

    private void Update()
    {
        if (!_pl.HasInputAuthority) return;

        _moveInputH = Input.GetAxis("Horizontal");
        _moveInputV = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJumpPressed = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            _isFirePressed = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _isShieldPressed = true;
        }
    }

    public NetworkInputData GetNetworkInput() 
    {
        _inputData.movementInputH = _moveInputH;
        _inputData.movementInputV = _moveInputV;

        _inputData.isJumpPessed = _isJumpPressed;
        _isJumpPressed = false;

        _inputData.isFirePessed = _isFirePressed;
        _isFirePressed = false;

        _inputData.isShieldPressed = _isShieldPressed;
        _isShieldPressed = false;

        return _inputData;
    }
}
