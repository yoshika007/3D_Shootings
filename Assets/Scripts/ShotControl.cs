using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControl : MonoBehaviour
{

    [SerializeField] private GameObject _shotOriginal;

    private float _timer = 0;

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer <= 0.25f)
        {
            return;
        }
        _timer = 0;

        //最大距離
        Ray ray = new Ray(Camera.main.transform.localPosition, Camera.main.transform.forward);
        RaycastHit hit;

        //最大距離
        const float maxDistance = 600;

        //Rayにヒットしたオブジェクトがあった場合
        if(Physics.Raycast(ray,out hit,maxDistance))
        {
            //Rayにヒットしたオブジェクト
            GameObject hitObject = hit.collider.gameObject;
            if(hitObject == null)
            {
                return;
            }
            //敵以外だったら処理しない
            if(hitObject.tag != "Enemy")
            {
                return;
            }

            //弾丸の発生場所がカメラの位置
            Vector3 position = Camera.main.transform.localPosition;

            //position.x += 2;

            GameObject shotClone = (GameObject)Instantiate(_shotOriginal, position, Quaternion.identity);

            //AddForceで打ち出す
            Rigidbody shotRigidBody = shotClone.gameObject.GetComponent<Rigidbody>();
            //カメラの向きの方向へパワーを加える
            shotRigidBody.AddForce(Camera.main.transform.forward * 10000);

        }
    }
}
