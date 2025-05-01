using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneManagerL2 : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject flea;
    [SerializeField] private GameObject pet;
    [SerializeField] private GameObject dragger;
    [SerializeField] private GameObject playerSpawn;
    [SerializeField] private GameObject petSpawn;
    public delegate void SceneStarted();
    public static event SceneStarted sceneStarted2;
    // Start is called before the first frame update
    void Awake()
    {
        cam = GameObject.Find("Camera");
        player = GameObject.Find("Player");
        flea = GameObject.Find("Flea");
        pet = GameObject.Find("Pet");
        dragger = GameObject.Find("DragController");
        playerSpawn = GameObject.Find("PlayerSpawn");
        petSpawn = GameObject.Find("PetSpawn");
    }

    void Start() {
        sceneStarted2();
        player.transform.SetPositionAndRotation(playerSpawn.transform.position, player.transform.rotation);    
        pet.transform.SetPositionAndRotation(petSpawn.transform.position, pet.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            player.transform.SetPositionAndRotation(playerSpawn.transform.position, player.transform.rotation);    
            pet.transform.SetPositionAndRotation(petSpawn.transform.position, pet.transform.rotation); 
        }
    }
}
