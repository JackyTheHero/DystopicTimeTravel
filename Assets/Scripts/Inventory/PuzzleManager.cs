using System;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static Action PuzzleSolved;
    public static bool puzzleSolved;
    public static bool[] solvedPuzzles = new bool[3];

    private static bool[] solvedSlots = new bool[3];

    public static TargetSlot currentSlot;

    public static bool getSolvedPuzzle()
    {
        return solvedPuzzles[2];
    }

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
                if (CheckPuzzle())
                {
                    if (solvedPuzzles[0] && solvedPuzzles[1])
                    {
                        solvedPuzzles[2] = true;
                    }
                    if (solvedPuzzles[0])
                    {
                        solvedPuzzles[1] = true;
                    }
                    if (!solvedPuzzles[0])
                    {
                        solvedPuzzles[0] = true;
                    }
                    solvedSlots[0] = false;
                    solvedSlots[1] = false;
                    solvedSlots[2] = false;


                    PuzzleSolved?.Invoke();
                }
                    
                
                snippet.transform.position = currentSlot.transform.position;
                return true;
            }
        return false;
    }

    private static bool CheckPuzzle()
    {
        
        return solvedSlots[0] && solvedSlots[1] && solvedSlots[2];
    }
}