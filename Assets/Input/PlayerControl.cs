using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float speed = 5f;

    private Animator animator;
    private Rigidbody2D body;
    private Vector2 inputDir;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }   

    public void OnMovement(InputValue input)
    {
        inputDir = input.Get<Vector2>();

        animator.SetBool("walk", inputDir != Vector2.zero);

        if (inputDir != Vector2.zero)
        {
            animator.SetFloat("x", inputDir.x);
            animator.SetFloat("y", inputDir.y);
        }
    }

    private void FixedUpdate()
    {
        //this.transform.Translate(speed * Time.deltaTime * inputDir);
        body.linearVelocity = inputDir * speed;
    }
}
