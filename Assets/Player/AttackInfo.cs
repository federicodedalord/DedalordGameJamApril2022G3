using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInfo : MonoBehaviour
{
    public BoxCollider2D attackCollider;
    public float attackTime;

    private void Start()
    {
        attackCollider.enabled = false;
    }

    public void Attack()
    {
        attackCollider.enabled = true;
        StartCoroutine("FinishAttack");
    }

    IEnumerator FinishAttack()
    {
        yield return new WaitForSeconds(attackTime);
        attackCollider.enabled = false;
    }
}
