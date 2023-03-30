using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int score = 10;
    
    public Vector3 currPos;
    public Vector2 currPos2;
    public Color warna;
    public Light lampu;
    public Material material;

    public string namaGO;
    public Vector3 posisiGO;
    public float fovCamera;

    // Start is called before the first frame update
    void Start()
    {
        namaGO = gameObject.name;
        posisiGO = gameObject.transform.position;

        fovCamera = gameObject.GetComponent<Camera>().fieldOfView;

        Debug.Log("Nama GO Adalah: " + gameObject.name);
        Debug.Log("Posisi GO Ada di: " + gameObject.transform.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
