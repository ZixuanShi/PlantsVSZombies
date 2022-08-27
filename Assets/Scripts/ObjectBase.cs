using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bare minimal class for plants and zombies
/// </summary>
public class ObjectBase : MonoBehaviour
{
    [field: SerializeField]
    public EToughness ToughnessType { get; private set; } = EToughness.kNormal;

    [field: SerializeField]
    public EDamage DamageType { get; private set; } = EDamage.kNormal;

    [field: SerializeField]
    public Sprite IconSprite { get; private set; } = null;

    public float Toughness { get; private set; }
    public float Damage { get; private set; }

    private void Awake()
    {
        Toughness = (float)ToughnessType;
        Damage = (float)DamageType;
    }
}
