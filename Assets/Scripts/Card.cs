using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Drag 설정")]
    [SerializeField] private RectTransform dragArea;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Transform originalParent;
    private bool isDragging;

    [Header("Hover 설정")]
    [SerializeField] private float hoverScale = 1.1f;
    RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 마우스로 클릭
    public void OnPointerDown(PointerEventData eventData)
    {
        if (isDragging) return;
        if (dragArea == null) return;

        isDragging = true;

        originalPosition = rect.localPosition;
        originalRotation = rect.localRotation;
        originalParent = rect.parent;

        rect.SetParent(dragArea);
    }

    // 드래그 중
    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging == false) return;

        Vector2 mousePosition = eventData.position;

        rect.position = mousePosition;
    }

    // 클릭 종료
    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isDragging) return;
        isDragging = false;

        rect.SetParent(originalParent);
        rect.localPosition = originalPosition;
        rect.localRotation = originalRotation;
    }

    // 마우스가 UI 요소 위에 올라 왔을 때
    public void OnPointerEnter(PointerEventData eventData)
    {
        rect.localScale = Vector3.one * hoverScale;
    }

    // 마우스가 UI 요소 밖으로 나갈 때
    public void OnPointerExit(PointerEventData eventData)
    {
        rect.localScale = Vector3.one;
    }
}
