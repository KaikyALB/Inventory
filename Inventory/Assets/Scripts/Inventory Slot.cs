
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Image itemImage;
    private Canvas canvas;
    private RectTransform rectTransform; //Controls position, size & Anchoring
    private CanvasGroup canvasGroup; // Sets Transparency, Interactivity & Blocking Raycast
    private Transform originalParent; //To set item back to where it belongs
    public Sprite iconSprite; // set via Inspector or load dynamically
    public Sprite restSprite;
    public Image restItemImage;
    private Vector2 originalPosition; //Stores the original position of the item

    public itemType itemType;
    void Start()
    {
       
    }

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        restItemImage = GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Clicked On Slot" + gameObject.name);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent; // changes the original parent
        transform.SetParent(canvas.transform); //Brings item to front
        originalPosition = rectTransform.anchoredPosition;
        canvasGroup.blocksRaycasts = false;
        originalPosition = rectTransform.anchoredPosition; // Save original position
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        GameObject target = eventData.pointerEnter;
        if (target != null)
        {
            InventoryType slot = target.GetComponentInParent<InventoryType>();

            if (slot != null)
            {
                Debug.Log($"ItemType: {itemType}, SlotType: {slot.slotType}");

                if (slot.slotType == itemType)
                {
                    if (originalParent != null)
                    {
                        InventoryType oldSlot = originalParent.GetComponentInParent<InventoryType>();
                        if (oldSlot != null)
                        {
                            oldSlot.removeItem(this);
                        }
                    }
                    transform.SetParent(slot.transform);
                    rectTransform.anchoredPosition = Vector2.zero;
                    restItemImage.sprite = restSprite;
                    return;
                }
            }
        }

        // Invalid drop – return to original
        transform.SetParent(originalParent);
        rectTransform.anchoredPosition = originalPosition;
    }
}


