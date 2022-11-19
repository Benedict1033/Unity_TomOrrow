using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour
{
    Image hpbar;

    public static float HP;

    void Start()
    {
        hpbar = GetComponent<Image>();
        HP = 1f;
    }

    void Update()
    {
        hpbar.fillAmount = HP;
    }
}