using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class goal : MonoBehaviour
{
    public Timer TimerController; // �^�C�}�[����p�X�N���v�g�iTimer.cs�j��Inspector����ݒ�
    public GameObject chara; //Inspector�ŃL�����N�^�[�ƃS�[���I�u�W�F�N�g�̎w����ł���悤�ɂ���B
    public GameObject gameclea; // �Q�[���N���A���ɕ\������UI�iTextMeshPro�Ȃǁj
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        // ���������Ă����I�u�W�F�N�g�̃^�O��"Player"�Ȃ�
        if (other.CompareTag("Player"))
        {
            TimerController.stopTimer();//�^�C�}�[��~
        }
        // ���������Ă����I�u�W�F�N�g�̖��O��chara�Ɠ����Ȃ�
        if (other.name==chara.name)
        {
            //�Q�[���N���A�e�L�X�g��\�������ăL�����N�^�[���\���ɂ��܂��B
            gameclea.SetActive(true);
            chara.SetActive(false); // �L�����N�^�[�̕\�����I�t�i�����j
        }
    }
}
