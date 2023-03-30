 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animasi : MonoBehaviour
{
    private float kecepatan_player;

    private float nilai_x;
    private float nilai_z;
    private bool isGround;
    private bool isRun;
    private bool isJump;


    private Animator anim;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        kecepatan_player = player.GetComponent<Move>().kecepatan;
        nilai_x = player.GetComponent<Move>().x;
        nilai_z = player.GetComponent<Move>().z;

        isGround = player.GetComponent<Move>().isGround;
        isRun = player.GetComponent<Move>().isRun;
        isJump = player.GetComponent<Move>().isJump;

        anim.SetFloat("x", nilai_x);
        anim.SetFloat("z", nilai_z);
        anim.SetBool("isGround", isGround);
        anim.SetBool("isRun", isRun);
        anim.SetBool("isJump", isJump);
    }
}
