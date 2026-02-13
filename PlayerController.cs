using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float boostMultiplier = 2f;
    public float boundaryX = 9f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        float currentSpeed = moveSpeed;
        if (Input.GetKey(KeyCode.Space))
            currentSpeed *= boostMultiplier;

        Vector3 move = new Vector3(horizontal * currentSpeed, 0, 0);
        controller.Move(move * Time.deltaTime);

        
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -boundaryX, boundaryX);
        transform.position = pos;
    }
}


