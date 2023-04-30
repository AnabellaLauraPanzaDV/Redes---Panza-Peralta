using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public struct NetworkInputData : INetworkInput
{
    public float movementInputH, movementInputV;
    public NetworkBool isJumpPessed;
    public NetworkBool isFirePessed;
}
