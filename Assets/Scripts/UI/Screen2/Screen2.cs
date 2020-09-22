using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Screen2 : Screen
{
    [SerializeField] private GameObject m_selectedGameObject = null;
    public override void Display()
    {
        gameObject.SetActive(true);       

        EventSystem.current.SetSelectedGameObject(m_selectedGameObject);
    }

    public void GameModeSelected(GameParameters.GameMode mode)
    {
        GameParameters.selectedMode = mode;
        GoToNextScreen();
    }
    
    protected override void HideCurrentScreen()
    {
        gameObject.SetActive(false);
        foreach (var ui in GetComponentsInChildren<GameMode>())
            ui.OnDeselect(null);
    } 
}
