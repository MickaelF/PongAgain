using System.Collections;
using System.Collections.Generic;

public class CharacterData 
{
    private string m_name; 
    public string name { get { return m_name; } }
    private int m_length; 
    public int length { get { return m_length; } }
    private int m_rebound; 
    public int rebound { get { return m_rebound; } }
    private int m_speed; 
    public int speed { get { return m_speed; } }

    public CharacterData(string name, int length, int rebound, int speed)
    {
        m_name = name; 
        m_length = length; 
        m_rebound = rebound;
        m_speed = speed;
    }
}
