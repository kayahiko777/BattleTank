using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public Transform muzzleTran;
    public GameObject bulletPrefab;

    public AudioClip shotSound;
    public float shotSpeed;

    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // マウスの左クリックをしたら
        if (Input.GetMouseButtonDown(0))
        {
            {
                Shot();
            }
        }
    void Shot()
        {
            Vector3 spawnPosition = muzzleTran.position + muzzleTran.forward * 0.5f;
            // 銃の発射口の位置に弾を生成
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, muzzleTran.rotation);

            // 弾の先端の向きを、銃の発射口の向いている方向に合わせる
            bullet.transform.forward = muzzleTran.forward;
            // 弾の回転角度を調整する
            bullet.transform.eulerAngles = new Vector3(bullet.transform.eulerAngles.x + offset, bullet.transform.eulerAngles.y, bullet.transform.eulerAngles.z);

            //Debug.Log("弾の回転角度 : " +bullet.transform.eulerAngles);
            // 弾にアタッチされている Rigidbody の取得を行い、取得できたら
            if (bullet.TryGetComponent(out Rigidbody rb))
            {
                // 弾を発射
                rb.AddForce(muzzleTran.forward * shotSpeed);
                // SE 鳴らす
                //AudioSource.PlayClipAtPoint(shotSound, Camera.main.transform.position);
            }
            else
            {
                Debug.Log("Rigidbodyが取得できないため、弾を発射できません");
            }
        }
        
    }
}
