using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Style
{
    private static Style m_instance = null;
    public static Style instance
    {
        get
        {
            if (m_instance == null)
                m_instance = new Style();
            return m_instance;
        }
    }

    public static Sprite unselectedBkgBtn
    {
        get { return instance.m_unselectedBkgBtn; }
    }
    public static Sprite selectedBkgBtn
    {
        get { return instance.m_selectedBkgBtn; }
    }

    public readonly static float ppuBtnMultiplier = 0.53f;
    public readonly static SpriteDrawMode btnDrawMode = SpriteDrawMode.Sliced;

    public readonly static Color unselectedColor = new Color(0.7843f, 0.7843f, 0.7843f, 0.7843f);
    public readonly static Color selectedColor = new Color(0.7843f, 0.7843f, 0.7843f, 1.0f);
    public readonly static Color pressedColor = Color.white;

    public readonly static Color purple = new Color(0.4352941f, 0.003921569f, 0.5960785f, 1.0f);
    public readonly static Color transparentGrey = new Color(1.0f, 1.0f, 1.0f, 0.25f);
    public readonly static Color white = Color.white;
    public readonly static Color black = Color.black;
    public readonly static Color grey = new Color(0.745283f, 0.745283f, 0.745283f, 1.0f);

    public readonly static Color mediumGrey = new Color(0.4f, 0.4f, 0.4f, 1.0f);
    public readonly static Color lightGrey = new Color(0.8f, 0.8f, 0.8f, 0.8f);
    public readonly static Color clear = Color.clear;
    public readonly static Color blackMidAlpha = new Color(0.0f, 0.0f, 0.0f, 0.5f);

    private readonly Sprite m_unselectedBkgBtn = null;
    private readonly Sprite m_selectedBkgBtn = null;

    private Style()
    {
        m_unselectedBkgBtn = Resources.Load<Sprite>("Sprites/RoundBrightBorder");
        m_selectedBkgBtn = Resources.Load<Sprite>("Sprites/RoundRectangle");
    }

}
