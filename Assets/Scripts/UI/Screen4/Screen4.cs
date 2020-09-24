using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class Screen4 : Screen
{
    [SerializeField] private GameObject m_prefab = null; 
    [SerializeField] private GameObject m_playerPrefab = null; 
    [SerializeField] private HorizontalLayoutGroup m_layout = null; 
    private List<PlayerSelection> m_playerSelection;
    private PlayerInputManager m_inputManager; 
    private UserControl m_action; 

    void Awake()
    {
        m_playerSelection = new List<PlayerSelection>();
        m_inputManager = PlayerInputManager.instance;
        m_inputManager.playerPrefab = m_playerPrefab;
        m_action = new UserControl();
        m_action.UI.Enable();

    }

    public override void Display()
    {
        gameObject.SetActive(true);
        m_action.UI.Submit.started += m_inputManager.JoinPlayerFromActionIfNotAlreadyJoined;
        m_inputManager.EnableJoining(); 
        m_inputManager.onPlayerJoined += OnPlayerJoin; 
        m_inputManager.onPlayerLeft += OnPlayerLeft; 

        for (int i = 0; i < GameParameters.playerNumberSelected; ++i)
        {            
            var go = Instantiate(m_prefab, m_layout.transform, false) as GameObject;
            var playerSelection = go.GetComponent<PlayerSelection>();
            playerSelection.SetPlayerNumber(i);
            m_playerSelection.Add(playerSelection);
        }
    }
    
    protected override void HideCurrentScreen()
    {
        m_action.UI.Submit.started -= m_inputManager.JoinPlayerFromActionIfNotAlreadyJoined;
        m_inputManager.onPlayerJoined -= OnPlayerJoin; 
        m_inputManager.onPlayerLeft -= OnPlayerLeft; 
        m_inputManager.DisableJoining(); 
        gameObject.SetActive(false);
        int childCount = m_layout.transform.childCount; 
        for (int i = 0; i < childCount; ++i)
            DestroyImmediate(m_layout.transform.GetChild(0).gameObject);
        m_playerSelection.Clear();
    } 

    public void PlayerStateChanged(int playerNum, bool ready)
    {

    }

    public void OnPlayerJoin(PlayerInput input)
    {
        DontDestroyOnLoad(input);
        m_playerSelection[input.playerIndex].playerInput = input;  
        StopListenToCancelAction();   
        if (m_playerSelection[0].playerInput != null 
            && (m_playerSelection.Count == 1 || m_playerSelection[1].playerInput != null))   
        {
            m_action.UI.Submit.started -= m_inputManager.JoinPlayerFromActionIfNotAlreadyJoined;
        }
    }

    public void OnPlayerLeft(PlayerInput input)
    {
        if (m_playerSelection[0].playerInput == null 
            && (m_playerSelection.Count == 1 || m_playerSelection[1].playerInput == null))
        {            
            StartListenToCancelAction();
            m_action.UI.Submit.started += m_inputManager.JoinPlayerFromActionIfNotAlreadyJoined;
        }
        
    }
}
