using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FleaBehavior : MonoBehaviour
{
    [SerializeField] Transform PlayerPos;
    [SerializeField] private new CircleCollider2D collider;
    [SerializeField] private SpriteRenderer SR;
    [SerializeField] private Rigidbody2D RB;

    bool isFiring;
    //bool isGrounded;
    private float HInput;
    public delegate void FireFinished();
    public static event FireFinished fireFinished;
    

    // Start is called before the first frame update
    void Awake() {
        isFiring = false;
        DragController.onFleaFired += Fire;
        PetController.fleaLand += Hide;
        sceneManagerL2.sceneStarted2 += Hide;
    }
    void Start()
    {
        Hide();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Door") {
            Debug.Log("next level");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)) {
            Aim();
        }
        if(Input.GetMouseButtonDown(1)) {
            Hide();
        }
        if(RB.velocity.magnitude < 0.001f && isFiring) {
            Hide();
        }

        /*if(isFiring && !isGrounded) {
            HInput = Input.GetAxisRaw("Horizontal");
            RB.velocity = new Vector2(HInput + RB.velocity.x, RB.velocity.y);
        }*/
    }
    /*
    private void OnCollisionEnter2D(Collision2D other) {
        isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D other) {
        isGrounded = false;
    }
    */
    void Hide() {
        fireFinished();
        SR.enabled = false;
        RB.velocity = Vector2.zero;
        RB.gravityScale = 0f;
        collider.enabled = false;
    }

    void Aim() {
        RB.velocity = Vector2.zero;
        transform.SetPositionAndRotation(PlayerPos.position, transform.rotation);
    }

    void Fire() {
        isFiring = true;
        SR.enabled = true;
        RB.gravityScale = 1f;
        collider.enabled = true;
    }


}
