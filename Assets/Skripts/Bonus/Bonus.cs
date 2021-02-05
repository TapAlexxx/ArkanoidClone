using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {
    public enum BonusType {
        positiveSpeed,
        negativeSpeed,
        positiveSize,
        negativeSize,
        aditionalBalls
    }

    [SerializeField]
    private BonusType _bonusEnchantment;

    public BonusType BonusEnchantment => _bonusEnchantment;
}
