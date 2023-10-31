using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum State
{
    None,
    Ready,
    Game,
    Result
}

public class FsmTestDlg : MonoBehaviour
{
    public State m_CurState = State.None;
    [Space]
    public Button m_btnStart = null;
    public Button m_btnStop = null;
    public Button m_btnAttack = null;
    [Space]
    public Text m_txtHp = null;
    public Text m_txtTime = null;
    public Text m_txtState = null;
    [Space]
    public int m_MonsterHp = 100;
    const float m_PlayTime = 10.0f;
    public float m_CurTime = 0f;
    bool m_IsClear = true;
    bool m_IsPlay = true;
    Coroutine m_GameFunc = null;

    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        m_CurState = State.None;
        PrintState();

        m_btnStart.onClick.AddListener(OnClicked_BtnStart);
        m_btnStop.onClick.AddListener(OnClicked_BtnStop);
        m_btnAttack.onClick.AddListener(OnClicked_BtnAttack);
    }

    void OnClicked_BtnStart()
    {
        if (m_GameFunc == null)
            m_GameFunc = StartCoroutine(OnReadyState());
        else
            m_IsPlay = true;
    }

    void OnClicked_BtnStop()
    {
        if (m_CurState == State.Game)
            m_IsPlay = false;
    }

    void OnClicked_BtnAttack()
    {
        if (m_CurState == State.Game)
            m_MonsterHp -= 1;
        m_txtHp.text = $"{m_MonsterHp}";
    }

    IEnumerator OnReadyState()
    {
        m_CurState = State.Ready;
        PrintState();
        yield return new WaitForSeconds(1f);

        StartCoroutine(OnGameState());
    }

    IEnumerator OnGameState()
    {
        m_CurState = State.Game;
        PrintState();
        while (m_CurTime != m_PlayTime)
        {
            if(m_IsPlay)
                m_CurTime += Time.deltaTime;

            if (m_CurTime >= m_PlayTime)
                m_CurTime = m_PlayTime;

            m_txtTime.text = $"{string.Format("{0:0.0}", m_CurTime)}";

            if (m_MonsterHp <= 0)
            {
                m_IsClear = true;
                break;
            }

            yield return null;
        }
        if (m_MonsterHp > 0)
            m_IsClear = false;
        OnResultState();
    }

    void OnResultState()
    {
        m_CurState = State.Result;
        PrintState();
    }

    void PrintState()
    {
        switch (m_CurState)
        {
            case State.None:
                m_txtState.text = "None"; break;
            case State.Ready:
                m_txtState.text = "Ready"; break;
            case State.Game:
                m_txtState.text = "Game"; break;
            case State.Result:
                {
                    if (m_IsClear) m_txtState.text = "Result(Clear)";
                    else m_txtState.text = "Result(Fail)";
                    break;
                }

        }
    }
}
