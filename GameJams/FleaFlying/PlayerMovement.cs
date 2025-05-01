using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private new BoxCollider2D collider;

    private bool isJumping;
    private bool isMoveable = true;
    private float HInput;
    [SerializeField] private float RunSpeed = 7;
    [SerializeField] private float JumpSpeed = 10;
    [SerializeField] private float fallSpeed = 1;
    [SerializeField] Transform fleaPos;
    private void Awake() {
        FleaBehavior.fireFinished += Unfreeze;
        DragController.onFleaFired += Freeze;
        PetController.fleaLand += newPet;
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Floor") {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Floor") {
            isJumping = true;
        }
    }

    private void Move() { 
        body.velocity = new Vector2(HInput * RunSpeed, body.velocity.y);
        if(Input.GetButtonDown("Jump") && !isJumping) {
            body.AddForce(new Vector2(0, JumpSpeed), ForceMode2D.Impulse);
        }
        if(isJumping && !Input.GetButton("Jump")) {
            body.AddForce(new Vector2(body.velocity.x, fallSpeed * -1));
        }
    }
    private void Update() {
        HInput = Input.GetAxisRaw("Horizontal");
        if(isMoveable){
            Move();
        }
    }

    private void Freeze() {
        isMoveable = false;
    }

    private void Unfreeze() {
        isMoveable = true;
    }

    private void newPet() {
        transform.SetPositionAndRotation(fleaPos.position, transform.rotation);
        Unfreeze();
    }
}
