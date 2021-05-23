using System;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static Action PuzzleSolved;
    public static bool puzzleSolved;

    private static bool[] solvedSlots = new bool[3];

    public static TargetSlot currentSlot;

    private void OnEnable()
    {
        var slots = GetComponentsInChildren<TargetSlot>();
        for (int i = 0; i < slots.Length; i++)
            slots[i].index = i;

        var snippets = GetComponentsInChildren<Snippet>();
        for (int i = 0; i < snippets.Length; i++)
            snippets[i].index = i;
    }

    public static bool SnippetDrop(Snippet snippet)
    {
        if (currentSlot)
            if (snippet.index == currentSlot.index)
            {
                solvedSlots[snippet.index] = true;
                if (puzzleSolved = CheckPuzzle())
                    PuzzleSolved?.Invoke();
                snippet.transform.position = currentSlot.transform.position;
                return true;
            }
        return false;
    }

    private static bool CheckPuzzle()
    {
        for (int i = 0; i < solvedSlots.Length; i++)
        {
            if (solvedSlots[i] == false)
                return false;
        }
        return true;
    }
}
