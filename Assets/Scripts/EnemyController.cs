using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int Health = 10;
    public Animator enemyAnim;

    private void Update()
    {
        if(Health <= 0)
        {
            Debug.Log("Enemy Dead");
            Destroy(gameObject);
        }
    }

    public void LoseHealth()
    {
        Health = Health - 1;
        StartCoroutine("AnimDelay");
    }

    IEnumerator AnimDelay(float time)
    {
        time = 1f;

        enemyAnim.SetBool("IsHit", true);
        
        yield return new WaitForSeconds(time);
        
        enemyAnim.SetBool("IsHit", false);
    }
}
