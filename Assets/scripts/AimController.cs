using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimController : MonoBehaviour
{
    public Image aimImage;
    public GameObject aim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                // Æ€Ší‚ğÔF‚É•Ï‰»‚³‚¹‚éB
                aimImage.color = Color.red;

                // aim‚Ì‘å‚«‚³‚ğ¬‚³‚­‚·‚é
                aim.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else
            {
                // Æ€Ší‚ğ”’‚É–ß‚·B
                aimImage.color = Color.white;

                // aim‚Ì‘å‚«‚³‚ğŒ³‚É–ß‚·
                aim.transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            aimImage.color = Color.white;
            aim.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
