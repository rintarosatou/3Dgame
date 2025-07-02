using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro �̖��O���

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Text �� TextMeshProUGUI �ɕύX
    public TextMeshProUGUI bestTimeText;     // �x�X�g�^�C���\���p
    private float time = 0f;// ���ۂɃJ�E���g���Ă��鎞�ԁi�b�j
    private bool isRunning = true;// �^�C�}�[�������Ă��邩�ǂ����ifalse�Œ�~�j
    private const string BEST_TIME_KEY = "BestTime"; // PlayerPrefs �ɕۑ�����L�[���i�Œ�j

    void Start()
    {
        // �ۑ����ꂽ�x�X�g�^�C����ǂݍ���ŕ\��
        if (PlayerPrefs.HasKey(BEST_TIME_KEY))
        {
            // �ۑ�����Ă����ꍇ�A�l���擾���ĕ\��
            float best = PlayerPrefs.GetFloat(BEST_TIME_KEY);
            if (bestTimeText != null)
                bestTimeText.text = "Best: " + best.ToString("F2") + "s";// �����_�ȉ�2���ŕ\��
        }
        else
        {
            // ����Ȃǂł܂��ۑ����Ȃ��ꍇ�� "--" �ƕ\��
            if (bestTimeText != null)
                bestTimeText.text = "Best: --";
        }
    }

    void Update()
    {
        if (isRunning)
        {
            // �o�ߎ��Ԃ����Z�iTime.deltaTime = �O�t���[������̌o�ߕb���j
            time += Time.deltaTime;

            // UI�Ɍ��݂̎��Ԃ�\���i�����_�ȉ�2���j
            if (timerText != null)
                timerText.text = time.ToString("F2"); // �����_�ȉ�2���\��
        }
    }

    // �S�[�����ɌĂяo���p
    public void stopTimer()
    {
        isRunning = false;// �^�C�}�[���~�߂�

        // �ȑO�̃x�X�g�^�C�����擾�i����͔��ɑ傫�����ŏ������j
        float best = PlayerPrefs.GetFloat(BEST_TIME_KEY, float.MaxValue); // ����͔��ɑ傫�����ŏ�����
        // ����̃^�C�����x�X�g��葬����΍X�V
        if (time < best)
        {
            PlayerPrefs.SetFloat(BEST_TIME_KEY, time);// �V�����x�X�g�^�C����ۑ�
            PlayerPrefs.Save();// ���ۂɕۑ������̂͂��̃^�C�~���O
            // UI�ɂ��V�����x�X�g�^�C����\��
            if (bestTimeText != null)
                bestTimeText.text = "Best: " + time.ToString("F2") + "s";
        }
    }
    // �x�X�g�^�C�������Z�b�g����֐��i�{�^������Ăяo���j
    public void ResetBestTime()
    {
        // �ۑ����ꂽ�x�X�g�^�C�����폜
        PlayerPrefs.DeleteKey(BEST_TIME_KEY);
        PlayerPrefs.Save();

        // �\�����X�V�i"--" �ɖ߂��j
        if (bestTimeText != null)
            bestTimeText.text = "Best: --";

        Debug.Log("�x�X�g�^�C�������Z�b�g���܂���");
    }
}
