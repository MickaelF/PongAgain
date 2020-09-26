using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimplePong.Localisation;

public class NavigationKey : MonoBehaviour
{
    private Dictionary<NavigationKeyInstructionHandler.Controller, Sprite> m_sprites;
    private List<NavigationKeyInstructionHandler.Controller> m_possibleControllerType;
    private int m_currentIndex = 0;
    private Animation m_animation;
    private LocaliseText m_keyAction;
    public TranslationKeys text
    {
        get { return m_keyAction.key; }
        set { m_keyAction.key = value; }
    }

    private NavigationKeyImage m_keyImage;

    void Awake()
    {
        m_animation = GetComponentInChildren<Animation>();
        m_keyAction = GetComponentInChildren<LocaliseText>();
        m_keyImage = GetComponentInChildren<NavigationKeyImage>();
        m_sprites = new Dictionary<NavigationKeyInstructionHandler.Controller, Sprite>();
        m_possibleControllerType = new List<NavigationKeyInstructionHandler.Controller>();
    }

    public void AddControllerSpriteDefinition(NavigationKeyInstructionHandler.Controller controller, Sprite sprite)
    {
        if (m_sprites.ContainsKey(controller))
            m_sprites[controller] = sprite;
        else
            m_sprites.Add(controller, sprite);
    }

    public void SetUniqueControllerType(NavigationKeyInstructionHandler.Controller type)
    {
        m_keyImage.sprite = m_sprites[type];

        if (m_animation.isPlaying)
        {
            m_animation.Stop();
            m_keyImage.ResetAlpha();
        }
    }

    public void SetControllerTypes(List<NavigationKeyInstructionHandler.Controller> types)
    {
        m_possibleControllerType.Clear();
        m_possibleControllerType = types;
        if (!m_animation.isPlaying)
            m_animation.Play();
    }

    public Sprite GetNextSprite()
    {
        if (++m_currentIndex >= m_possibleControllerType.Count)
            m_currentIndex = 0;
        return m_sprites[m_possibleControllerType[m_currentIndex]];
    }
}
