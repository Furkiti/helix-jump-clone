using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPart : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void HittedDeathPart()
    {
        GameManager.Instance.GetUIController().RestartLevel();
    }
}
