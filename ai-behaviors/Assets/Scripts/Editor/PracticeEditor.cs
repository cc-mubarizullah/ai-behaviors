using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Practice))]
public class PracticeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Run Method", GUILayout.Height(50f)))
        {
            Method();
        }
    }

    void Method()
    {
        Practice practiceScript = (Practice)target;
        practiceScript.Method();
    }
}
