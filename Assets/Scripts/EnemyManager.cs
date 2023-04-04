using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    //コピー元の敵オブジェクト
    [SerializeField] private EnemyBase _originalEnemy;

    //作成するまでの時間
    private float _createTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //5秒経過していないなら先に進まない
        if (_createTimer < 5.0f)
        {
            _createTimer += Time.deltaTime;
            return;
        }
        _createTimer = 0;

        //敵の複製を作る
        EnemyBase enemyBase = (EnemyBase)Instantiate(_originalEnemy,
            new Vector3(UnityEngine.Random.Range(-80.0f, 80.0f),
            UnityEngine.Random.Range(-60.0f, 80.0f),
            UnityEngine.Random.Range(20.0f, 180.0f)),
            Quaternion.identity);

        //こちらを向かせる
        enemyBase.gameObject.transform.LookAt(Camera.main.transform.localPosition);
    }
}
