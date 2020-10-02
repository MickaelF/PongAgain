using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 m_moveVector;
    private float m_speed = 100.0f;
    public System.Action PlayerOneGoal; 
    public System.Action PlayerTwoGoal;

    public
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(m_moveVector * m_speed * Time.deltaTime);
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
        Debug.Log("In Collision Enter");
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
            float angle = Vector3.Angle(other.GetContact(0).normal, m_moveVector);
            m_moveVector = Quaternion.AngleAxis(-angle, other.GetContact(0).normal) * m_moveVector;
        }
    }
}
