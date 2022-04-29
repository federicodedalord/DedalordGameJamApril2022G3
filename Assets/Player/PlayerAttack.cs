using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AttackInfo[] attackInfo;

    public void Attack(int phase)
    {
        switch (phase)
        {
            case 1:
            case 2:
                break;
            case 3:
                attackInfo[0].Attack();
                break;
            case 4:
                attackInfo[1].Attack();
                break;
            case 5:
                attackInfo[2].Attack();
                break;
            case 6:
                attackInfo[3].Attack();
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
        {
            Attack((int)GameManager.Instance.stage);
        }
    }
}
