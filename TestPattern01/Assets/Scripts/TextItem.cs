using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextItem : MonoBehaviour
{
    public Text m_txtName = null;
    public Image m_Iamge = null;

    public delegate void DelegateFunc(TextItem kItem, bool bSelect);
    public DelegateFunc OnSelectedFunc = null;

    private void Start()
    {
        Initiailze();
    }

    void Initiailze()
    {
        GetComponent<Button>().onClick.AddListener(OnClicked_Selected);
    }

    public void OnAddListner(DelegateFunc func)
    {
        OnSelectedFunc = new DelegateFunc(func);
    }

    public void OnClicked_Selected()
    {
        if (OnSelectedFunc != null)
            OnSelectedFunc(this, true);
    }
}
