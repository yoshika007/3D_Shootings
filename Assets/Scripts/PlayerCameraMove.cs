using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//ジョイスティックの動きを受け取ってプレイヤーカメラを動かす
public class PlayerCameraMove : MonoBehaviour
{
    //プレイヤーのオブジェクト
    [SerializeField] private GameObject _player;

    //参照をするインプットパラメータ
    [SerializeField] private InputAction _moveAction;

    private Vector2 _joyStickPosition;

    //今ジョイスティックが動いているか
    private bool _isJoyStickMove = false;

    void Start()
    {
        //インプットシステムの有効化
        _moveAction.Enable();
        //ジョイスティックを動かした時に呼ばれる
        _moveAction.performed += _ =>
        {
            Vector2 value = _moveAction.ReadValue<Vector2>();
            _joyStickPosition = value;
            _isJoyStickMove = true;
        };

        //ジョイスティックが止まった時
        _moveAction.canceled += _ =>
        {
            _isJoyStickMove = false;
        };

    }

    //常に呼ばれる
    void Update()
    {
        if(_isJoyStickMove)
        {
            Vector3 angle = _player.transform.localEulerAngles;
            angle.x -= _joyStickPosition.y * Time.deltaTime * 50;
            angle.y += _joyStickPosition.x * Time.deltaTime * 50;

            //編集後の角度を入れる
            _player.transform.localEulerAngles = angle;
        }
    }
}
