using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour
{
    [SerializeField]
    private float displayTime = 0;
    [SerializeField]
    private float flashSpeed = 0;
    [SerializeField]
    private Image warningImage = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(WarningAnimation());
        }
    }

    private IEnumerator WarningAnimation()
    {
        float _timeCount = 0;
        float _alpha = 0;
        while (_timeCount < displayTime)
        {
            _timeCount += Time.deltaTime;
            #region 点滅処理
            //点滅判定
            if (_alpha >= 255) _alpha -= _alpha * flashSpeed * Time.deltaTime;
            else if (_alpha <= 0) _alpha += _alpha * flashSpeed * Time.deltaTime;
                //0~255の範囲
                _alpha = Mathf.Clamp(_alpha, 0, 255);
            //透明度の変更
            warningImage.color = new Color(255, 255, 255, _alpha);
            #endregion
            yield return null;
        }
    }
}
