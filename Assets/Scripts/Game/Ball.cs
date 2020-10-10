using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 m_moveVector;
    private float m_speed = 50.0f;
    public System.Action PlayerOneGoal; 
    public System.Action PlayerTwoGoal;

    private Rigidbody m_rigidbody;
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_rigidbody.velocity = m_moveVector * m_speed;
    }

    public void StartOnLeft()
    {
        m_moveVector = new Vector3(-0.5f, -0.5f, 0.0f); 
    }

    public void StartOnRight()
    {
        m_moveVector = new Vector3(0.5f, 0.5f, 0.0f);
    }

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("In Collision Enter : " + other.gameObject);
        var boundClass = other.gameObject.GetComponent<Bound>();
        if (boundClass)
        {
            if (boundClass.IsPlayerInnerBound())
                return;
            if (boundClass.IsVerticalLimit())
                m_moveVector.y = -m_moveVector.y;
            else if (boundClass.type == Bound.Type.Left)
                PlayerTwoGoal();
            else if (boundClass.type == Bound.Type.Right)
                PlayerOneGoal();
        }
        else 
        {
            float angle = Vector3.SignedAngle(-m_moveVector, other.GetContact(0).normal, Vector3.forward);
            m_moveVector = Quaternion.AngleAxis(angle, Vector3.forward) * other.GetContact(0).normal;
            m_moveVector.Normalize();
        }
    }
}
