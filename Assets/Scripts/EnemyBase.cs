using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int lifePoint = 3;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Enemy")
        {
            lifePoint--;
            if(lifePoint == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
