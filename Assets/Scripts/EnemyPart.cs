using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPart : MonoBehaviour
{
    [SerializeField] private Enemy mainScript;
    [SerializeField] private float damageMultiplier;
    public void DamageRecieved(float damage)
    {
        mainScript.Life -= (damage * damageMultiplier);
        if (mainScript.Life <= 0)
        {
            mainScript.Death();
        }
    }
}
