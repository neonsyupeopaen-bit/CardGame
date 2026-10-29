using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("적 캐릭터 여부")]
    public bool isEnemy = false;

    [Header("스텟 설정")]
    [SerializeField] private int maxhp = 10;
    [SerializeField] private int currentHp = 0;

    [Header("ui 설정")]
    public TextMeshPro hpText;
    [Header("애니메이터")]
    public Animator animator;

    bool isDie = false;
    
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
    public void TakeDamage (int damage)
    {
        currentHp = Mathf.Clamp (currentHp - damage, 0, maxhp);

        if(currentHp <= 0)
        {
            Debug.Log("사망");
        }
        if (hpText != null)
            hpText.text = $"{currentHp} / {maxhp}";
       
        if(animator  != null)
        {
            animator.SetTrigger("hurt");
            animator.SetBool("isDie", isDie);
        }
    }
    public void Heal (int amount_)
    {
        currentHp = Mathf.Clamp(currentHp + amount_, 0, maxhp);

        if (hpText != null)
            hpText.text = $"{currentHp} / {maxhp}";
    }
   

}
