using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private CharacterLifeData characterLifeData;
    public event Action<int> OnlifeChanged;
    public event Action OnDie;
    private int life;
    public int Life
    {
        get { return life; }
        set
        {
            if(life < 0) return;
            life = value;
            Debug.Log("Life " + life);
            OnlifeChanged?.Invoke(life);
            if(life == 0)
            {
                OnDie?.Invoke();
            }
        }
    }
    
    private DateTime lastTimeDamage;

    public bool IsFullLife()
    {
        return life == characterLifeData.fullLife;
    }

    public float GetLifeNormalized()
    {
        return (float)life / characterLifeData.fullLife;
    }

    void Start()
    {
        Life = characterLifeData.fullLife;
    }
    
    public bool TakeDamage( int Power)
    {
        if(!CanTakeDamage()) return false;
        this.Life -= Power;
        lastTimeDamage = DateTime.UtcNow;
        return true;
    }

    private bool CanTakeDamage()
    {
        if(!characterLifeData.invulnerableOnDamage) return true;
        if (characterLifeData.timeBetweenDamage > 0)
        {
            TimeSpan timeSpan = DateTime.UtcNow - lastTimeDamage;
            return timeSpan.TotalSeconds > characterLifeData.timeBetweenDamage;
        }
        return true;
    }

    void Update()
    {
        
    }
}
