using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarX : MonoBehaviour
{
    private GameObject target;
    private float dis;
    // Start is called before the first frame update
    void Start()
    {
        // Find�i�j�E�E�E���Q�[����ʏ�Łu���O�v�ŃI�u�W�F�N�g���擾����B
        target = GameObject.Find("Tank");
    }

    // Update is called once per frame
    void Update()
    {
        // target�ƂȂ�I�u�W�F�N�g�����݂��鎞�������s�i�����j
        if (target)
        {
            // �Q�_��(����́u�����v�Ɓu�^�[�Q�b�g�v�̈ʒu�j�̋������擾����i�|�C���g�j
            dis = Vector3.Distance(transform.position, target.transform.position);

        if(dis < 5)
            {
                // LookAt�i�j�E�E�E���w�肵�������ɃI�u�W�F�N�g�̌�������]�����邱�Ƃ��ł���B
                transform.LookAt(target.transform);
            }
        }
    }
}
