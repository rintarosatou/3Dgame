using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gamemanager : MonoBehaviour
{
    public void StartButton()// �X�^�[�g�{�^���������ꂽ�Ƃ��ɌĂ΂�鏈��
    {
        SceneManager.LoadScene("GameScenes");// "GameScenes" �Ƃ������O�̃V�[����ǂݍ��ށi�Q�[���J�n�j
    }
    public void RetryButton()// ���g���C�{�^���������ꂽ�Ƃ��ɌĂ΂�鏈��
    {
        SceneManager.LoadScene("GameScenes");// ������ "GameScenes" �V�[�����ēǂݍ��݁i���g���C�����j
    }
    public void TitleButton()// �^�C�g���ɖ߂�{�^���������ꂽ�Ƃ��ɌĂ΂�鏈��
    {
        SceneManager.LoadScene("Title");// ������ "GameScenes" �V�[�����ēǂݍ��݁i�^�C�g���ɖ߂鏈���j
    }
}
