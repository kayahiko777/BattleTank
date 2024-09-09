using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public AudioClip sound;

    public void OnStartButtonClicked()
    {
        StartCoroutine(GoToMain());
    }

    // ���R���[�`���i�u���s�E�E�E���ҋ@�E�E�E�����s�v�̎d�g�݂�����j
    private IEnumerator GoToMain()
    {
        // ���𔭐�������i���s�P�j
        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);

        // 1.5�b�҂i�ҋ@�j
        yield return new WaitForSeconds(1.5f);

        // Main�V�[���ɑJ�ڂ���i���s�Q�j
        SceneManager.LoadScene("Main");
    }    
}
