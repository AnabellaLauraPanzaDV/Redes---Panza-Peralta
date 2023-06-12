using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] GameObject victory_TextGO, defeat_textGO, shieldCD_ImageGO, shieldKEY_ImageGO;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        victory_TextGO.SetActive(false);
        defeat_textGO.SetActive(false);
        shieldCD_ImageGO.SetActive(false);
    }

    public void Victory()
    {
        victory_TextGO.SetActive(true);
    }

    public void Defeat()
    {
        defeat_textGO.SetActive(true);
    }

    public void ShieldCoolDown(bool status)
    {
        shieldCD_ImageGO.SetActive(status);
        shieldKEY_ImageGO.SetActive(!status);
    }

}
