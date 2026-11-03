using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardEntry
{
    public Card cardPrefab;
    public float rate = 0f;
}
public class CardManager : MonoBehaviour
{

    [Header("핸드 설정")]
    [SerializeField] private int maxCardCount = 8;
    [SerializeField] private int drawCardCount = 5;
    [SerializeField] private float drawInterval = 0.25f;
    [Header("카드 프리팹 목록")]
    [SerializeField] private List<CardEntry> cardList = new();

    [Header("핸드 레이아웃")]
    public HandLayout handLayout;
    public static CardManager Instance;         // 임시 싱글톤으로 사용

    void Awake()
    {
        if (Instance == null)
            Instance = this;                    // 자신이 인스턴스가 된다.
    }

    void OnDestroy()
    {
        if (Instance == this)
            Instance = null;                    // 파괴된다면 인스턴스를 비워준다.
    }

    private void Start()
    {
        DrawCard(drawCardCount);
    }
    public void ArrangeCards()
    {
        if(handLayout != null)
            handLayout.ArrangeCards();
    }

    public void DrawCard()
    {
        if (cardList.Count == 0) return;
        if (handLayout == null) return;
        if (handLayout.transform.childCount >= maxCardCount)
        {
            Debug.LogWarning("카드를 더 이상 뽑을 수 없습니다.");
            return;
        }

        float rand = Random.value;

        float sumRate = 0;
        
        for (int i = 0;  i < cardList.Count; i++)
        {
            if (cardList[i] == null) continue;

            sumRate += cardList[i].rate;

            if(rand < sumRate)
            {
                if (cardList[i].cardPrefab == null)
                    break;
                Card card = Instantiate(cardList[i].cardPrefab, handLayout.transform);
                break;
            }
        }

        ArrangeCards();




        ArrangeCards();
    }


    public void DrawCard(int count)
    {
        StartCoroutine(DrawRoutine(count));
    }
    
    IEnumerator DrawRoutine(int count)
    {
        while(count>0)
        {
            DrawCard();
            count--;
            yield return new WaitForSeconds(drawInterval);
        }
    }
}