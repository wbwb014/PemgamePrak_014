using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Player playerInstance;
    public Image currentEnergy;
    public Image currentHealth;
    private GameObject player;

    private float health = 100;
    private float maxHealth = 100;

    private float energy = 200;
    private float maxEnergy = 200;
    public float kecepatan;
    private float kecepatanLari;
    private float input_x;
    private float input_z;
    private bool isRun = false;
    private bool isJump = false;
    [SerializeField] GameObject pauseMenu;
    public static bool GameIsPaused = false;

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
        ShowPauseMenu();
        HealthDrain();
        UpdateHealth();
    }

    private void HealthDrain(){
        if(Input.GetKeyDown(KeyCode.E)){
            health -= 10;
        }
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
            energy -= 25 * (Time.deltaTime * 3);
        }
    }
    
    private void UpdateEnergy(){
        float ratioEnergy = energy / maxEnergy;
        currentEnergy.rectTransform.localScale = new Vector3(ratioEnergy, 1,1);
    }

    private void UpdateHealth(){
        float ratioHealth = health / maxHealth;
        currentHealth.rectTransform.localScale = new Vector3(ratioHealth, 1, 1);
    }

    private void ShowPauseMenu(){
        if(Input.GetKeyDown(KeyCode.P)){
            if(GameIsPaused){
                Resume();
            }else{
                Pause();
            }
        }
    }
    public void Resume(){
        pauseMenu.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Pause(){
        pauseMenu.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
    }
    
    public void SaveGame(){
        SaveSystem.SavePlayer(playerInstance);

    }
    
}
