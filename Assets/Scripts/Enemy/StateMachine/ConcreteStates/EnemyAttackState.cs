using System.Collections;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private Transform playerTransform;

    private float timer;
    private float timeBetweenShots = 2f;
    private float bulletSpeed = 10f;

    private float exitTimer;
    private float timeTillExit = 3f;
    private float distanceToCountExit = 3f;

    private ObjectPool bulletPool;

    public EnemyAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        bulletPool = enemy.bulletPool;
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();


        enemy.MoveEnemy(Vector2.zero);

        if (timer > timeBetweenShots)
        {
            timer = 0f;

            Vector2 dir = (playerTransform.position - enemy.transform.position).normalized;

            Attack(dir);
        }

        if (Vector2.Distance(playerTransform.position, enemy.transform.position) > distanceToCountExit)
        {
            exitTimer += Time.deltaTime;

            if (exitTimer > timeTillExit)
            {
                enemy.StateMachine.ChangeState(enemy.ChaseState);
            }
        }
        else
        {
            exitTimer = 0f;
        }

        timer += Time.deltaTime;
    }

    //ObjectPooling
    void Attack(Vector2 dir)
    {
        GameObject bullet = bulletPool.GetObject();

        bullet.transform.position = enemy.transform.position;
        bullet.transform.rotation = enemy.transform.rotation;

        Rigidbody2D brb = bullet.GetComponent<Rigidbody2D>();
        brb.linearVelocity = dir * bulletSpeed;

        bulletPool.StartCoroutine(bulletPool.DeactivateBullet(bullet));
    }

    
}
