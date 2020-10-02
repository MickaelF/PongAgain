using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{
    private PlayerControl[] m_player = new PlayerControl[2];
    private Vector2 m_originPosition = new Vector2(-75.0f, 30.0f);
    [SerializeField] private Ball m_ball; 
    void Start()
    {
        for (int i = 0; i < GameParameters.playerNumberSelected; ++i)
        {
            var playerGO = GameParameters.playerInput[i].gameObject;
            foreach (var maps in GameParameters.playerInput[i].actions.actionMaps)
            {
                if (maps.name == "UI")
                    maps.Disable();
                else if (maps.name == "Game")
                    maps.Enable();
            }
            CharacterData data = CharactersGlobal.instance.GetCharacter(GameParameters.characterSelected[i]);
            var go = GameObject.Instantiate(Resources.Load<GameObject>("Prefab/Game/Characters/" + data.name));
            go.transform.SetParent(playerGO.transform);
            go.transform.position = m_originPosition;
            m_originPosition *= -1.0f;
            m_player[i] = playerGO.GetComponent<PlayerControl>();
            m_player[i].data = data;
            m_player[i].enabled = true;
            m_player[i].LaunchPressed += OnLaunchPressed; 
        }    
        m_player[0].launch = true;   
    }

    void Update()
    {
        
    }

    private void OnLaunchPressed(PlayerControl ctrl)
    {
        if (m_player[0] == ctrl)
            m_ball.StartOnRight(); 
        else 
            m_ball.StartOnLeft();
    }
}
