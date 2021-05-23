using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Snippet : MonoBehaviour, IDraggable
{
    [HideInInspector] public int index = -1;
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
        //Debug.Log($"my parent's parent is: {this.transform.parent.parent.GetComponent<PuzzleManager>()}");
        solved = this.transform.parent.parent.GetComponent<PuzzleManager>().SnippetDrop(this);
        if (!solved)
            image.raycastTarget = true;
    }
}

public interface IDraggable : IBeginDragHandler, IDragHandler, IEndDragHandler { }
