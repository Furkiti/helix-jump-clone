using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveDatas
{
    private int _savedHighScore;

    
    public int GetSavedHighScore()
    {
        return _savedHighScore;
    }

    public void SetSavedHighScore()
    {
        _savedHighScore = GameManager.Instance.GetScoreController().GetHighScore();
    }
}