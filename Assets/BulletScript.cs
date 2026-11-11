using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float ImpulsePower;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        AddmyForce();
    }
    public void AddmyForce()
    {
        _rb.AddForce(Vector2.right * ImpulsePower, ForceMode2D.Impulse);
    }
}
