
using TMPro;
using UnityEngine;

public class CostManager : MonoBehaviour
{
    public static CostManager Instance;         // 임시 싱글톤으로 사용

    [Header("마나설정")]
    [SerializeField] private int maxMana = 10;
    [SerializeField] private int mana = 0;
    public int Mana => mana;

    [Header("UI 설정")]
    public TextMeshProUGUI manaText;

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

    void Start()
    {
        mana = maxMana;
        RefreshText();
    }
    
    public void UseMana(int amount)
    {
        mana -= amount;
        RefreshText();
    }

    public void RestoreMana(int amount)
    {
        mana = Mathf.Clamp(mana + amount, 0 , maxMana);
        RefreshText();
    }
    void RefreshText()
    {
        if (manaText != null)
            manaText.text = $"mana\n{mana}/{maxMana}";
    }
}
