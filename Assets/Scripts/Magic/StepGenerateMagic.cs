using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ClearSky
{
    public class StepGenerateMagic : MagicBase
    {
        [SerializeField] StepController StepPreview;
        public SimplePlayerController simple;
        public bool isPreview = false; // �v���r���[���[�h���L�����ǂ���
        public Vector3 preview = default; // �����u���v���r���[���̍��W��錾
        public Vector3 direction;
        // Start is called before the first frame update
        public override void OnCall()
        {
            if (IsValid) // ���@�g�p��Ȃ瑁�����^�[�������ď������s��Ȃ��B
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
            isPreview = true; //�v���r���[�֐����Ă΂ꂽ��True��Ԃ�
            preview = Input.mousePosition; // �}�E�X���W���擾
            direction = transform.position;
            direction = Camera.main.ScreenToWorldPoint(preview);
            StepController step = Instantiate(StepPreview, direction, Quaternion.identity); //�v���r���[���[�h�p��prefab���Ă�

            step.transform.position = direction;
        }
    }

}
