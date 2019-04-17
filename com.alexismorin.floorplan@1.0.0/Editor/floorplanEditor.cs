using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (floorplan))]
public class floorplanEditor : Editor {

    public override void OnInspectorGUI () {
        DrawDefaultInspector ();

        floorplan script = (floorplan) target;
        if (GUILayout.Button ("Spawn Pillar")) {
            script.createInstance (script.tileset.pillarTile, script.gameObject.transform.position, Quaternion.identity);
        }
        if (GUILayout.Button ("Spawn Floor Tile")) {
            script.createInstance (script.tileset.floorTile, script.gameObject.transform.position, Quaternion.LookRotation (Vector3.right, Vector3.up));
        }

    }

    void OnSceneGUI () {
        floorplan script = (floorplan) target;
        Event e = Event.current;
        switch (e.type) {
            case EventType.KeyDown:
                {
                    if (Event.current.keyCode == (KeyCode.Space)) {
                        script.ToggleTool ();
                    }
                    break;
                }
        }
    }
}