using UnityEngine;

public class MeshVertices : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        for (var i = 0; i < vertices.Length; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = vertices[i];
            cube.transform.localScale *= 0.1f;
            //vertices[i] += Vector3.up * Time.deltaTime;
            //vertices[i] = cube.transform.position * Time.deltaTime;
        }

        // assign the local vertices array into the vertices array of the Mesh.
        mesh.vertices = vertices;
        mesh.RecalculateBounds();
    }

}
