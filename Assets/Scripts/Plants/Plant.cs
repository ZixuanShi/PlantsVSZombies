using UnityEngine;

/// <summary>
/// Required base class for all plants
/// </summary>
public class Plant : MonoBehaviour
{
    [field: SerializeField]
    public float Cost { get; private set; } = 50;

    [field: SerializeField]
    public ERechargeType RechargeType { get; private set; } = ERechargeType.kMedium;

    [field: SerializeField]
    public EToughness ToughnessType { get; private set; } = EToughness.kNormal;

    [field: SerializeField]
    public EDamage DamageType { get; private set; } = EDamage.kNormal;

    [field: SerializeField]
    public Sprite IconSprite { get; private set; } = null;

    public float RechargeTime { get; private set; }
    public float Toughness { get; private set; }
    public float Damage { get; private set; }

    private void Awake()
    {
        RechargeTime = (float)RechargeType;
        Toughness = (float)ToughnessType;
        Damage = (float)DamageType;
    }
}
