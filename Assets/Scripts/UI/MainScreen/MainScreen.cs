using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainScreen : MonoBehaviour
{
    [SerializeField] private GameObject m_selectedGameObject = null;
    [SerializeField] private Screen2 m_nextScreen = null;
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(m_selectedGameObject);
    }

    public void OnLetsPlayPressed()
    {
        gameObject.SetActive(false);
        m_nextScreen.Display();
    }
}
