using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtils.delegates;


public class Health : MonoBehaviour
{
    public int MaxHp { get; private set; }

    public int Hitpoints;
    public bool DontDestroy = false;

    //Please use these, I worked hard on these :(
    public SimpleCallback onDeathCallback;
    public SimpleCallback onDamageCallback;
    
    //Don't use these they're too simple :)
    // Also full qualifying 
    public UnityEngine.Events.UnityEvent UE_onDeathCallback;
    public UnityEngine.Events.UnityEvent UE_onDamageCallback;

    private void Awake()
    {
        MaxHp = Hitpoints;
    }

    public void ModifyHealth(int _hp)
    {
        Hitpoints += _hp;
        if (Hitpoints <= 0)
        {
            onDeathCallback?.Invoke();
            if (!DontDestroy)
                Destroy(gameObject);
        }
        onDamageCallback?.Invoke();
    }
}
