using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr
{
    static GameMgr _Inst= null;

    public static GameMgr Inst
    {
        get 
        {
            if(_Inst == null)
                _Inst = new GameMgr();
            return _Inst;
        }
    }

    public TestScore m_TestScore = new TestScore();
}

public class GameManager
{
    static GameManager _Inst = null;

    public static GameManager Inst()
    {
        if (_Inst == null)
            _Inst = new GameManager();
        return _Inst;
    }

    public TestScore m_TestScore = new TestScore(); 
}

public class GameMagr : MonoBehaviour
{
    static GameMagr _Inst = null;
    public static GameMagr Inst
    {
        get
        {
            if( _Inst == null)
            {
                GameObject go = new GameObject("Singleton GameMagr");
                _Inst = go.AddComponent<GameMagr>();
                DontDestroyOnLoad(go);
            }
            return _Inst;
        }
    }

    public TestScore m_TestScore = new TestScore();
}


public class TestScore
{
    public int m_Score = 0;
}
