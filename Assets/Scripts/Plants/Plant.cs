using UnityEngine;

/// <summary>
/// Required base class for all plants
/// </summary>
public class Plant : ObjectBase
{
    [Tooltip("The cost of sunlight to plant this plant")]
    [field: SerializeField]
    public int Cost { get; private set; } = 50;

    [field: SerializeField]
    public ERechargeType RechargeType { get; private set; } = ERechargeType.kMedium;

    public float RechargeTime { get; private set; }

    private void Awake()
    {
        RechargeTime = (float)RechargeType;
    }
}
