using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Highlighter))]
public class RubicController : MonoBehaviour
{
    private List<MeshRenderer> selection = new List<MeshRenderer>();
    private float delta = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
            DeselectAll();

        Func<Vector3, bool> selector = null;
        bool selectionChanged = false;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selector = position => position.y > transform.position.y + delta;
            selectionChanged = true;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selector = position => position.y < transform.position.y - delta;
            selectionChanged = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selector = position => position.x < transform.position.x - delta;
            selectionChanged = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selector = position => position.x > transform.position.x + delta;
            selectionChanged = true;
        }

        if (selectionChanged)
        {
            IterateChilds(transform, selector);
            GetComponent<Highlighter>().EnableHighlight(selection);
        }
    }

    private void IterateChilds(Transform goTransform, Func<Vector3, bool> selector)
    {
        foreach (Transform child in goTransform)
        {
            if (selector(child.position))
            {
                var mesh_renderer = child.GetComponent<MeshRenderer>();
                if (mesh_renderer != null)
                {
                    selection.Add(mesh_renderer);
                }
            }
            IterateChilds(child, selector);
        }
    }

    void DeselectAll()
    {
        GetComponent<Highlighter>().DisableHighlight(selection);
        selection.Clear();
    }
}
