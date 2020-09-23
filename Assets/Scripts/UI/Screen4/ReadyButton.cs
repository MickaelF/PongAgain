using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ReadyButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    
    [SerializeField] private Button m_button = null; 
    [SerializeField] private Text m_text = null; 
    private Animation m_animation = null; 

    void Awake() 
    {
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
}
