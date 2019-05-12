using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadAssetBundles : MonoBehaviour
{
    // Start is called before the first frame update
    string bundleURL = @"https://drive.google.com/open?id=1LytrMiJUFMO8cPWKEVjv46h90A98BtI3";
    public string assetName;
    AssetBundle bundle;

    IEnumerator GetAssetBundle() {
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle("https://drive.google.com/open?id=1LytrMiJUFMO8cPWKEVjv46h90A98BtI3");
        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            bundle = DownloadHandlerAssetBundle.GetContent(www);
            var prefabs = bundle.LoadAllAssets();
            foreach(var prefab in prefabs){
                Instantiate(prefab);
            }
        }
    }

    void Start()
    {
        StartCoroutine(GetAssetBundle());
    }

}
