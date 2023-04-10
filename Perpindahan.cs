    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Perpindahan : MonoBehaviour
    {

        public List<Vector3> posisi = new List<Vector3>();
        public int index = 0;
        public int indexCurr;

        public GameObject cam;
        public bool isMoving = false;

        // Start is called before the first frame update
        void Start()
        {
            posisi.Add(GameObject.Find("Cam1").transform.position);
            posisi.Add(GameObject.Find("Cam2").transform.position);
            // posisi.Add(GameObject.Find("Cam3").transform.position);
            posisi.Add(new Vector3(-23.35382f,16.96111f,20.68188f));
        }

        // Update is called once per frame
        void Update()
        {   
            //next
            if(Input.GetKeyDown(KeyCode.E)){
                index++;
                cam.transform.position = posisi[indexCurr];

                indexCurr = index % posisi.Count;
                isMoving = true;

                // if(index >= posisi.Count){
                //     index = 0;
                // }

            }
            // prev
            if(Input.GetKeyDown(KeyCode.Q)){
                index--;
                indexCurr = index % posisi.Count;

                // cam.transform.position = posisi[indexCurr];
                isMoving = true;
                // if(index <= posisi.Count){
                //     index = 0;
                // }
            }

            cam.transform.position = Vector3.Lerp(
                    cam.transform.position, 
                    posisi[indexCurr], 
                    Time.deltaTime);

            if(isMoving){
                
                // isMoving = false;
            }
        
        }
    }
