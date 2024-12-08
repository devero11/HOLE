using UnityEngine;

public class HolesMeshGenerator : MonoBehaviour
{
    public Transform[] holes;
    public PolygonCollider2D hole2D;
    public PolygonCollider2D ground2D;

    Mesh GeneratedMesh;
    public MeshCollider GeneratedMeshCollider;


    void FixedUpdate()
    {

        for (int i = 0; i < holes.Length; i++)
            MakeHoles2D(new Vector2(holes[i].position.x, holes[i].position.z), i + 1);
        Make3DMeshCollider();
    }
    private void MakeHoles2D(Vector2 vec, int index)
    {
        hole2D.transform.position = vec;
        Vector2[] PointPositions = hole2D.GetPath(0);
        
        for (int i = 0; i < PointPositions.Length; i++)
        {   PointPositions[i] *= holes[index-1].transform.localScale;
            PointPositions[i] += (Vector2)hole2D.transform.position;
            
        }

        ground2D.pathCount = 11;
        ground2D.SetPath(index, PointPositions);
    }
    private void Make3DMeshCollider()
    {
        if (GeneratedMesh != null) Destroy(GeneratedMesh);
        GeneratedMesh = ground2D.CreateMesh(true, true);
        GeneratedMeshCollider.sharedMesh = GeneratedMesh;
    }
}
