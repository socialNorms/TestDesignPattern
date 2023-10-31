using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelegateTest2Dlg : MonoBehaviour
{
    public Button m_btnResult = null;
    public Button m_btnClear = null;
    public TextItem2[] m_txtItems = null;
    public Text m_txtResult = null;
    public TextItem2 m_SelectItem = null;

    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        for (int i = 0; i < m_txtItems.Length; i++)
            m_txtItems[i].OnAddListner(OnClicked_BtnTextItem);
        m_btnResult.onClick.AddListener(OnClicked_BtnResult);
        m_btnClear.onClick.AddListener(OnClicked_BtnClear);
    }

    void OnClicked_BtnResult()
    {
        if (m_SelectItem != null)
            m_txtResult.text = $"¼±µµ = {m_SelectItem.m_txtValue.text}";
    }

    void OnClicked_BtnClear()
    {
        ClearItem();
        m_txtResult.text = string.Empty;
    }

    void OnClicked_BtnTextItem(TextItem2 textItem, bool value)
    {
        ClearItem();

        m_SelectItem = textItem;
        textItem.GetComponent<Image>().color = Color.yellow;

        m_txtResult.text = $"{textItem.m_txtValue.text}";
    }

    void ClearItem()
    {
        foreach (TextItem2 item in m_txtItems)
            item.GetComponent<Image>().color = Color.white;

        m_SelectItem = null;
    }
}
