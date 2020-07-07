using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubicController : MonoBehaviour
{
    private List<MeshRenderer> selection = new List<MeshRenderer>();
    private float delta = 0.1f;

    [SerializeField]
    Color selectionColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
            DeselectAll();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Func<Vector3, bool> selector = position => position.y > transform.position.y + delta;
            IterateChilds(transform, selector);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Func<Vector3, bool> selector = position => position.y < transform.position.y - delta;
            IterateChilds(transform, selector);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Func<Vector3, bool> selector = position => position.x < transform.position.x - delta;
            IterateChilds(transform, selector);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Func<Vector3, bool> selector = position => position.x > transform.position.x + delta;
            IterateChilds(transform, selector);
        }
    }

    private void IterateChilds(Transform goTransform, Func<Vector3, bool> selector)
    {
        foreach (Transform child in goTransform)
        {
            if (selector(child.position))
                Select(child);
            IterateChilds(child, selector);
        }
    }

    void Select(Transform t)
    {
        var mesh_renderer = t.GetComponent<MeshRenderer>();
        if (mesh_renderer != null)
        {
            var material = mesh_renderer.materials[1];
            material.color = selectionColor;
            selection.Add(mesh_renderer);
        }
    }

    void DeselectAll()
    {
        foreach (var item in selection)
        {
            var material = item.materials[1];
            material.color = new Color(0.56f, 0.56f, 0.56f);
        }
        selection.Clear();
    }
}
