using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimplePong.Localisation;

[RequireComponent(typeof(Text))]
public class LocaliseText : MonoBehaviour
{
    private Text m_text;
    public string text
    {
        get { return m_text.text; }
        set { m_text.text = value; }
    }

    public Color color
    {
        get { return m_text.color; }
        set { m_text.color = value; }
    }
    [SerializeField] private TranslationKeys m_key = TranslationKeys.Unknown;
    public TranslationKeys key
    {
        get { return m_key; }
        set { SetKey(value); }
    }
    [SerializeField] private bool m_toUppercase = false;
    void Awake()
    {
        m_text = GetComponent<Text>();
        ChangeText();
    }

    private void SetKey(TranslationKeys key)
    {
        if (m_key == key)
            return;
        m_key = key;
        ChangeText();
    }

    private void ChangeText()
    {
        if (m_toUppercase)
            m_text.text = LocalLoader.GetValue(m_key).ToUpper();
        else
            m_text.text = LocalLoader.GetValue(m_key);
    }
}
