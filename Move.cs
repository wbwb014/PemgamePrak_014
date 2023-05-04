using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] public float kecepatan;
    public float x;
    public float z;
    private CharacterController controller;

    private float gravitasi = 15f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    
    public bool isGround;
    public bool isRun;
    public bool isJump;

    Vector3 velocity;
    public float speed_jump = 2.5f;
    public float speed_jalan = 5f;
    public float speed_lari = 10f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        bergerak();
        gravity();
        lompat();
        jalan();
    }

    private void bergerak(){
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        Vector3 gerakan = transform.right * x + transform.forward * z;
        controller.Move(gerakan * kecepatan * Time.deltaTime);
    }

    private void gravity(){
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGround && velocity.y < 0){
            velocity.y = -2f;
        }
        velocity.y -= gravitasi * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void lompat(){
        if(Input.GetButtonDown("Jump")&& isGround ){
            velocity.y = Mathf.Sqrt(speed_jump * 2f * gravitasi);
            
        }
        if(isGround == false){
            isJump = true;
        }
        if(isGround == true){
            isJump = false;
        }
        
        velocity.y -= gravitasi * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
        
    }

    

    private void jalan(){
        if(Input.GetKey(KeyCode.LeftShift)){
            kecepatan = speed_lari;
            isRun = true;
        }else{
            kecepatan = speed_jalan;
            isRun = false;
        }
    }
}