using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShotShell : MonoBehaviour
{
    public float shotSpeed;
    public GameObject ShellPrefab;
    public AudioClip shotSound;
    private float interval = 0.75f;
    private float timer = 0;
    public int shotCount;
    public TextMeshProUGUI shellLabel;
    // Start is called before the first frame update
    private void Start()
    {
        shellLabel.text = "" + shotCount;
    }

    // Update is called once per frame
    void Update()
    {
        // �^�C�}�[�̎��Ԃ𓮂���
        timer += Time.deltaTime;
        // ������Space�L�[���������Ȃ�΁i�����j
        // �uSpace�v�̕�����ύX���邱�Ƃő��̃L�[�ɂ��邱�Ƃ��ł���i�|�C���g�j
        if (Input.GetKeyDown(KeyCode.Space)&& timer > interval&& shotCount > 0)
        {
            shotCount -= 1;
            shellLabel.text ="" + shotCount;
            // �^�C�}�[�̎��Ԃ��O�ɖ߂�
            timer = 0.0f;
            // �C�e�̃v���n�u�����̉��i�C���X�^���X���j����
            GameObject shell = Instantiate(ShellPrefab,transform.position,Quaternion.identity);
            // �C�e�ɕt���Ă���Rigidbody�R���|�[�l���g�ɃA�N�Z�X����B
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();
            // forward�i����Z���j�̕����ɗ͂�������B
            shellRb.AddForce(transform.forward * shotSpeed);
            // ���˂����C�e���R�b��ɔj�󂷂�B
            // �i�d�v�ȍl�����j�s�v�ɂȂ����C�e�̓������[�ォ��폜���邱�ƁB
            Destroy(shell, 3.0f);
            // �C�e�̔��ˉ����o���B
           // AudioSource.PlayClipAtPoint(shotSound,transform.position);
        }
    }
}
