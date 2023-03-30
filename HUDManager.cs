using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Image currentEnergy;
    private GameObject player;
    private float energy = 200;
    private float maxEnergy = 200;
    public float kecepatan;
    private float kecepatanLari;
    private float input_x;
    private float input_z;
    private bool isRun = false;
    private bool isJump = false;

    public Text time;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        kecepatanLari = player.GetComponent<Move>().speed_lari;
    }

    // Update is called once per frame
    void Update()
    {
        kecepatan = player.GetComponent<Move>().kecepatan;
        input_x = player.GetComponent<Move>().x;
        input_z = player.GetComponent<Move>().z;
        isRun = player.GetComponent<Move>().isRun;
        isJump = player.GetComponent<Move>().isJump;
        EnergyDrain();
        UpdateEnergy();
    }

    private void EnergyDrain(){
        if(kecepatan == kecepatanLari){
            if((input_x > 0|| input_z > 0) && energy > 0 ){
                energy -= 5 * Time.deltaTime;
            }
        }else{
            if(energy < maxEnergy){
                energy += 35 * Time.deltaTime;
            }
        }
        if(isJump == true){
            energy -= 40 * (Time.deltaTime * 3);
        }
    }
    
    private void UpdateEnergy(){
        float ratio = energy / maxEnergy;
        currentEnergy.rectTransform.localScale = new Vector3(ratio, 1,1);
    }
    
}
