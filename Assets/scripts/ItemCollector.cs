using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private int itemsToCollect = 5;
    [SerializeField] private float radius = 10.0f;

    private int collectedItems = 0;
    private string itemTag = "Item";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Fキーが押されました");
            TryCollectItem();
        }
    }

    private void TryCollectItem()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        if (hitColliders.Length == 0)
        {
            Debug.Log("アイテムが範囲内にありません");
            return;
        }
        foreach (Collider collider in hitColliders)
        {
            if(!collider.gameObject.CompareTag(itemTag))
            {
                Debug.Log("対象はアイテムではありません");
                continue;
            }

            Debug.Log("アイテムが見つかりました");
            collectedItems++;

            Destroy(collider.gameObject);
            Destroy(collider.gameObject);

            if(collectedItems >= itemsToCollect)
            {
                Debug.Log("Clear");
            }
            break;

        }
    }
}
