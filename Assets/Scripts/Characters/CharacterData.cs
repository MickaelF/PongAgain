using System.Collections;
using System.Collections.Generic;

public class CharacterData 
{
    private string m_name; 
    public string name { get { return m_name; } }
    private float m_length; 
    public float length { get { return m_length; } }
    private float m_rebound; 
    public float rebound { get { return m_rebound; } }
    private float m_speed; 
    public float speed { get { return m_speed; } }

    public CharacterData(string name, int length, int rebound, int speed)
    {
        m_name = name; 
        m_length = (length * 0.02f); 
        m_rebound = (rebound * 0.02f); 
        m_speed = (speed * 0.02f); 
    }
}
