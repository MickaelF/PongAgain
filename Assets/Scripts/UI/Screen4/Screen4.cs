using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Screen4 : Screen
{
    [SerializeField] private GameObject m_prefab = null; 
    [SerializeField] private HorizontalLayoutGroup m_layout = null; 
    private List<PlayerSelection> m_playerSelection;

    void Awake()
    {
        m_playerSelection = new List<PlayerSelection>();
    }

    public override void Display()
    {
        gameObject.SetActive(true); 
        for (int i = 0; i < GameParameters.playerNumberSelected; ++i)
        {            
            var go = Instantiate(m_prefab, m_layout.transform, false) as GameObject;
            var playerSelection = go.GetComponent<PlayerSelection>();
            playerSelection.SetPlayerNumber(i);
            m_playerSelection.Add(playerSelection);
        }
        EventSystem.current.SetSelectedGameObject(m_playerSelection[0].characterName.gameObject);
    }

    
    protected override void HideCurrentScreen()
    {
        gameObject.SetActive(false);
        int childCount = m_layout.transform.childCount; 
        for (int i = 0; i < childCount; ++i)
            DestroyImmediate(m_layout.transform.GetChild(0).gameObject);
        m_playerSelection.Clear();
    } 

    public void PlayerStateChanged(int playerNum, bool ready)
    {

    }
}
