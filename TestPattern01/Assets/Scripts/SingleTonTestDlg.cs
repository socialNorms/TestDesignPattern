using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleTonTestDlg : MonoBehaviour
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
        m_btnClear.onClick.AddListener(OnClicked_BtnClear);
    }

    void OnClicked_BtnResult()
    {
        int gameMgr = GameMgr.Inst.m_TestScore.m_Score = 1;
        int gameMaanger = GameManager.Inst().m_TestScore.m_Score = 2;


        m_txtResult.text = $"{gameMgr}, {gameMaanger}";
    }

    void OnClicked_BtnClear()
    {
        GameMgr.Inst.m_TestScore.m_Score = 0;
        GameManager.Inst().m_TestScore.m_Score = 0;

        m_txtResult.text = string.Empty;
    }
}
