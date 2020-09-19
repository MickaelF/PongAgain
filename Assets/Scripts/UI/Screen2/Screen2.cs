using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Screen2 : MonoBehaviour
{
    [SerializeField] private GameObject m_selectedGameObject = null;
    [SerializeField] private GameObject m_header = null;
    [SerializeField] private Screen3 m_nextScreen = null;
    public void Display()
    {
        gameObject.SetActive(true);       
        m_header.SetActive(true); 
        EventSystem.current.SetSelectedGameObject(m_selectedGameObject);
    }

    public void GameModeSelected(GameParameters.GameMode mode)
    {
        gameObject.SetActive(false);
        m_nextScreen.Display(mode);
    }
}
