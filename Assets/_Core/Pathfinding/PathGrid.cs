using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGrid : MonoBehaviour {



    public LayerMask unwalkableMask;
    public Vector3 gridWorldSize;
    public float nodeRadius;
    Node[,] grid;
    float nodeDiameter;
    int gridSizeX, gridSizeY;
    GameObject player;

    void Start() {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.z / nodeDiameter);
        player = GameObject.FindGameObjectWithTag("Player");
        CreateGrid();
    }

    private void CreateGrid() {
        grid = new Node[gridSizeX, gridSizeY];
        Debug.Log("Grid: " + grid + " Grid Length: " + grid.Length);
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.z / 2;
    for (int x = 0; x < gridSizeX; x++) {
        for (int y = 0; y < gridSizeY; y++) {
            Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask)); //this is where i check for collision and get a walkable..
                grid[x, y] = new Node(walkable, worldPoint, x, y);
            }
        }
    }

    public Node NodeFromWorldPoint(Vector3 worldPosition) {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.z + gridWorldSize.z / 2) / gridWorldSize.z;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return grid[x, y]; 
    }
    void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.z));
        if (grid!= null) {
            Node playerNode = NodeFromWorldPoint(player.transform.position);

            foreach (Node node in grid) {
                Gizmos.color = (node.walkable) ? Color.white : Color.red;
                if (playerNode == node) {
                    Gizmos.color = Color.cyan;
                }
             
                Gizmos.DrawCube(node.worldPosition, Vector3.one * (nodeDiameter -.1f));
            }
        }
    }
    public List<Node> GetNeighbours (Node node) {
        List<Node> neighbours = new List<Node>();

        for (int x = -1; x <= 1; x++) {
            for (int y = -1; y <= 1; y++) {
                if (x == 0 && y == 0)
                    continue;
                int checkX = node.gridX + x;
                int checkY = node.gridY + y;
                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY) {
                    neighbours.Add(grid[checkX, checkY]);
                } 
            }
            }

            return neighbours;
    }
    public int MaxSize {
        get {
            return gridSizeX * gridSizeY;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
