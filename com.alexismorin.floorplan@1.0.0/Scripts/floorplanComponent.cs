using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class floorplanComponent : MonoBehaviour {
    public floorplanTileset tileset;

    void Start () {

        // I should have overlap prevention code here, really.

        /* Collider[] hitColliders = Physics.OverlapSphere (this.transform.GetChild (0).GetComponent<Renderer> ().bounds.center, 0.1f);

        for (int i = 0; i < hitColliders.Length; i++) {
            if (hitColliders[i].transform.parent.gameObject.name == instanceType.name) {
                DestroyImmediate (hitColliders[i].gameObject);
            }
        }*/
    }

    public void ChangeComponentType (GameObject newType) {
        foreach (Transform child in this.transform) {
            GameObject.DestroyImmediate (child.gameObject);
        }
        GameObject newInstance = GameObject.Instantiate (newType, transform.position, transform.rotation);
        newInstance.transform.parent = this.transform;
    }
}