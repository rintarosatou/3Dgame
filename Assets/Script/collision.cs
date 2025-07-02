using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class collision : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject retryButtonObj; // �� GameObject�Ƃ��ă{�^��������

    // Start is called before the first frame update
    void Start()
    {
        if (retryButtonObj != null) // retryButtonObj���������ݒ肳��Ă��邩�m�F
        {
            Button retryButton = retryButtonObj.GetComponent<Button>(); // �{�^���ɃN���b�N�C�x���g��o�^
            retryButton.onClick.RemoveAllListeners(); // ��d�o�^�h�~
            retryButton.onClick.AddListener(ReloadScene); // �{�^���N���b�N����ReloadScene���\�b�h���ĂԂ悤�ɐݒ�


            retryButtonObj.SetActive(false); // �Q�[���J�n���̓��g���C�{�^�����\���ɂ���
            // Debug.Log("Retry�{�^����\���ɂ��܂���");
        }
        //else
        //{
        //    Debug.LogError("retryButtonObj ���A�^�b�`����Ă��܂���I");
        //}
    }
    void OnCollisionEnter(Collision collision)// �I�u�W�F�N�g���Փ˂����Ƃ��ɌĂ΂�郁�\�b�h
    {
        Debug.Log("Collision");// �Փ˂������������Ƃ����O�ɏo��
        gameOverText.SetActive(true);// �Q�[���I�[�o�[�e�L�X�g��\��
        retryButtonObj.SetActive(true); // �{�^����\��
    }
    void ReloadScene()
    {
        Time.timeScale = 1f;// �ꎞ��~���Ă����ꍇ�Ɏ��Ԃ����ɖ߂�
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);// ���݂̃V�[�����ēǂݍ���
    }
}
