using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Classes below serve as objects for storing parsed Json data.
/// </summary>
[System.Serializable]
public class Alappuzha
{
    public long under_observation;
    public long under_home_isolation;
    public long total_hospitalised;
    public long hospitalised_today;
    public long corona_positive;
    public string cured_discharged;
    public long deaths;
}

[System.Serializable]
public class Ernakulam
{
    public long under_observation;
    public long under_home_isolation;
    public long total_hospitalised;
    public long hospitalised_today;
    public long corona_positive;
    public long cured_discharged;
    public long deaths;
}

[System.Serializable]
public class Idukki
{
    public long under_observation;
    public long under_home_isolation;
    public long total_hospitalised;
    public long hospitalised_today;
    public long corona_positive;
    public long cured_discharged;
    public long deaths;
}

[System.Serializable]
public class Kannur
{
    public long under_observation;
    public long under_home_isolation;
    public long total_hospitalised;
    public long hospitalised_today;
    public long corona_positive;
    public long cured_discharged;
    public long deaths;
}

[System.Serializable]
public class Kasaragod
{
    public long under_observation;
    public long under_home_isolation;
    public long total_hospitalised;
    public long hospitalised_today;
    public long corona_positive;
    public long cured_discharged;
    public long deaths;
}

[System.Serializable]
public class Kollam
{
    public long under_observation;
    public long under_home_isolation;
    public long total_hospitalised;
    public long hospitalised_today;
    public long corona_positive;
    public long cured_discharged;
    public long deaths;
}

[System.Serializable]
public class Kottayam
{
    public long under_observation;
    public long under_home_isolation;
    public long total_hospitalised;
    public long hospitalised_today;
    public long corona_positive;
    public long cured_discharged;
    public long deaths;
}

[System.Serializable]
public class Kozhikode
{
    public long under_observation;
    public long under_home_isolation;
    public long total_hospitalised;
    public long hospitalised_today;
    public long corona_positive;
    public long cured_discharged;
    public long deaths;
}

[System.Serializable]
public class Malappuram
{
    public long under_observation;
    public long under_home_isolation;
    public long total_hospitalised;
    public long hospitalised_today;
    public long corona_positive;
    public long cured_discharged;
    public long deaths;
}

[System.Serializable]
public class Palakkad
{
    public long under_observation;
    public long under_home_isolation;
    public long total_hospitalised;
    public long hospitalised_today;
    public long corona_positive;
    public long cured_discharged;
    public long deaths;
}

[System.Serializable]
public class Pathanamthitta
{
    public long under_observation;
    public long under_home_isolation;
    public long total_hospitalised;
    public long hospitalised_today;
    public long corona_positive;
    public long cured_discharged;
    public long deaths;
}

[System.Serializable]
public class Thiruvananthapuram
{
    public long under_observation;
    public long under_home_isolation;
    public long total_hospitalised;
    public long hospitalised_today;
    public long corona_positive;
    public long cured_discharged;
    public long deaths;
}

[System.Serializable]
public class Thrissur
{
    public long under_observation;
    public long under_home_isolation;
    public long total_hospitalised;
    public long hospitalised_today;
    public long corona_positive;
    public long cured_discharged;
    public long deaths;
}

[System.Serializable]
public class Wayanad
{
    public long under_observation;
    public long under_home_isolation;
    public long total_hospitalised;
    public long hospitalised_today;
    public long corona_positive;
    public long cured_discharged;
    public long deaths;
}

[System.Serializable]
public class Kerala
{
    public Alappuzha Alappuzha;
    public Ernakulam Ernakulam;
    public Idukki Idukki;
    public Kannur Kannur;
    public Kasaragod Kasaragod;
    public Kollam Kollam;
    public Kottayam Kottayam;
    public Kozhikode Kozhikode;
    public Malappuram Malappuram;
    public Palakkad Palakkad;
    public Pathanamthitta Pathanamthitta;
    public Thiruvananthapuram Thiruvananthapuram;
    public Thrissur Thrissur;
    public Wayanad Wayanad;
}

[System.Serializable]
public class RootData
{
    public Kerala kerala;
}

/// <summary>
/// MonoBehaviour class to download and parse Json, use parsed data.
/// </summary>
public class KeralaData : MonoBehaviour
{
    private RootData rootData;

    private string uri = "http://volunteer.coronasafe.network/api/reports";
    private string stateData;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetData());
    }

    /// <summary>
    /// Downloads the Json and parses it into objects.
    /// </summary>
    private IEnumerator GetData()
    {
        UnityWebRequest req = new UnityWebRequest(uri, "GET");

        DownloadHandlerBuffer dB = new DownloadHandlerBuffer();
        req.downloadHandler = dB;

        yield return req.SendWebRequest();
        
        if (!req.isNetworkError)
        {
            Debug.Log(req.responseCode);
            stateData = req.downloadHandler.text;

            Debug.Log(stateData);

            rootData = JsonUtility.FromJson<RootData>(stateData);

            // Ex of use : long testData = rootData.kerala.Alappuzha.under_observation;
            // Similarly, data in each district can be obtained.

        }
        else
        {
            Debug.Log(req.responseCode);
            Debug.Log(req.error);
        }
    }
}
