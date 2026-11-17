using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class BulletScript : MonoBehaviour
{
    [FormerlySerializedAs("ImpulsePower")] [SerializeField] private float impulsePower;
    [SerializeField] private float lifetime;
    [SerializeField] private float damage;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        AddmyForce();
        Destroy(gameObject, lifetime);
    }
    public void AddmyForce()
    {
        _rb.AddForce(Vector2.right * impulsePower, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyClass thisenem))
        {
            thisenem.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
