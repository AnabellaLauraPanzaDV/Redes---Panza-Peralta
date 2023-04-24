using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PU_Action();
            Destroy(gameObject);
        }
    }

    public virtual void PU_Action()
    {

    }
}
