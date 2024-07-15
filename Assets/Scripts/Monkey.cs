using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private LayerMask bloonsLayerMask;
    [SerializeField] private float attackInterval;
    [SerializeField] private Vector3 projectilePositionOffset;

    private float halfScreenWidth;
    private bool enemyPresent;
    private bool isAttacking = false;
    private Animator anim;

    private void Awake()
    {
        halfScreenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isAttacking)
            return;

        EnemyDetectionAndShooting();
    }

    private void EnemyDetectionAndShooting()
    {
        float distanceToRight = halfScreenWidth - transform.position.x;
        enemyPresent = Physics2D.Raycast(transform.position, Vector2.right, distanceToRight, bloonsLayerMask);
        
        if (enemyPresent)
        {
            StartCoroutine(ShootRoutine());
        }
    }

    private IEnumerator ShootRoutine()
    {
        isAttacking = true;
        anim.SetTrigger("isThrowing");
        Instantiate(projectile, transform.position + projectilePositionOffset, Quaternion.identity);

        yield return new WaitForSeconds(attackInterval);

        isAttacking = false;
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(32/3f, transform.position.y));
    }*/
}
