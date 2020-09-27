using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressJoinButton : MonoBehaviour
{
    private List<Sprite> m_sprites;
    private Image m_image;
    private int m_index;
    // Start is called before the first frame update
    void Start()
    {
        m_index = 0;
        m_image = GetComponent<Image>();
        m_sprites = NavigationKeyInstructionHandler.instance.selectKeySprites;
        m_image.sprite = m_sprites[0];
    }

    private void OnAnimationEnded()
    {
        if (++m_index >= m_sprites.Count)
            m_index = 0;
        m_image.sprite = m_sprites[m_index];
    }
}
