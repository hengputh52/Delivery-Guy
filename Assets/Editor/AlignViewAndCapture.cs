using UnityEngine;
using UnityEditor;

public class AlignViewAndCapture
{
    public static void Execute()
    {
        GameObject camObj = GameObject.Find("Main Camera");
        if (camObj != null)
        {
            SceneView.lastActiveSceneView.AlignViewToObject(camObj.transform);
            SceneView.lastActiveSceneView.Repaint();
        }
    }
}
