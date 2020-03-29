using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NewsData : MonoBehaviour
{
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

            Debug.Log(newsData);
        }
        else
        {
            Debug.Log(req.responseCode);
            Debug.Log(req.error);
        }
    }
}
