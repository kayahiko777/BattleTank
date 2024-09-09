using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BlinkMessage : MonoBehaviour
{
    public Text starttext;
    public float blinkTime;
    // Start is called before the first frame update
    void Start()
    {
        starttext.DOFade(0,blinkTime).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo).SetLink(starttext.gameObject);
    }
}
