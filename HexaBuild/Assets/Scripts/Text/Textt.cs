public static class Textt
{
    public static void GameLocal(string text)
    {
        GameDialogScript.instance.AddText(text);
    }

    public static void Reset() => GameDialogScript.instance.Reset();
}