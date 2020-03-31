using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class NewsSource
{
    public string id;
    public string name;
}

[System.Serializable]
public class NewsReport
{
    public NewsSource source;
    public string author;
    public string title;
    public string description;
    public string url;
    public string urlToImage;
    public string publishedAt;
    public string content;
}

[System.Serializable]
public class RootNewsClass
{
    public long totalResults;
    public NewsReport[] articles;
}

public class NewsData : MonoBehaviour
{
    public RootNewsClass rootNewsClass;

    private string uri = "https://newsapi.org/v2/top-headlines?";
    private string newsData;

    public void GetNewsData()
    {
        StartCoroutine(NewsStat());
    }

    private IEnumerator NewsStat()
    {
        uri += "q=COVID&sortBy=relevancy&apiKey=debe24b0254d4badb176996b8065495b&pageSize=100&page=1&language=en";

        UnityWebRequest req = UnityWebRequest.Get(uri);

        yield return req.SendWebRequest();

        if (!req.isNetworkError)
        {
            Debug.Log(req.responseCode);
            newsData = req.downloadHandler.text;

            rootNewsClass = JsonUtility.FromJson<RootNewsClass>(newsData);

            Debug.Log(rootNewsClass.articles[0].source.name);
            Debug.Log(rootNewsClass.articles[0].title);
        }
        else
        {
            Debug.Log(req.responseCode);
            Debug.Log(req.error);
        }
    }
}
