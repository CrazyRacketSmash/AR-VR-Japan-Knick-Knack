using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class KyotoWeather : MonoBehaviour
{
    public TextMeshPro text;
    public string apiKey = "4c91371cc501ca36efe3e4fc68ea84d2";
    float updateInterval = 600f; // update every 10 minutes

    void Start()
    {
        StartCoroutine(UpdateWeather());
    }

    IEnumerator UpdateWeather()
    {
        while (true)
        {
            string url =
                "https://api.openweathermap.org/data/2.5/weather?q=Kyoto,jp&units=metric&appid=" + apiKey;

            UnityWebRequest request = UnityWebRequest.Get(url);
            yield return request.SendWebRequest();


            string json = request.downloadHandler.text;
            WeatherData data = JsonUtility.FromJson<WeatherData>(json);
            text.text = $"{data.main.temp}°C";


            yield return new WaitForSeconds(updateInterval);
        }
    }

    [System.Serializable]
    public class WeatherData
    {
        public Main main;
    }

    [System.Serializable]
    public class Main
    {
        public float temp;
    }
}