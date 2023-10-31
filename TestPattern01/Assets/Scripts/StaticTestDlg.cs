using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticTestDlg : MonoBehaviour
{
    public Button m_btnResult = null;
    public Button m_btnClear = null;
    public Text m_txtResult = null;

    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        m_btnResult.onClick.AddListener(OnClicked_BtnResult);
        m_btnClear.onClick.AddListener(OnClicekd_BtnClear);
    }
    void OnClicked_BtnResult()
    {
        string resultTxt = string.Empty;
        Score score1 = new Score(90);
        resultTxt += score1.GetScore();
        Score score2 = new Score(80);
        resultTxt += score2.GetScore();
        Score score3 = new Score(95);
        resultTxt += score3.GetScore();

        m_txtResult.text = resultTxt;
    }
    void OnClicekd_BtnClear()
    {
        m_txtResult.text = string.Empty;
    }
}

public class Score
{
    public int m_Score = 0;
    public static int m_Total = 0;

    public string GetScore()
    {
        return $"Score = {m_Score}, Total = {m_Total}\n";
    }

    public Score(int score)
    {
        m_Score = score;
        m_Total += m_Score;
    }
}