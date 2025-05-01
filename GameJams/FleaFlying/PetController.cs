using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PetController : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void onFleaLand();
    public static event onFleaLand fleaLand;
    [SerializeField] private Transform playerPos;
    void Awake() {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Flea") {
            transform.SetPositionAndRotation(playerPos.position, transform.rotation);
            fleaLand();
        }
    }




}
