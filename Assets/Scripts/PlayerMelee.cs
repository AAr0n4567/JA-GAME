using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            EnemyController Enemy = other.gameObject.GetComponent<EnemyController>();

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Player Attack");
                Enemy.Health = Enemy.Health - 1;
            }
        }
    }
}
