﻿using UnityEngine;
using UnityEngine.EventSystems;

public class MainScreen : Screen
{
    [SerializeField] private GameObject m_header = null;
    [SerializeField] private QuitPopUp m_popUp = null;
    private CustomButton m_letsPlayButton = null;
    void Start()
    {
        m_currentScreen = this;
        StartListenToCancelAction();
        m_popUp.gameObject.SetActive(false);
        m_header.SetActive(false);
        m_letsPlayButton = GetComponentInChildren<CustomButton>();
        m_letsPlayButton.ButtonPressed += OnLetsPlayPressed;
        EventSystem.current.SetSelectedGameObject(m_letsPlayButton.gameObject);
    }

    public override void Display()
    {
        gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(m_letsPlayButton.gameObject);
        m_header.SetActive(false);
    }

    private void OnLetsPlayPressed()
    {
        GoToNextScreen();
        m_header.SetActive(true);
    }

    public override void OnCancelPressed()
    { 
        m_popUp.Display(this);   
    }
}
