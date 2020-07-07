using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubicBuilder : MonoBehaviour
{
    public GameObject platePrefab;

    // Start is called before the first frame update
    void Start()
    {
        CreateSide(Vector3.down, Quaternion.Euler(90, 0, 0), "down", new Color(0.8f, 0.65f, 0.1f));
        CreateSide(Vector3.up, Quaternion.Euler(90, 0, 0), "up", Color.white);
        CreateSide(Vector3.forward, Quaternion.Euler(0, 0, 0), "front", new Color(0.2f, 0.2f, 0.95f));
        CreateSide(Vector3.back, Quaternion.Euler(0, 0, 0), "back", new Color(0.6f, 1, 0.65f));
        CreateSide(Vector3.left, Quaternion.Euler(0, 90,0), "left", new Color(1, 0.6f, 0.65f));
        CreateSide(Vector3.right, Quaternion.Euler(0, 90, 0), "right", new Color(1, 0.3f, 0.2f));
    }

    GameObject CreateSide(Vector3 v, Quaternion q, string name, Color color)
    {
        GameObject sideGO = new GameObject(name);
        sideGO.transform.parent = transform;

        for (int x = -1; x <= 1; x++)
            for (int y = -1; y <= 1; y++)
            {
                var go = Instantiate(platePrefab, new Vector3(x, y, 0), Quaternion.identity, sideGO.transform);
                var mesh = go.GetComponent<MeshRenderer>();
                mesh.material.color = color;
            }
        sideGO.transform.rotation = q;
        sideGO.transform.position = v * 1.5f;
        return sideGO;
    }


}
