using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PowerUps : MonoBehaviour
{
    protected Player _pl;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out _pl))
        {
            PU_Action();
            Destroy(gameObject);
        }
    }

    public virtual void PU_Action()
    {

    }
}
