using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] GameObject GO_Shield;
    [SerializeField] float _duration, maxHits;
    float hits;

    private void Start()
    {
        GO_Shield.SetActive(false);
    }

    public void ActivateShield()
    {
        GO_Shield.SetActive(true);
        StartCoroutine(StartTimer());
    }

    public void DeactivateShield()
    {
        GO_Shield.SetActive(false);
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(_duration);
        DeactivateShield();
    }

    
}
