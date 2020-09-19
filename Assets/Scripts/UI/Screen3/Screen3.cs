using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using SimplePong.Localisation;

public class Screen3 : MonoBehaviour
{
    [SerializeField] private GameObject m_optionPrefab = null;
    [SerializeField] private VerticalLayoutGroup m_layoutGroup = null;
    [SerializeField] private LocaliseText m_parameterLabel = null; 
    [SerializeField] private Button m_validateButton = null; 

    private List<GameObject> m_uiElements = new List<GameObject>();
    public void Display(GameParameters.GameMode mode)
    {
        gameObject.SetActive(true);
        GameParameters.selectedMode = mode;        
        m_uiElements.Add(InstanciateElement(TranslationKeys.PlayerNumber, GameParameters.playerNumberOption));
        AddDifficulties();
        switch(mode)
        {
            case GameParameters.GameMode.Cooperation:
                m_parameterLabel.key = TranslationKeys.Cooperation;
                break;
            case GameParameters.GameMode.ScoreLimit:
                m_parameterLabel.key = TranslationKeys.ScoreLimit;
                m_uiElements.Add(InstanciateElement(TranslationKeys.ScoreLimitOption, GameParameters.scoreLimitOption));
                break;
            case GameParameters.GameMode.TimeLimit:
                m_parameterLabel.key = TranslationKeys.TimeLimit;
                m_uiElements.Add(InstanciateElement(TranslationKeys.TimeLimitOption, GameParameters.timeLimitOption));
                break;
        }
        UpdateNavigation();
        EventSystem.current.SetSelectedGameObject(m_uiElements[0]);
    }

    private GameObject InstanciateElement(TranslationKeys key, List<string> elements)
    {
        var go = Instantiate(m_optionPrefab, m_layoutGroup.transform, false) as GameObject;
        var optionElement = go.GetComponentInChildren<MultiOptionsElement>();
        optionElement.labelKey = key; 
        optionElement.options = elements;
        return go;
    }

    private void AddDifficulties() 
    {
        List<string> difficultyLabels = new List<string>();
        foreach (TranslationKeys key in GameParameters.difficultyKeys)
            difficultyLabels.Add(LocalLoader.GetValue(key));
        m_uiElements.Add(InstanciateElement(TranslationKeys.DifficultyLabel, difficultyLabels));        
    }

    private void UpdateNavigation()
    {
        for (int i = 0; i < m_uiElements.Count; ++i)
        {
            Navigation navigation = new Navigation();
            if (i != 0)
                navigation.selectOnUp = m_uiElements[i-1].GetComponentInChildren<Button>();
            if (i != m_uiElements.Count - 1)
                navigation.selectOnDown = m_uiElements[i + 1].GetComponentInChildren<Button>();
            
            m_uiElements[i].GetComponentInChildren<Button>().navigation = navigation; 
        }
        var lastElement = m_uiElements[m_uiElements.Count - 1].GetComponentInChildren<Button>();
        var lastElementNav = lastElement.navigation;
        lastElementNav.selectOnDown = m_validateButton;
        lastElement.navigation = lastElementNav; 

        var validateNavigation = new Navigation(); 
        validateNavigation.selectOnUp = lastElement; 
        m_validateButton.navigation = validateNavigation;

    }
}
