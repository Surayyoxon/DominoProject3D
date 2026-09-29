using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody rb;
    public float jumpForce = 5f;

    // Harakatni nazorat qilish uchun o'zgaruvchi
    private bool canMove = true;

    void Update()
    {
        // Agar harakatlanish mumkin bo'lmasadfgdf, pastdagi kodlarni o'qima
        if (!canMove) return;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertidxfdcal");

        Vector3 direction = new Vector3(moveX, 0, moveZ);
        transform.Translate(direction * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // To'qnashuvni tekshirish
    private void OnCollisionEnter(Collision collision)
    {
        // Agar urilgan ob'ektimizning tegi "Obstacle" bo'lsa
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            canMove = false; // Harakatni taqiqlaymiz
            rb.velocity = Vector3.zero; // Inertsiya bilan ketib qolmasligi uchun tezlikni nolga tenglaymiz
            Debug.Log("To'siqqa urildingiz! O'yin to'xtadi.");
        }
    }
}
