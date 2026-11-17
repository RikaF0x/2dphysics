using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyClass : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private float _currentHealth;
    private Rigidbody2D rb;
    [SerializeField] private float damage;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _currentHealth = _maxHealth;
    }
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
