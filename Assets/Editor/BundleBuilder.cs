using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BundleBuilder : Editor
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles(){
        BuildPipeline.BuildAssetBundles(@"/Users/guo/Documents/codes/Unity/4995/AssetsBundleTest/UnityBundles", BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.Android);
    }
}
