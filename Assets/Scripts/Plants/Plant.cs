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

    public float RechargeTime { get; private set; }
    public float Toughness { get; private set; }

    private void Awake()
    {
        RechargeTime = (float)RechargeType;
        Toughness = (float)ToughnessType;
    }
}
