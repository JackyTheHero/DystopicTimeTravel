using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static bool sloved;

    public static TargetSlot currentSlot;

    public static bool SnippetDrop(Draggable snippet)
    {
        if (currentSlot)
            if (snippet.index == currentSlot.index)
            {
                snippet.transform.position = currentSlot.transform.position;
                return true;
            }
        return false;
    }
}
