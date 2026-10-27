using TMPro;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("스텟 설정")]
    [SerializeField] private int maxhp = 10;
    [SerializeField] private int currentHp = 0;

    [Header("ui 설정")]
    public TextMeshPro hpText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxhp;
        if (hpText != null)
            hpText.text = $"{currentHp} / {maxhp}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
