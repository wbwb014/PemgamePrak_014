using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{
    float time;
    GameObject[] allLight;

    // Start is called before the first frame update
    void Start()
    {
        allLight = GameObject.FindGameObjectsWithTag("Lighting");
    }

    // Update is called once per frame
    void Update()
    {
        time = EnviroSky.instance.GameTime.Hours;

        if(time < 18 && time > 6){
            foreach(GameObject i in allLight){
                i.SetActive(false);
            }
        }else{
            foreach(GameObject i in allLight){
                i.SetActive(true);
            }
        }
    }
}
