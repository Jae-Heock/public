using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int mScore, mClearScore;

    [SerializeField]
    private Text mScoreText, mFinishText;

    private void Start()
    {
        mScore = 0;
        mScoreText.text = "Score :" + mScore.ToString();
        mFinishText.text = "";
        Time.timeScale = 1;
    }

    public void AddScore(int value)
    {
        mScore += value;
        mScoreText.text = "Score: " + mScore.ToString();  // 점수 업데이트

        if (mScore >= mClearScore)
        {
            mFinishText.text = "Clear!";
            Debug.Log("Clear");
            Time.timeScale = 0;
        }
    }

}
