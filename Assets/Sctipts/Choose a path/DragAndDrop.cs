using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Image image;
    private Color colorOfImage;

    public bool isMagnetized = false;  // Флаг примагничивания
    public bool isBeingDragged = false; // Флаг, указывает, перемещается ли объект вручную

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        colorOfImage = image.color;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isMagnetized)
        {
            image.color = new Color(0f, 255f, 200f, 0.7f);
            image.raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        isBeingDragged = true;
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.color = colorOfImage;
        image.raycastTarget = true;
        // Перестаем двигать объект
        isBeingDragged = false;
    }
}
