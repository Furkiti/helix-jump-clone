using System.Collections;
using System.Collections.Generic;
using Start.Base;
using UnityEngine;
using UnityEngine.UI;

public class UIController : BaseObject
{

    [SerializeField] private Text textDeadScore;
    [SerializeField] private Canvas deadCanvas;
   public void RestartLevel()
   {
      Debug.Log("game is over");
      //GameManager.Instance.GetScoreController().SetScore();
      GameManager.Instance.GetBaseObject(4).GetComponent<BallController>().ResetBallPos();
     
      deadCanvas.gameObject.SetActive(true);
      textDeadScore.text = GameManager.Instance.GetScoreController().GetScore().ToString();
   }
}
