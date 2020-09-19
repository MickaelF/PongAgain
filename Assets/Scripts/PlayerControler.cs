using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public float m_speed = 5.0f;
    private Vector3 m_moveVector;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(m_moveVector * m_speed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        var moveVector = context.ReadValue<Vector2>();
        m_moveVector.x = moveVector.x;
        m_moveVector.y = moveVector.y;
    }
}
