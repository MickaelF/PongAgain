using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using SimplePong.Localisation;

public class LocalLoader
{
    public enum Locals { Default, French, English };
    private static Dictionary<TranslationKeys, string> translation = new Dictionary<TranslationKeys, string>();

    public static void LoadLocal(Locals local)
    {
        translation.Clear();
        translation.Add(TranslationKeys.Unknown, "This is not in the translation file.");
        TextAsset csvFile = Resources.Load<TextAsset>(GetFilePath(local));
        string[] lines = csvFile.text.Split('\n');
        for (int i = 1; i < lines.Length; ++i)
        {
            int indexOfSeperator = lines[i].IndexOf(',');
            if (indexOfSeperator < 0)
                continue;

            string key = lines[i].Substring(0, indexOfSeperator).Trim('"');
            string value = lines[i].Substring(indexOfSeperator + 1);
            value = value.Substring(1, value.LastIndexOf('"') - 1);
            translation.Add(Utils.toKey(key), value);
        }
    }

    private static string GetFilePath(Locals local)
    {
        switch (local)
        {
            case Locals.English:
                return "Localisation/english";
            case Locals.French:
                return "Localisation/french";
            default:
                return "Localisation/english";
        }
    }

    public static string GetValue(TranslationKeys key)
    {
        if (translation.Count == 0)
            LoadLocal(Locals.Default);
        return translation[key];
    }
}
