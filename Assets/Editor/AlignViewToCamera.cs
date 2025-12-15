using UnityEngine;
using UnityEditor;

public class AlignViewToCamera
{
    public static void Execute()
    {
        GameObject camObj = GameObject.Find("Main Camera");
        if (camObj != null)
        {
            // Align Scene View to Main Camera
            SceneView.lastActiveSceneView.AlignViewToObject(camObj.transform);
            SceneView.lastActiveSceneView.Repaint();
        }
    }
}
