using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MagicType {
    None,
    SpeedUp,
    HiJunp,
}

[CreateAssetMenu(fileName = "MagicData", menuName = "MyScriptable/Create MagicData", order = 1)]
public class MagicScriptableData : ScriptableObject {
    // 魔法の種類
    public MagicType type;
    // 回数制限が有効か
    public bool isUsingLimit = false;
    // 回数制限
    public int usingValid;
    // _effectPowerを初期化する値
    public float effectInitialValue = 1.0f;
    // 効果時間
    public float effectTime;
    // 効果の強さ
    public float effectPower;
    // １度effectPowerを取得したら初期値に戻すか
    public bool isFastTake = false;
}
