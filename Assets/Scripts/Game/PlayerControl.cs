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

    // Start is called before the first frame update
    void Start()
    {
        m_actions = new UserControl();
        m_playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(m_moveVector * m_speed * m_data.speed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext context)
    { 
        var move2D = context.ReadValue<Vector2>();
        m_moveVector.x = move2D.x;
        m_moveVector.y = move2D.y;
        
        Debug.Log("MOve : " + m_moveVector);
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
