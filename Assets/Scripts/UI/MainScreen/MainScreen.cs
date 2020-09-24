using UnityEngine;
using UnityEngine.EventSystems;

public class MainScreen : Screen
{
    [SerializeField] private GameObject m_selectedGameObject = null;
    [SerializeField] private GameObject m_header = null;
    void Start()
    {
        m_currentScreen = this;
        StartListenToCancelAction();
        EventSystem.current.SetSelectedGameObject(m_selectedGameObject);
        m_header.SetActive(false);
    }

    public override void Display()
    {
        gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(m_selectedGameObject);
        m_header.SetActive(false);
    }

    public void OnLetsPlayPressed()
    {
        GoToNextScreen();
        m_header.SetActive(true);
    }
}
