namespace SimplePong.Localisation
{
    public enum TranslationKeys
    {
        LetsPlay,
        Back,
        Cooperation,
        CooperationDesc,
        TimeLimit,
        TimeLimitDesc,
        TimeLimitOption,
        ScoreLimit,
        ScoreLimitDesc,
        ScoreLimitOption,
        PlayerOneLabel,
        PlayerTwoLabel,
        DifficultyLabel,
        DifficultyEasy,
        DifficultyMedium,
        DifficultyHard,
        StartGameButton,
        PressButtonLabel,
        SpeedParametersCharacter,
        ReboundParametersCharacter,
        Select,
        Confirm,
        DefaultValue,
        PlayerNumber,
        ParameterLabel,
        ReadyLabel,
        SettingsLabel,
        QuitPopUpLabel,
        QuitPopUpDesc,
        Quit,
        Continue,
        LengthParametersCharacter,
        Unknown
    };

    public class Utils
    {
        public static TranslationKeys toKey(string s)
        {
            foreach (TranslationKeys key in System.Enum.GetValues(typeof(TranslationKeys)))
                if (key.ToString() == s)
                    return key;
            return TranslationKeys.Unknown;
        }

        public static string toString(TranslationKeys key)
        {
            return key.ToString();
        }
    }

}