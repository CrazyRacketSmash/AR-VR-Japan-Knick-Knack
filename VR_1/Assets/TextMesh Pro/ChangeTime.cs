using UnityEngine;
using System;

public class TimeSceneChange : MonoBehaviour
{
    public Light sceneLight;

    void Start()
    {
        int hour = DateTime.Now.Hour;

        if (hour < 12)
        {
            sceneLight.color = Color.yellow;// Morning
        }
        else if (hour < 18)
        {
            sceneLight.color = Color.white; //Afternoon
        }
        else
        {
            sceneLight.color = Color.blue; //Night
        }
    }
}