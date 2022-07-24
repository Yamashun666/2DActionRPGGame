using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ClearSky
{
    public class StepGenerateMagic : MagicBase
    {
        [SerializeField] StepController StepPreview;
        public SimplePlayerController simple;
        public bool isPreview = false; // プレビューモードが有効かどうか
        public Vector3 preview = default; // 足場を置くプレビュー時の座標を宣言
        public Vector3 direction;
        // Start is called before the first frame update
        public override void OnCall()
        {
            if (IsValid) // 魔法使用後なら早期リターンをして処理を行わない。
            {
                return;
            }
            if (simple.isStepGenerate)
            {
                StepGeneratePreview();
                base.OnCall();
            }

            
        }

        public void StepGeneratePreview()
        {
            isPreview = true; //プレビュー関数が呼ばれたらTrueを返す
            preview = Input.mousePosition; // マウス座標を取得
            direction = transform.position;
            direction = Camera.main.ScreenToWorldPoint(preview);
            StepController step = Instantiate(StepPreview, direction, Quaternion.identity); //プレビューモード用のprefabを呼ぶ

            step.transform.position = direction;
        }
    }

}
