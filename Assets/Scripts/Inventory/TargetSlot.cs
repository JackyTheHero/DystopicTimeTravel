using UnityEngine;
using UnityEngine.EventSystems;

public class TargetSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector] public int index = -1;

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.parent.parent.GetComponent<PuzzleManager>().currentSlot = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.parent.parent.GetComponent<PuzzleManager>().currentSlot = null;
    }
}
