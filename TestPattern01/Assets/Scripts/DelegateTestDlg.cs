using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelegateTestDlg : MonoBehaviour
{
    public Button m_btnResult = null;
    public Button m_btnClear = null;
    public Text m_txtResult = null;
    public TextItem[] m_TextItems = null;
    string dosi = string.Empty;

    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        for (int i = 0; i < m_TextItems.Length; i++)
        {
            m_TextItems[i].OnAddListner(OnClicked_BtnTextItem);
        }

        m_btnResult.onClick.AddListener(OnClicked_BtnResult);
        m_btnClear.onClick.AddListener(OnClicked_BtnClear);
    }

    void OnClicked_BtnResult()
    {
        if (dosi == string.Empty) return;
        m_txtResult.text = $"´Ô¼±µµ = {dosi}";
    }
    void OnClicked_BtnClear()
    {
        foreach (TextItem _item in m_TextItems)
            _item.GetComponent<Image>().color = Color.white;
        dosi = string.Empty;
        m_txtResult.text = string.Empty;
    }
    void OnClicked_BtnTextItem(TextItem item, bool value)
    {
        foreach (TextItem _item in m_TextItems)
            _item.GetComponent<Image>().color = Color.white;

        item.GetComponent<Image>().color = Color.yellow;
        m_txtResult.text = item.m_txtName.text;

        dosi = item.m_txtName.text;
    }
}
