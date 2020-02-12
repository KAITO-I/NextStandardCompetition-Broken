using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class Demon : BaseEnemy
{
    [SerializeField]
    int _xRange, _yRange;

    Tilemap _tilemap;

    bool _blockDis;
    protected override void Start()
    {
        _tilemap = GameObject.FindWithTag("Block").GetComponent<Tilemap>();
        _blockDis = true;
    }

    protected override void Update()
    {
        if (_blockDis)//タイルを出現させる処理
        {
            BlockDisplay();
        }
    }

    //ブロックを出現させる処理//コライダーがついていない可能性？？
    private void BlockDisplay()
    {
            var screenToWorldPointPosition = gameObject.transform.position;
            Vector3Int vlickPosition = _tilemap.WorldToCell(screenToWorldPointPosition);//タイルのポジション
            vlickPosition.x += Random.Range(-_xRange - 1, -1);
            vlickPosition.y += Random.Range(-_yRange, _yRange);
            Debug.Log(vlickPosition);
            _tilemap.SetTile(vlickPosition, _blockTile);//「0」の部分はやってみないとわからない
            _blockDis = false;
    }
}
