using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ComboTier", menuName = "ScriptableObjects/ComboTierSO")]
public class comboTier : ScriptableObject
{
    public Sprite letterGradeSprite;
    public string letterGradeText;
    public Color comboMeterColor;
    public float pointsRequiredToNext;
    public float pointMultiplier;
    public comboTier nextTier;
    public comboTier prevTier;
}
