using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private Button m_button = null; 
    public Button button { get { return m_button; } }
    private Text m_text = null; 
    private Animation m_animation = null; 
    public System.Action ButtonPressed;

    public Navigation navigation 
    {
        get { return m_button.navigation; }
        set { m_button.navigation = value; }
    }

    void Awake() 
    {
        m_button = GetComponent<Button>();
        m_text = GetComponentInChildren<Text>();
        m_animation = GetComponent<Animation>();
        OnDeselect(null);
    }

    public void OnSelect(BaseEventData data)
    {
        m_button.image.sprite = Style.selectedBkgBtn;
        m_button.image.color = Style.white; 
        m_text.color = Style.purple;
        if (!m_animation.isPlaying)
            m_animation.Play();
    }
    
    public void OnDeselect(BaseEventData data)
    {
        m_button.image.sprite = Style.unselectedBkgBtn;
        m_button.image.color = Style.lightGrey; 
        m_text.color = Style.lightGrey;
        if (m_animation.isPlaying)
            m_animation.Stop();
    }

    public void OnClick()
    {
        if (ButtonPressed != null)
            ButtonPressed();
    }
}
