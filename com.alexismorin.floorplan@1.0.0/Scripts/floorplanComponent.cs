using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class floorplanComponent : MonoBehaviour {
    public floorplanTileset tileset;

    void Start () {
        // I should have overlap prevention code here, really.
    }

    public void ChangeComponentType (GameObject newType) {

        //    GameObject newInstance = GameObject.Instantiate (newType, transform.position, transform.rotation);
        GameObject newInstance = PrefabUtility.InstantiatePrefab (newType) as GameObject;
        newInstance.transform.position = this.transform.position;
        newInstance.transform.rotation = this.transform.rotation;
        newInstance.transform.parent = this.transform.parent;
        GameObject.DestroyImmediate (this.gameObject);

    }
}