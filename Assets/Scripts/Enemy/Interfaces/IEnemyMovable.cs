using UnityEngine;

public interface IEnemyMovable
{
    Rigidbody2D rb { get; set; }

    void MoveEnemy(Vector2 velocity);
}
