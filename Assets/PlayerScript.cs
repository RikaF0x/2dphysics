using UnityEngine;

public class PlayerScript : MonoBehaviour
{
     [SerializeField] private float speed;
     [SerializeField] private float jumpForce;
     [SerializeField] private GameObject BulletPrefab;
     [SerializeField] private Transform FirePoint;
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
               _isGrounded = false;
          }

          if (Input.GetKeyDown(KeyCode.Return))
          {
               GameObject _bullet = Instantiate(BulletPrefab, FirePoint.position + new Vector3(h*1, 0), FirePoint.rotation);
               
          }
     }

     private void FixedUpdate()
     {
          
          rb.linearVelocityX = h*speed*Time.fixedDeltaTime;
     }

     private void OnCollisionEnter2D(Collision2D collision)
     {
          if (collision.gameObject.tag == "Ground")
          {
               _isGrounded = true;
          }
     }
}
