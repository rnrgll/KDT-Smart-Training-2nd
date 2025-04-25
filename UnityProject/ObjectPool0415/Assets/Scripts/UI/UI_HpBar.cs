using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
public class UI_HpBar : MonoBehaviour
{
    [SerializeField] private Slider Hp_Bar;
    private float offset_y = 0.4f;

    [SerializeField] private MonsterV2 monsterV2;

    private float max;
    private float min;

    [SerializeField] private float activeTime = 2f;

    private Coroutine hideUICoroutine;
    private WaitForSeconds delay;
    
    private void Awake()
    {
        hideUICoroutine = null;
        delay = new WaitForSeconds(activeTime);
        Hp_Bar = GetComponentInChildren<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
        gameObject.SetActive(false);
    }

    public void Init()
    {
        monsterV2 = transform.GetComponentInParent<MonsterV2>();
        max = monsterV2.Stat.MaxHp;
        min = 0f;
        Hp_Bar.maxValue = max;
        Hp_Bar.minValue = min;

        monsterV2.Stat.OnHpChanged += SetHpRatio;
        monsterV2.Stat.OnHpChanged += ShowHP;
        
    }
    
    public virtual void SetHpRatio(int value)
    {
        
        Hp_Bar.value = value;
    }

    public virtual void ShowHP(int hp)
    {
        gameObject.SetActive(true);
        if (hideUICoroutine != null)
        {
            StopCoroutine(hideUICoroutine);
            
        }
        hideUICoroutine = StartCoroutine(HideHp());

    }


    public IEnumerator HideHp()
    {
        yield return delay;
        gameObject.SetActive(false);
        hideUICoroutine = null;
    }

    private void OnDestroy()
    {
        if (monsterV2 != null)
            monsterV2.Stat.OnHpChanged -= ShowHP;
    }
}
