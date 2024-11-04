using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static WeaponData;

public class DataBaseManager : MonoBehaviour
{
    public static DataBaseManager instance;

    public WeaponDataSO weaponDataSO;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// WeaponDataSO �X�N���v�^�u���E�I�u�W�F�N�g�̒�����A�����Ɏw�肳�ꂽ WeaponNo ������ WeaponData �̎擾
    /// </summary>
    /// <param name="searchWeaponNo"></param>
    /// <returns></returns>
    public WeaponData GetWeaponData(int searchWeaponNo)
    {
        return weaponDataSO.weaponDatasList.Find(x => x.weaponNo == searchWeaponNo);
    }
    // Start is called before the first frame update
}
