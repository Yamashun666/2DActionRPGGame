using UnityEngine;

// 魔法の共通部分を書くクラス
public class MagicBase : MonoBehaviour {
    // ScriptableObjectを使用したマジックデータ
    [SerializeField] private MagicScriptableData _data;
    [SerializeField] private PlayerStatus _status;

    // 効果の強さ
    private float _effectPower;
    // 有効か
    private bool _isValid = false;
    // 残りの使用回数
    private int _usingValid;
    // 最大スタック数
    private int _maxUsingValid;

    // 外部から_effectPowerを取得するゲッター
    public float effectPower {
        get{ 
            if (_data.isFastTake) { // 効果発動後１回限りで効果をかけたいか
                float tempEffectPower = _effectPower; // 効果を一度別の変数に逃がす
                _effectPower = _data.effectInitialValue; // 効果をリセットする
                _isValid = false;
                return tempEffectPower;
            } else { // 何もなければ普通に効果を返す
                return _effectPower; 
            } 
            
        }
    }
    public bool IsValid { get { return _isValid; } }
    public int UsingValid { get { return _usingValid; } set { _usingValid = value; } }
    public bool ValidReset { get { return _maxUsingValid > _usingValid; } }

    // 発動する
    public virtual void OnCall() {
        // 効果時間内ならば早期リターンをして効果発動処理を行わない
        
        if (_isValid) {
            return;
        }

        // 回数制限があるならば使用可能回数を減らす処理をする
        if (_data.isUsingLimit){
            // _usingValidが1以上だったら使用回数を減らす
            // _usingValidが0以下だったら早期リターンをして効果発動処理を行わない
            if (_usingValid > 0) {
                _usingValid--;
            } else {
                return;
            }
            
        }
        if (_data.isMPUse) // MP消費型の魔法の場合は、MPを消費して魔法を使う。
        {
            _status.currentMp -= _data.useMP;
            Debug.Log(_status.currentMp);
        }
        _effectPower = _data.effectPower;
        _isValid = true;
        if (!_data.isFastTake) {
            Invoke(nameof(Reset), _data.effectTime);
        }
    }
    
    //_usingValidの回数をリセットしたいときに呼ぶ
    public void UsingValidReset()
    {
        _usingValid = _maxUsingValid;
        Debug.Log(_usingValid);
    }

    // 終了時にリセットを行う
    private void Reset() {
        _isValid = false;
        _effectPower = _data.effectInitialValue;
    }

    // オブジェクトが有効になったときに呼ばれる
    private void OnEnable() {
        _effectPower = _data.effectInitialValue;
        _isValid = false;
        _usingValid = _data.usingValid;
        _maxUsingValid = _data.usingValid;
    }

    // オブジェクトが破棄、非有効になったときに呼ばれる
    private void OnDisable() {
        // 登録したInvokeをすべてキャンセル
        CancelInvoke();
    }
    
}
