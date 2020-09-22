using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using SimplePong.Localisation;

public class MultiOptionsElement : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private bool m_isSelected = false; 

    [Header("Arrows")]
    [SerializeField] private Image m_leftArrow = null;
    [SerializeField] private Image m_rightArrow = null;
    
    [Header("Visual elements")]
    [SerializeField] private Image m_background = null;
    [SerializeField] private LocaliseText m_label = null;
    [SerializeField] private Text m_option = null;

    private static UseControl m_actions = null;

    private int m_objectIndex; 
    public int objectIndex 
    {
        set { m_objectIndex = value; }
    }

    public TranslationKeys labelKey
    {
        set { m_label.key = value; }
    }

    private List<string> m_options; 
    public List<string> options 
    { 
        get { return m_options; } 
        set { m_options = value; } 
    }

    private int m_currentIndex = 0; 
    public int currentIndex { get { return m_currentIndex; } }

    void Start()
    {
        if (m_actions == null)
            m_actions = new UseControl();
        m_option.text = m_options[m_currentIndex];
    }

    public void OnSelect(BaseEventData data)
    {
        m_isSelected = true;
        m_background.sprite = Style.selectedBkgBtn;
        m_background.color = Style.white;
        m_label.color = Style.white;
        m_option.color = Style.purple;
        m_leftArrow.color = Style.black;
        m_rightArrow.color = Style.black;
    }

    public void OnDeselect(BaseEventData data)
    {
        m_isSelected = false;
        m_background.sprite = Style.unselectedBkgBtn;
        m_background.color = Style.unselectedColor;
        m_label.color = Style.unselectedColor;
        m_option.color = Style.unselectedColor;
        m_leftArrow.color = Style.unselectedColor;
        m_rightArrow.color = Style.unselectedColor;
    }

    public void OnClicked()
    {
        GetComponentInParent<Screen3>().SelectNextOption(m_objectIndex);
    }
}
