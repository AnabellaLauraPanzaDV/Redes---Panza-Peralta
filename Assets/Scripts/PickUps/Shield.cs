using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Shield : NetworkBehaviour
{
    [SerializeField] GameObject GO_Shield;
    [SerializeField] float _duration, maxHits;
    float hits;

    private void Start()
    {
        GO_Shield.gameObject.SetActive(false);
    }

    public void ActivateShield()
    {
        GO_Shield.gameObject.SetActive(true);
        StartCoroutine(StartTimer());
    }

    public void DeactivateShield()
    {
        GO_Shield.gameObject.SetActive(false);
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(_duration);
        DeactivateShield();
    }

    
}
