using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManagerL1 : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject flea;
    [SerializeField] private GameObject pet;
    [SerializeField] private GameObject dragger;
    [SerializeField] private GameObject playerSpawn;
    [SerializeField] private GameObject petSpawn;
    [SerializeField] private GameObject musicBox;
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
        musicBox = GameObject.Find("MusicBox");
        DontDestroyOnLoad(cam);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(flea);
        DontDestroyOnLoad(pet);
        DontDestroyOnLoad(dragger);
        DontDestroyOnLoad(musicBox);

    }

    void Start() {
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
