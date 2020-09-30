using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float m_speed = 50.0f;
    private Vector3 m_moveVector = new Vector3();
    private PlayerInput m_playerInput; 
    private UserControl m_actions; 
    private CharacterData m_data;
    public CharacterData data { set { m_data = value; } }

    private bool m_launch = false; 
    public bool launch { set { m_launch = value; } }

    private Vector2 m_maxHorizontal = new Vector2(-10.0f, 10.0f);

    void Start()
    {
        m_actions = new UserControl();
        m_playerInput = GetComponent<PlayerInput>();
        m_data = CharactersGlobal.instance.characters[0];
    }

    void FixedUpdate()
    {
        var move = m_moveVector * m_speed * m_data.speed * Time.deltaTime;
        if (move.x > 0.0f)
        {
            if (transform.position.x + move.x > m_maxHorizontal[1])
                move.x = m_maxHorizontal[1] - transform.position.x;
        }
        else if (move.x < 0.0f)
        {
            if (transform.position.x + move.x < m_maxHorizontal[0])
                move.x = m_maxHorizontal[0] - transform.position.x  ;
        }
        transform.Translate(move);
    }

    public void OnMove(InputAction.CallbackContext context)
    { 
        var move2D = context.ReadValue<Vector2>();
        m_moveVector.x = move2D.x;
        m_moveVector.y = move2D.y;
    }
    public void OnLaunch(InputAction.CallbackContext context)
    { 
        Debug.Log("Launch");
    }

    public void OnPause(InputAction.CallbackContext context)
    { 
        Debug.Log("Pause");
    }

    public void OnPower(InputAction.CallbackContext context)
    { 
        Debug.Log("Power");
    }
}
