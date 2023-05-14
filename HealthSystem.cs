using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float healthPlayer;

    // Start is called before the first frame update
    void Start()
    {
        healthPlayer = 100f;    
    }

    // Update is called once per frame
    void Update()
    {
        // if(healthPlayer > 0){
        //     Debug.Log("Player Alive");
        // }else{
        //     Debug.Log("Player Dead");
        // }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Obstacle"){
            healthPlayer -= 20f;
        }
        if(other.tag == "Enemy"){
            healthPlayer -= 25f;
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.tag == "Fire"){
            healthPlayer -= 0.25f;
        }
    }
}
