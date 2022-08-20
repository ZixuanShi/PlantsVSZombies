using UnityEngine;

[System.Serializable]

// How fast to recharge to summon a new one
public enum ERechargeType
{
    kNever = -1,
    kFast = 5,
    kMedium = 10,
    kSlow = 15,
}

// How many damage can be taken before dead
public enum EToughness
{
    kWeak = 5,
    kNormal = 10,
    kHard = 20,
}

// How far can I attack
public enum ERange
{
    kShort = 3,
    kLong = 20,
}

// Damage to deal per attack
public enum EDamage
{
    kNone = 0,
    kNormal = 5,
}