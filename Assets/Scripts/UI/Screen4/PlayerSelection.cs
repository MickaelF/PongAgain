using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimplePong.Localisation;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField] private RawImage m_characterRenderTexture = null; 
    [SerializeField] private MultiOptionsElement m_characterName = null; 
    [SerializeField] private Image m_speedStats = null; 
    [SerializeField] private Image m_reboundStats = null; 
    [SerializeField] private Image m_lenghtStats = null; 
    [SerializeField] private LocaliseText m_playerNumberText = null;
    private int m_playerNumber;

    void Awake()
    {
        m_characterName.IndexChanged += UpdateCharacter;
    }

    private void UpdateCharacter(int index)
    {

    }

    public void SetPlayerNumber(int number)
    {
        m_playerNumber = number; 
        m_playerNumberText.key = (number == 1) ? TranslationKeys.PlayerOneLabel : TranslationKeys.PlayerTwoLabel;
    }
     
    public void OnPlayerReady()
    {
        GetComponentInParent<Screen4>().PlayerStateChanged(m_playerNumber, true);
        // TODO Change style
    }

    public void OnPlayerCancel()
    {
        GetComponentInParent<Screen4>().PlayerStateChanged(m_playerNumber, false);
        // TODO Change style
    }
}
