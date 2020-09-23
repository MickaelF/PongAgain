using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimplePong.Localisation;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField] private RawImage m_characterRenderTexture = null; 
    [SerializeField] private MultiOptionsElement m_characterName = null;
    public MultiOptionsElement characterName { get { return m_characterName; } } 

    [SerializeField] private Image m_speedStats = null; 
    [SerializeField] private Image m_reboundStats = null; 
    [SerializeField] private Image m_lenghtStats = null; 
    [SerializeField] private LocaliseText m_playerNumberText = null;
    [SerializeField] private GameObject m_selectionPrefab = null;
    private int m_playerNumber;
    private CharacterPanel m_cameraPanel = null; 
    private RenderTexture m_targetTexture = null; 

    void Awake()
    {
        m_characterName.IndexChanged += UpdateCharacter;
        m_characterName.OptionClicked += SelectReadyButton; 
        m_characterName.options = CharactersGlobal.instance.GetCharacterNames();

        var cameraPanelGO = Instantiate(m_selectionPrefab) as GameObject;
        cameraPanelGO.transform.SetParent(this.transform);
        m_cameraPanel = cameraPanelGO.GetComponent<CharacterPanel>();
        m_targetTexture = new RenderTexture(300, 300, 0, RenderTextureFormat.Default);
        m_cameraPanel.GetComponent<Camera>().targetTexture = m_targetTexture;
        m_characterRenderTexture.texture = m_targetTexture;
        
        UpdateCharacter(0);
    }

    private void UpdateCharacter(int index)
    {
        var character = CharactersGlobal.instance.GetCharacter(index);
        m_speedStats.fillAmount = character.speed * 0.01f;
        m_reboundStats.fillAmount = character.rebound * 0.01f;
        m_lenghtStats.fillAmount = character.length * 0.01f;
        m_cameraPanel.SetSelectedCharacter(index);
    }

    public void SetPlayerNumber(int number)
    {
        m_playerNumber = number; 
        m_playerNumberText.key = (number == 0) ? TranslationKeys.PlayerOneLabel : TranslationKeys.PlayerTwoLabel;
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

    private void SelectReadyButton(int index)
    {
    }
}
