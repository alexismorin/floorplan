using System.Collections;
using UnityEngine;

[CreateAssetMenu (fileName = "New Floorplan Tileset", menuName = "Floorplan Tileset")]
public class floorplanTileset : ScriptableObject {
    public GameObject floorTile;
    public GameObject wallTile;
    public GameObject archTile;
    public GameObject windowTile;
    public GameObject pillarTile;
}