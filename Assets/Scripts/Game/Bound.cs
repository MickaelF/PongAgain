using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : MonoBehaviour
{
    public enum Type { Left, Right, Top, Bottom, InnerLeft, InnerRight};
    [SerializeField] private Type m_type;
    public Type type { get { return m_type; } } 
    private BoxCollider m_collider; 

    private float m_relevantBound;
    public float relevantBound { get { return m_relevantBound; } }
    static private Dictionary<Type, Bound> m_bounds = new Dictionary<Type, Bound>();

    void Awake()
    {
        m_bounds.Add(m_type, this);
    }

    void Start()
    {
        m_collider = GetComponent<BoxCollider>();
        switch(m_type)
        {
            case Type.Bottom : m_relevantBound = m_collider.bounds.max.y; break;
            case Type.Top : m_relevantBound = m_collider.bounds.min.y; break;
            case Type.Left : m_relevantBound = m_collider.bounds.max.x; break;
            case Type.Right : m_relevantBound = m_collider.bounds.min.x; break;
            case Type.InnerLeft : m_relevantBound = m_collider.bounds.min.x; break;
            case Type.InnerRight : m_relevantBound = m_collider.bounds.max.x; break;
        }
    }

    static public void ConstraintMovement(Vector3 pos, Vector3 size, ref Vector3 move)
    {
        if (move.x != 0.0f)
        {
            if (move.x < 0.0f)
            {
                float position = pos.x - size.x * 0.5f;
                float bound = (position >= m_bounds[Type.InnerRight].m_relevantBound) ?
                    m_bounds[Type.InnerRight].m_relevantBound : 
                    m_bounds[Type.Left].m_relevantBound;
                float delta = bound - position;
                
                if (delta >= move.x)
                    move.x = delta;
            }
            else 
            {
                float position = pos.x + size.x * 0.5f;
                float bound = (position <= m_bounds[Type.InnerLeft].m_relevantBound) ?
                    m_bounds[Type.InnerLeft].m_relevantBound : 
                    m_bounds[Type.Right].m_relevantBound;
                float delta = bound - position;
                if (delta < move.x)
                    move.x = delta;
            }
        }
        if (move.y != 0.0f)
        {
            if (move.y > 0.0f)
            {
                float delta = m_bounds[Type.Top].m_relevantBound - (pos.y + size.y * 0.5f) ; 
                if (delta < move.y)
                    move.y = delta;
            }
            else 
            {
                float delta = m_bounds[Type.Bottom].m_relevantBound - (pos.y - size.y * 0.5f); 
                if (delta > move.y)
                    move.y = delta;
            }
        }
    }

    public bool IsVerticalLimit()
    {
        return m_type == Type.Bottom || m_type == Type.Top;
    }    

    public bool IsPlayerInnerBound()
    {
        return m_type == Type.InnerLeft || m_type == Type.InnerRight;
    }

}
