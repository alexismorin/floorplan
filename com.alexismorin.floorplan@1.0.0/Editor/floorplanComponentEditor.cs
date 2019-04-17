using System.Collections;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (floorplanComponent))]
public class floorplanComponentEditor : Editor {
    public override void OnInspectorGUI () {
        DrawDefaultInspector ();

        floorplanComponent componentScript = (floorplanComponent) target;
        if (GUILayout.Button ("Convert to Wall")) {
            componentScript.ChangeComponentType (componentScript.tileset.wallTile);
        }
        if (GUILayout.Button ("Convert to Arch")) {
            componentScript.ChangeComponentType (componentScript.tileset.archTile);
        }
        if (GUILayout.Button ("Convert to Window")) {
            componentScript.ChangeComponentType (componentScript.tileset.windowTile);
        }
    }
}