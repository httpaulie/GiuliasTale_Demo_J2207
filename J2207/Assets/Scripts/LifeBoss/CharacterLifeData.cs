using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Char_", menuName ="ScriptableObject/Character")]
public class CharacterLifeData : ScriptableObject
{
    [Tooltip("Max character life")]
    public int fullLife;
    [Tooltip("Recovery time between damage")]
    public float timeBetweenDamage;
    [Tooltip("Make character invulnerabe during a amount of time in the timeBetweenDamage attribute")]
    public bool invulnerableOnDamage = true;

}
