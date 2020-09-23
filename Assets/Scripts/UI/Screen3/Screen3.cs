using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using SimplePong.Localisation;
using UnityEngine.InputSystem;


public class Screen3 : Screen
{
    [SerializeField] private GameObject m_optionPrefab = null;
    [SerializeField] private VerticalLayoutGroup m_layoutGroup = null;
    [SerializeField] private LocaliseText m_parameterLabel = null; 
    [SerializeField] private Button m_validateButton = null; 

    private List<MultiOptionsElement> m_uiElements = new List<MultiOptionsElement>();

    public override void Display()
    {
        gameObject.SetActive(true);   
        m_uiElements.Add(InstanciateElement(TranslationKeys.PlayerNumber, GameParameters.playerNumberOption, m_uiElements.Count));
        AddDifficulties();
        switch(GameParameters.selectedMode)
        {
            case GameParameters.GameMode.Cooperation:
                m_parameterLabel.key = TranslationKeys.Cooperation;
                break;
            case GameParameters.GameMode.ScoreLimit:
                m_parameterLabel.key = TranslationKeys.ScoreLimit;
                m_uiElements.Add(InstanciateElement(TranslationKeys.ScoreLimitOption, GameParameters.scoreLimitOption, m_uiElements.Count));
                break;
            case GameParameters.GameMode.TimeLimit:
                m_parameterLabel.key = TranslationKeys.TimeLimit;
                m_uiElements.Add(InstanciateElement(TranslationKeys.TimeLimitOption, GameParameters.timeLimitOption, m_uiElements.Count));
                break;
        }
        UpdateNavigation();
        EventSystem.current.SetSelectedGameObject(m_uiElements[0].gameObject);
    }

    private MultiOptionsElement InstanciateElement(TranslationKeys key, List<string> elements, int index)
    {
        var go = Instantiate(m_optionPrefab, m_layoutGroup.transform, false) as GameObject;
        var optionElement = go.GetComponentInChildren<MultiOptionsElement>();
        optionElement.objectIndex = index;
        optionElement.labelKey = key; 
        optionElement.options = elements;
        optionElement.OptionClicked += SelectNextOption;
        return optionElement;
    }

    private void AddDifficulties() 
    {
        List<string> difficultyLabels = new List<string>();
        foreach (TranslationKeys key in GameParameters.difficultyKeys)
            difficultyLabels.Add(LocalLoader.GetValue(key));
        m_uiElements.Add(InstanciateElement(TranslationKeys.DifficultyLabel, difficultyLabels, m_uiElements.Count));        
    }

    private void UpdateNavigation()
    {
        for (int i = 0; i < m_uiElements.Count; ++i)
        {
            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            if (i != 0)
                navigation.selectOnUp = m_uiElements[i-1].GetComponent<Button>();
            if (i != m_uiElements.Count - 1)
                navigation.selectOnDown = m_uiElements[i + 1].GetComponent<Button>();
            
            m_uiElements[i].GetComponent<Button>().navigation = navigation; 
        }
        var lastElement = m_uiElements[m_uiElements.Count - 1].GetComponent<Button>();
        var lastElementNav = lastElement.navigation;
        lastElementNav.selectOnDown = m_validateButton;
        lastElement.navigation = lastElementNav; 

        var validateNavigation = new Navigation(); 
        validateNavigation.mode = Navigation.Mode.Explicit;
        validateNavigation.selectOnUp = lastElement; 
        m_validateButton.navigation = validateNavigation;
    }

    public void SelectNextOption(int i)
    {
        if (i == m_uiElements.Count -1)
            EventSystem.current.SetSelectedGameObject(m_validateButton.gameObject);
        else 
            EventSystem.current.SetSelectedGameObject(m_uiElements[i + 1].gameObject);
    }

    public void OnValidate()
    {
        if (m_uiElements.Count == 0)
            return; 
        GameParameters.playerNumberSelected = m_uiElements[0].currentIndex + 1;
        GameParameters.difficultySelected = m_uiElements[1].currentIndex;
        if (GameParameters.selectedMode == GameParameters.GameMode.ScoreLimit)
            GameParameters.scoreLimitIndexSelected = m_uiElements[2].currentIndex;
        else if (GameParameters.selectedMode == GameParameters.GameMode.TimeLimit)
            GameParameters.timeLimitIndexSelected = m_uiElements[2].currentIndex;

        GoToNextScreen();
    }

    protected override void HideCurrentScreen()
    {
        gameObject.SetActive(false);
        int childCount = m_layoutGroup.transform.childCount; 
        for (int i = 0; i < childCount; ++i)
            DestroyImmediate(m_layoutGroup.transform.GetChild(0).gameObject);
        m_uiElements.Clear();
        m_validateButton.OnDeselect(null);
    } 
}
