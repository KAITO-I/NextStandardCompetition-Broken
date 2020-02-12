using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Salamander : BaseEnemy
{
    [SerializeField]
    int _xRange;
    Tilemap _tileMap,_trapMap;
    bool _downDis;
    protected override void Start()
    {
        _tileMap = GameObject.FindWithTag("Block").GetComponent<Tilemap>();
        _trapMap = GameObject.FindWithTag("Trap").GetComponent<Tilemap>();
        _downDis = true;
    }
    protected override void Update()
    {
        if (_downDis)
        {
            DownTrap();
        }
    }

    private void DownTrap()
    {
        var screenToWorldPointPosition = gameObject.transform.position;
        Vector3Int vlickPosition = _trapMap.WorldToCell(screenToWorldPointPosition);//タイルのポジション
        vlickPosition.y -= 1;
        vlickPosition.x += Random.Range(-_xRange - 1, -1);

        _tileMap.SetTile(vlickPosition, _blockTile);//「0」の部分はやってみないとわからない
        _downDis = false;
    }
}
