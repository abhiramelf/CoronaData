using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WorldData : MonoBehaviour
{
    private string uri = "https://coronavirus-monitor.p.rapidapi.com/coronavirus/worldstat.php";
    private string worldData;

    public void GetWorldData()
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
            Debug.Log(req.responseCode);
            worldData = req.downloadHandler.text;

            Debug.Log(worldData);
        }
        else
        {
            Debug.Log(req.responseCode);
            Debug.Log(req.error);
        }
    }
}
