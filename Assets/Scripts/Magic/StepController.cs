using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepController : MonoBehaviour
{
    [SerializeField] Transform stepGeneratePoint;
    [SerializeField] StepController step;
    public Vector3 generatePosition = default; // ���[���h���W��錾
    private MagicScriptableData _data;
    private ClearSky.StepGenerateMagic stepmagic;

    private void Update()
    {
        
    }
    

    public void StepGanerate()
    {
        stepmagic.StepGeneratePreview();
        if (Input.GetMouseButton(0)) //�v���r���[���ɍ��N���b�N��������A���̍��W�ɑ���𐶐�����B
        {

            StepController controller = Instantiate(step, stepmagic.direction, Quaternion.identity); //�v���r���[���[�h�p��prefab���Ă�
            stepmagic.isPreview = false; // ��������������Ƃ��Ƀv���r���[���[�h����������B
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
