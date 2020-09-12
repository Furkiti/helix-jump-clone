using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.GetScoreController().AddScore();
    }
}
