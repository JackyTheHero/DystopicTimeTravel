using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Draggable : MonoBehaviour, IDraggable
{
    public int index = -1;
    private Image image;
    private bool solved = false;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        solved = PuzzleManager.SnippetDrop(this);
        if (!solved)
            image.raycastTarget = true;
    }
}

public interface IDraggable : IBeginDragHandler, IDragHandler, IEndDragHandler { }
