using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using SimplePong.Localisation;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField] private RawImage m_characterRenderTexture = null; 
    [SerializeField] private MultiOptionsElement m_characterName = null;
    public MultiOptionsElement characterName { get { return m_characterName; } } 

    [SerializeField] private GameObject m_selectionScreen = null; 
    [SerializeField] private GameObject m_pressActionScreen = null; 

    [SerializeField] private Image m_speedStats = null; 
    [SerializeField] private Image m_reboundStats = null; 
    [SerializeField] private Image m_lenghtStats = null; 
    [SerializeField] private LocaliseText m_playerNumberText = null;
    [SerializeField] private GameObject m_selectionPrefab = null;
    [SerializeField] private ReadyButton m_readyButton = null; 
    private int m_playerNumber;
    private CharacterPanel m_cameraPanel = null; 
    private RenderTexture m_targetTexture = null; 

    private PlayerInput m_playerInput = null; 
    public PlayerInput playerInput 
    {
        get { return m_playerInput; } 
        set { SetPlayerInput(value); }
    } 

    private bool m_isReady = false; 
    public bool isReady { get {return m_isReady; } }


    void Awake()
    {
        m_characterName.m_useGlobalInput = false;
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

    private void SetPlayerInput(PlayerInput input)
    {
        if (m_playerInput != null)
        {
            var proxy = m_playerInput.GetComponent<PlayerInputProxy>();
            proxy.PlayerMoved -= OnMoveMade;
            proxy.PlayerAccept -= OnAcceptPressed;
            proxy.PlayerDecline -= OnDeclinePressed;
        }

        m_playerInput = input;
        if (m_playerInput != null)
        {
            var proxy = m_playerInput.GetComponent<PlayerInputProxy>();
            proxy.PlayerMoved += OnMoveMade;
            proxy.PlayerAccept += OnAcceptPressed;
            proxy.PlayerDecline += OnDeclinePressed;
            m_selectionScreen.SetActive(true);
            m_pressActionScreen.SetActive(false);
            m_characterName.OnSelect(null);
        }
        else 
        {
            m_selectionScreen.SetActive(false);
            m_pressActionScreen.SetActive(true);
        }
    }

    private void OnMoveMade(Vector2 move)
    {
        if (m_isReady)
            return;

        if (m_characterName.isSelected)
        {
            if (move.x != 0.0f)
                m_characterName.OnMoveDone(move);
            else if (move.y < 0.0f)
            {
                m_characterName.OnDeselect(null);
                m_readyButton.OnSelect(null);
            }
        }
        else 
        {
            if (move.y > 0.0f)
            {
                m_characterName.OnSelect(null);
                m_readyButton.OnDeselect(null);
            }
        }
    }

    private void OnAcceptPressed()
    {
        if (m_isReady)
            return;

        if (m_characterName.isSelected)
        {
            m_characterName.OnDeselect(null);
            m_readyButton.OnSelect(null);
        }
        else 
        {
            // Mark ready
        }
    }

    private void OnDeclinePressed()
    {
        if (m_characterName.isSelected)
        {
            var go = m_playerInput.gameObject;
            m_characterName.OnDeselect(null);
            playerInput = null; 
            Destroy(go);
        }
        else if (m_isReady)
        {
            m_isReady = false; 
            // Remove ready thingy
        }
        else
        {
            m_characterName.OnSelect(null);
            m_readyButton.OnDeselect(null);
        }
    }
}
