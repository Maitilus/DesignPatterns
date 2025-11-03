using UnityEngine;

public class EnemyAggroCheck : MonoBehaviour
{
    public GameObject playertarget { get; set; }
    private Enemy Enemy;

    void Awake()
    {
        playertarget = GameObject.FindGameObjectWithTag("Player");

        Enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == playertarget)
        {
            Enemy.SetAggroStatus(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == playertarget)
        {
            Enemy.SetAggroStatus(false);
        }
    }
}
