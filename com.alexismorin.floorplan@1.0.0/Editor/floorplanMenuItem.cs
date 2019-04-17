using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class floorplanMenuItem : MonoBehaviour {

    [MenuItem ("Tools/Add Floorplan Handle")]
    static void addFloorplanHandle () {
        GameObject floorplanGeometryGameObject = new GameObject ("New Floorplan Geometry");
        GameObject floorplanHandleGameObject = new GameObject ("New Floorplan Handle");
        floorplanHandleGameObject.AddComponent<floorplan> ();
    }
}