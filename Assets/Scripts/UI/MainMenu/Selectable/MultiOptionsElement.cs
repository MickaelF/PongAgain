using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using SimplePong.Localisation;

public class MultiOptionsElement : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private bool m_isSelected = false; 
    public bool isSelected { get { return m_isSelected; } }

    public bool m_useGlobalInput = true;

    [Header("Arrows")]
    [SerializeField] private Image m_leftArrow = null;
    [SerializeField] private Image m_rightArrow = null;
    
    [Header("Visual elements")]
    [SerializeField] private Image m_background = null;
    [SerializeField] private LocaliseText m_label = null;
    [SerializeField] private Text m_option = null;

    public delegate void Index(int i);
    public event Index IndexChanged; 

    public delegate void Clicked(int index);
    public event Clicked OptionClicked;

    private int m_objectIndex = 0; 
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

    public string selectedOptionText { get {return m_option.text; } }

    void Awake() 
    {
        OnDeselect(null);
    }

    void Start()
    {
        m_option.text = m_options[m_currentIndex];
    }

    public void OnSelect(BaseEventData data)
    {
        m_isSelected = true;
        m_background.sprite = Style.selectedBkgBtn;
        m_background.color = Style.white;
        if (m_label.isActiveAndEnabled)
            m_label.color = Style.white;
        m_option.color = Style.purple;
        m_leftArrow.color = Style.black;
        m_rightArrow.color = Style.black;
        if (m_useGlobalInput)
            GlobalInputs.Instance.inputSystem.move.action.performed += OnMoveDone;
    }

    public void OnDeselect(BaseEventData data)
    {
        m_isSelected = false;
        m_background.sprite = Style.unselectedBkgBtn;
        m_background.color = Style.unselectedColor;
        if (m_label.isActiveAndEnabled)
            m_label.color = Style.unselectedColor;
        m_option.color = Style.unselectedColor;
        m_leftArrow.color = Style.unselectedColor;
        m_rightArrow.color = Style.unselectedColor;
        if (m_useGlobalInput)
            GlobalInputs.Instance.inputSystem.move.action.performed -= OnMoveDone;
    }

    public void OnClicked()
    {
        if (OptionClicked != null)
            OptionClicked(m_objectIndex);
    }

    public void OnMoveDone(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();
        OnMoveDone(move);
    }

    public void OnMoveDone(Vector2 move)
    {
        if (move.x == 0)
            return; 
        if (move.x > 0 && m_currentIndex != m_options.Count - 1)
            SetCurrentIndex(m_currentIndex + 1);
        else if (move.x < 0 && m_currentIndex != 0)
            SetCurrentIndex(m_currentIndex - 1);
    }

    private void SetCurrentIndex(int index)
    {
        m_currentIndex = index; 
        m_option.text = m_options[index];
        if (IndexChanged != null)
            IndexChanged(m_currentIndex);
    }
}
