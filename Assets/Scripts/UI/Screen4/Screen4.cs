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
    [SerializeField] private FadingPlane m_fadingPlane = null;
    [SerializeField] private NavigationKeyInstructionHandler m_headerKeys = null;
    private List<PlayerSelection> m_playerSelection;
    private PlayerInputManager m_inputManager;

    private bool m_everyoneIsReady = true;

    void Awake()
    {
        m_playerSelection = new List<PlayerSelection>();
        m_inputManager = PlayerInputManager.instance;
        m_inputManager.playerPrefab = m_playerPrefab;
    }

    public override void Display()
    {
        gameObject.SetActive(true);
        m_headerKeys.displayLastUsed = false;
        GlobalInputs.Instance.inputSystem.submit.action.started += m_inputManager.JoinPlayerFromActionIfNotAlreadyJoined;
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
        GlobalInputs.Instance.inputSystem.submit.action.started -= m_inputManager.JoinPlayerFromActionIfNotAlreadyJoined;
        m_headerKeys.displayLastUsed = true;
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
        if (m_everyoneIsReady && ready == false)
        {
            m_fadingPlane.StopFadeOutAnimation();
        }
        else
        {
            foreach (var player in m_playerSelection)
                if (!player.isReady)
                    return;
            m_fadingPlane.StartFadeOutAnimation();
            m_everyoneIsReady = true;
        }
    }

    public void OnPlayerJoin(PlayerInput input)
    {
        DontDestroyOnLoad(input);
        m_playerSelection[input.playerIndex].playerInput = input;
        StopListenToCancelAction();
        if (m_playerSelection[0].playerInput != null
            && (m_playerSelection.Count == 1 || m_playerSelection[1].playerInput != null))
        {
            GlobalInputs.Instance.inputSystem.submit.action.started -= m_inputManager.JoinPlayerFromActionIfNotAlreadyJoined;
        }
    }

    public void OnPlayerLeft(PlayerInput input)
    {
        if (m_playerSelection[0].playerInput == null
            && (m_playerSelection.Count == 1 || m_playerSelection[1].playerInput == null))
        {
            StartListenToCancelAction();
            GlobalInputs.Instance.inputSystem.submit.action.started += m_inputManager.JoinPlayerFromActionIfNotAlreadyJoined;
        }

    }
}
