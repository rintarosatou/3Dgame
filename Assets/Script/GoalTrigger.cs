using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public Timer TimerController; // �^�C�}�[����X�N���v�g�iTimer.cs�j�� Inspector �ŃA�^�b�`����

    // �S�[���̃g���K�[�ɑ��̃I�u�W�F�N�g���������Ƃ��ɌĂ΂��
    private void OnTriggerEnter(Collider other)
    {
        // �����Ă����I�u�W�F�N�g�̃^�O�� "player" �̂Ƃ�
        if (other.CompareTag("player"))
        {
            TimerController.stopTimer();//�^�C�}�[��~
        }
    }
}
