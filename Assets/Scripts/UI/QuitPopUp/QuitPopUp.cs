using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuitPopUp : MonoBehaviour 
{
    [SerializeField] private CustomButton m_quitButton = null;
    [SerializeField] private CustomButton m_continueButton = null;
    private Screen m_callingScreen = null; 

    void Awake()
    {
        m_quitButton.ButtonPressed += Quit;
        m_continueButton.ButtonPressed += HidePopUp;
    }

    private void Quit()
    {
        Application.Quit();
    }

    private void HidePopUp()
    {
        gameObject.SetActive(false);
        m_continueButton.OnDeselect(null);
        if (m_callingScreen != null)
            m_callingScreen.Display();
    }

    public void Display(Screen callingScreen)
    {
        m_callingScreen = callingScreen;
        m_callingScreen.gameObject.SetActive(false);
        EventSystem.current.SetSelectedGameObject(m_quitButton.gameObject);
        m_quitButton.OnSelect(null);
        gameObject.SetActive(true);
    }
}
