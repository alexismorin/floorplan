using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class floorplan : MonoBehaviour {

    bool toolActive;
    [SerializeField]
    public floorplanTileset tileset;
    [Space (15)]
    public bool spawnWalls;
    public bool spawnFloors;
    public bool spawnPillars; // spawn pillars all the time,otherwise only spawn when turning corners
    Vector3 lastHandlePosition;
    Vector3 snapLastHandlePosition;
    Vector3 handlePosition;
    Vector3 lastTileDelta;
    Vector3 tileDelta;
    GameObject geometryRoot;
    float tileSize = 2f;
    Color gizmoColor = Color.red;

    void OnEnable () {
        snapLastHandlePosition = transform.position;
    }

    void Start () {
        snapLastHandlePosition = transform.position;
        geometryRoot = GameObject.Find ("New Floorplan Geometry");
    }

    void Update () {
        if (transform.hasChanged) {

            Vector3 snappedPosition = new Vector3 (Mathf.Ceil (transform.position.x), Mathf.Ceil (transform.position.y), Mathf.Ceil (transform.position.z));
            transform.position = snappedPosition;
            //    Vector3 deltaMovePosition = new Vector3 (snappedPosition.x - snapLastHandlePosition.x, snappedPosition.y - snapLastHandlePosition.y, snappedPosition.z - snapLastHandlePosition.z);
            //    Vector3 tileSizeAdjustedSnap = (tileSize * deltaMovePosition);

            //   Vector3 deltaTileSizeAdjustedSnap = transform.position + tileSizeAdjustedSnap;
            //   print (deltaTileSizeAdjustedSnap);
            if (snappedPosition.x % 2 == 0 && snappedPosition.z % 2 == 0) {
                //  print (deltaTileSizeAdjustedSnap);
                //  print (transform.position);

                transform.position = snappedPosition;

                lastHandlePosition = handlePosition;
                handlePosition = transform.position;
                floorplanHandleCallBack ();
                transform.hasChanged = false;
                snapLastHandlePosition = transform.position;
            }
        }

    }

    void floorplanHandleCallBack () {
        if (toolActive) {
            lastTileDelta = tileDelta;
            tileDelta = lastHandlePosition - handlePosition;
            tileDelta /= tileSize;
            if (tileDelta.magnitude > 0f) {
                if (handlePosition.y == lastHandlePosition.y) { // we check this to ensure that we don't build stuff horizontally and that we dont overlap with things
                    if (spawnFloors) {
                        createInstance (tileset.floorTile, transform.position, Quaternion.LookRotation (Vector3.right, Vector3.up));
                    }
                    if (spawnWalls) {
                        createInstance (tileset.wallTile, transform.position, Quaternion.LookRotation (tileDelta, Vector3.up));
                    }
                }
                if (spawnPillars) {
                    createInstance (tileset.pillarTile, transform.position, Quaternion.identity);
                } else {
                    if (tileDelta != lastTileDelta && spawnWalls) {
                        createInstance (tileset.pillarTile, lastHandlePosition, Quaternion.identity);
                    }
                }

            }
        }
    }

    public void createInstance (GameObject instanceType, Vector3 spawnPosition, Quaternion spawnRotation) {

        GameObject instance = PrefabUtility.InstantiatePrefab (instanceType) as GameObject;
        instance.transform.position = spawnPosition;
        instance.transform.rotation = spawnRotation;
        instance.transform.parent = geometryRoot.transform;
        instance.GetComponent<floorplanComponent> ().tileset = tileset;
        instance.name = instanceType.name;

    }

    public void ToggleTool () {
        if (toolActive == false) {
            gizmoColor = Color.green;
            toolActive = true;
        } else {
            gizmoColor = Color.red;
            toolActive = false;
        }
    }

    void OnDrawGizmos () {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere (transform.position, 0.5f);
    }

}