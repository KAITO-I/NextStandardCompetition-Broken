using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //壁から抜けた場合の距離計算
        //必殺
        gameObject.transform.position += new Vector3(speed, 0, 0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //攻撃アニメーションを再生

        }
        else if (collision.tag == "Block")
        {
            speed = 0;
        }
        else
        {
            speed = 5f;
        }
    }
}