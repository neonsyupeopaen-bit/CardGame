using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Card : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("카드 스킬 설정")]
    [SerializeField] CardType cardType;
    [SerializeField] int amount = 0;
    [SerializeField] int cost = 0;
    [Header("카드 사용 설정")]
    public LayerMask characterLayer;
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

        if (CostManager.Instance.Mana < cost)
        {
            rect.SetParent(originalParent);
            rect.localPosition = originalPosition;
            rect.localRotation = originalRotation;
            return;
        }

        bool used = false;

        Vector2 mouseposition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mouseposition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 100f, characterLayer);

        if(hit.collider != null)
        {
            Character target = hit.transform.GetComponent<Character>();

            if(target != null)
            {
                if (cardType == CardType.Attack && target.isEnemy)
                {
                    target.TakeDamage(amount);
                    used = true;
                }
                else if (cardType == CardType.Heal && target.isEnemy == false)
                {
                    target.Heal(amount);
                    used = true;
                }
                else if (cardType == CardType.Utility)
                {
                    Debug.Log("마나 회복 스킬 사용");
                    CostManager.Instance.RestoreMana(amount);
                    used = true;
                }
            }

        }
        if (used)
        {
            CostManager.Instance.UseMana(cost);
            Destroy(gameObject);
            return;
        }

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
