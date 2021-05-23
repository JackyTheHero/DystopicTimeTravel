using UnityEngine;
using UnityEngine.EventSystems;

public class TargetSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector] public int index = -1;

    public void OnPointerEnter(PointerEventData eventData)
    {
        PuzzleManager.currentSlot = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PuzzleManager.currentSlot = null;
    }
}
