using SimplePong.Localisation;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class GameParameters
{
    public enum GameMode { Cooperation, TimeLimit, ScoreLimit };

    static public GameMode selectedMode { get; set; }

    static private List<string> m_playerNumberOption = new List<string>() { "1", "2" };
    static public List<string> playerNumberOption { get { return m_playerNumberOption; } }
    static public int playerNumberSelected = 1;

    static private List<string> m_scoreLimitOption = new List<string>() { "3", "5", "7" };
    static public List<string> scoreLimitOption { get { return m_scoreLimitOption; } }
    static public int scoreLimitIndexSelected = 0;

    static private List<string> m_timeLimitOption = new List<string>() { "3", "5", "7" };
    static public List<string> timeLimitOption { get { return m_timeLimitOption; } }
    static public int timeLimitIndexSelected = 0;

    static private List<TranslationKeys> m_difficultyKeys = new List<TranslationKeys>() { TranslationKeys.DifficultyEasy, TranslationKeys.DifficultyMedium, TranslationKeys.DifficultyHard };
    static public List<TranslationKeys> difficultyKeys { get { return m_difficultyKeys; } }
    static public int difficultySelected = 0;


    static public void RemoveDevice(InputDevice device)
    {
        devices.Remove(device);
        if (DeviceListUpdate != null)
            DeviceListUpdate();
    }
    static public List<InputDevice> devices = new List<InputDevice>();
    static public System.Action DeviceListUpdate;
}