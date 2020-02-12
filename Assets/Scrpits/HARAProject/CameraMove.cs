using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    bool MoveChack;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        MoveChack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveChack)//カメラが動いているかどうか
        {
            gameObject.transform.position += new Vector3(speed, 0, 0);
        }

    }
}
