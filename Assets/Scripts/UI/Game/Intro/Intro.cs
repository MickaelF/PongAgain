using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimplePong.Localisation;

public class Intro : MonoBehaviour
{
    private LocaliseText m_localiseText;
    private Text m_text;
    private int m_countdown = 3;
    void Awake()
    {
        m_text = GetComponent<Text>();
        m_localiseText = GetComponent<LocaliseText>();
        
        switch(GameParameters.selectedMode)
        {
            case GameParameters.GameMode.Cooperation:
                m_localiseText.key = TranslationKeys.Cooperation;
                break;
            case GameParameters.GameMode.ScoreLimit:
                m_localiseText.key = TranslationKeys.ScoreLimit;
                break;
            case GameParameters.GameMode.TimeLimit:
                m_localiseText.key = TranslationKeys.TimeLimit;
                break;
        }
    }

    public void StartCountdown()
    {
        m_text.text = m_countdown.ToString();
    }

    
    public void UpdateCountdown()
    {
        if (--m_countdown == 0)
            m_text.text = "Go!";
        else
            m_text.text = m_countdown.ToString();
    }
}
