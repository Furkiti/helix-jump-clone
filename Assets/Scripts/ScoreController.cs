using System.Collections;
using System.Collections.Generic;
using Start.Base;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : BaseObject
{
    [SerializeField] private int scoreAmount = 1;
    private int _score;
    private int _highScore;
    
    [SerializeField] private Text textScore;
    [SerializeField] private Text textHighScore;
    
    
    public void AddScore()
    {
        _score += scoreAmount;
        textScore.text = _score.ToString();
        CheckHighScore(_score);
    }

    private void CheckHighScore(int currentScore)
    {
        if (currentScore > _highScore)
        {
            _highScore = currentScore;
            textHighScore.text = _highScore.ToString();
        }
    }
    
    public int GetScore()
    {
        return _score;
    }

    public void SetScore()
    {
        _score = 0;
        textScore.text = _score.ToString();
    }
    
    public int GetHighScore()
    {
        return _highScore;
    }

    public void SetHighScore(int savedHighScore)
    {
        _highScore = savedHighScore;
        textHighScore.text = _highScore.ToString();
    }
}
