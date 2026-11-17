using UnityEngine;

public class PlayerScript : MonoBehaviour
{
     [SerializeField] private float speed;
     [SerializeField] private float jumpForce;
     [SerializeField] private GameObject BulletPrefab;
     [SerializeField] private Transform FirePoint;
     [SerializeField] private Transform groundCheck;
     [SerializeField] private float groundCheckRadius;
     private Rigidbody2D rb;
     private float h = 0;
     private bool _isGrounded;
     private void Awake()
     {
          rb = GetComponent<Rigidbody2D>();
     }

     private void Update()
     {
          h = Input.GetAxis("Horizontal");
          if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
          {
               rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
          }

          if (Input.GetKeyDown(KeyCode.Return))
          {
               GameObject _bullet = Instantiate(BulletPrefab, FirePoint.position + new Vector3(h*1, 0), FirePoint.rotation);
               
          }
     }

     private void FixedUpdate()
     {
          
          rb.linearVelocityX = h*speed*Time.fixedDeltaTime;
          _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, LayerMask.GetMask("GroundObj"));
     }

     private void OnDrawGizmos()
     {
          Gizmos.color = Color.red;
          Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
     }
}
