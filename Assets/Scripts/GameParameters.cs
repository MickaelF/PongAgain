using SimplePong.Localisation;
using System.Collections.Generic;

public class GameParameters
{
    public enum GameMode { Cooperation, TimeLimit, ScoreLimit };

    static public GameMode selectedMode { get; set; }

    static private List<string> m_playerNumberOption = new List<string>() { "1", "2" };
    static public List<string> playerNumberOption { get { return m_playerNumberOption; } }
    
    static private List<string> m_scoreLimitOption = new List<string>() { "3", "5", "7" };
    static public List<string> scoreLimitOption { get { return m_scoreLimitOption; } }
    
    static private List<string> m_timeLimitOption = new List<string>() { "3", "5", "7" };
    static public List<string> timeLimitOption { get { return m_timeLimitOption; } }

    static private List<TranslationKeys> m_difficultyKeys = new List<TranslationKeys>() {TranslationKeys.DifficultyEasy, TranslationKeys.DifficultyMedium, TranslationKeys.DifficultyHard}; 
    static public List<TranslationKeys> difficultyKeys { get { return m_difficultyKeys; } }

}