using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

[System.Serializable]
public class WorldCase
{
    public string total_cases;
    public string total_deaths;
    public string total_recovered;
    public string new_cases;
    public string new_deaths;
}

public class WorldData : MonoBehaviour
{
    public WorldCase worldCase;

    public TMP_Text worldCases;
    public TMP_Text worldRecovered;
    public TMP_Text worldDeaths;

    private string uri = "https://coronavirus-monitor.p.rapidapi.com/coronavirus/worldstat.php";
    private string worldData;

    public void Start()
    {
        StartCoroutine(WorldStat());
    }

    private IEnumerator WorldStat()
    {
        UnityWebRequest req = UnityWebRequest.Get(uri);

        req.SetRequestHeader("X-RapidAPI-Key", "a0d088d060mshb48474326ba8efcp1c9494jsn93e66f94ae53");

        yield return req.SendWebRequest();

        if (!req.isNetworkError)
        {
            worldData = req.downloadHandler.text;

            worldCase = JsonUtility.FromJson<WorldCase>(worldData);

            worldCases.text = worldCase.total_cases;
            worldRecovered.text = worldCase.total_recovered;
            worldDeaths.text = worldCase.total_deaths;
        }
        else
        {
            Debug.Log(req.responseCode);
            Debug.Log(req.error);
        }
    }
}
