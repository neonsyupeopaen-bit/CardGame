
using UnityEngine;

public class HandLayout : MonoBehaviour
{
    [Header("원호 배치")]
    [SerializeField] private float radius = 650f;
    [SerializeField] private float maxFanAngle = 28f;

    private void Start()
    {
        ArrangeCards();
    }

    public void ArrangeCards()
    {
        int count = transform.childCount;

        if (count == 0)
            return;

        for (int i = 0; i < count; i++)
        {
            RectTransform card =
                transform.GetChild(i) as RectTransform;

            if (card == null)
                continue;

            Card cardComponent = card.GetComponent<Card>();

            if (cardComponent == null) return;
            cardComponent.SetIndex(i);                      // 인덱스 전달


            // 카드마다 전체 각도를 균등하게 분배
            float t = count == 1
                 ? 0f
                 : (float)i / (count - 1) * 2f - 1f;

            // 카드 수가 적을수록 전체 펼침 각도를 줄임
            float angleRange = maxFanAngle *
                Mathf.Clamp01((count - 1) / 7f);

            float angle = t * angleRange;
            float radian = angle * Mathf.Deg2Rad;

            float x = radius * Mathf.Sin(radian);
            float y = radius * (Mathf.Cos(radian) - 1f);

            card.anchoredPosition = new Vector2(x, y);

            card.localRotation =
                Quaternion.Euler(0f, 0f, -angle);
        }
    }
}

