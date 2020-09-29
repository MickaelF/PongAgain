using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameMode : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [Header("Icon")]
    [SerializeField] private Sprite m_selectedIcon = null; 
 
    [SerializeField] private Sprite m_deselectedIcon = null; 

    
    [Header("Elements")]
    private Image m_background; 
    [SerializeField] private Image m_icon = null; 
 
    [SerializeField] private Text m_desc = null; 
 
    [SerializeField] private Image m_gameModeImg = null; 
    [SerializeField] private Text m_gameModeLabel = null;
    [SerializeField] private GameParameters.GameMode m_mode = GameParameters.GameMode.Cooperation; 

    void Awake() 
    {
        m_background = GetComponent<Image>();
        OnDeselect(null);
    }

    public void OnSelect(BaseEventData eventData) 
	{        
        m_background.color = Style.white;
        m_desc.color = Style.mediumGrey;
        m_icon.sprite = m_selectedIcon;
        m_icon.color = Style.white;
        m_gameModeImg.color = Style.purple;
        m_gameModeImg.sprite = Style.selectedBkgBtn;
        m_gameModeLabel.color = Style.white;
	}

    
    public void OnDeselect(BaseEventData eventData) 
	{
        m_background.color = Style.transparentGrey;
        m_desc.color = Style.transparentGrey;
        m_icon.sprite = m_deselectedIcon;
        m_icon.color = Style.transparentGrey;
        m_gameModeImg.color = Style.transparentGrey;
        m_gameModeImg.sprite = Style.unselectedBkgBtn;
        m_gameModeLabel.color = Style.transparentGrey;
	}
    
    public void OnModeClicked()
    {
        GetComponentInParent<Screen2>().GameModeSelected(m_mode);
    }
}
