using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadAssetBundles : MonoBehaviour
{
    // Start is called before the first frame update
    string baseBundleURL = @"https://raw.githubusercontent.com/guotata1996/AssetsBundleTest/master/UnityBundles/";
    public string assetName;
    AssetBundle bundle;

    public Text bundleNameInput;

    IEnumerator GetAssetBundle() {
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(baseBundleURL + bundleNameInput.text);
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

    public void UpdateBundle()
    {
        StartCoroutine(GetAssetBundle());
    }

}
