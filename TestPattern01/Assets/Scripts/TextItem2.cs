using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextItem2 : MonoBehaviour
{
    public delegate void DelegateFunc(TextItem2 item, bool bSelected);
    public DelegateFunc OnSelectFunc = null;

    public Text m_txtValue = null;

    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        GetComponent<Button>().onClick.AddListener(OnClicked_Selected);
    }

    public void OnAddListner(DelegateFunc func)
    {
        OnSelectFunc = new DelegateFunc(func);
    }

    public void OnClicked_Selected()
    {
        if (OnSelectFunc != null)
            OnSelectFunc(this, true);
    }
}
public class GayMgr
{
    public static GayMgr inst;
    public static GayMgr Instance
    {
        get
        {
            if (inst == null)
                inst = new GayMgr();
            return inst;
        }
    }
}