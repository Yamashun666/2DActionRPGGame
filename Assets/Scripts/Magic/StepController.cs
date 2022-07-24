using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepController : MonoBehaviour
{
    [SerializeField] Transform stepGeneratePoint;
    [SerializeField] StepController step;
    public Vector3 generatePosition = default; // ワールド座標を宣言
    private MagicScriptableData _data;
    private ClearSky.StepGenerateMagic stepmagic;

    private void Update()
    {
        
    }
    

    public void StepGanerate()
    {
        stepmagic.StepGeneratePreview();
        if (Input.GetMouseButton(0)) //プレビュー中に左クリックをしたら、その座標に足場を生成する。
        {

            StepController controller = Instantiate(step, stepmagic.direction, Quaternion.identity); //プレビューモード用のprefabを呼ぶ
            stepmagic.isPreview = false; // 生成処理をするときにプレビューモードを解除する。
            generatePosition = this.transform.position;
            //Destroy(gameObject);

            Invoke(nameof(StepDelete), _data.effectTime);
        }
    }

    public void StepDelete()
    {
        Destroy(gameObject);
    }
}
