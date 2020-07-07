using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{

    [SerializeField]
    Color SelectedColor = new Color(0.75f, 0.75f, 0.75f);

    [SerializeField]
    Color DeselectedColor = new Color(0.5f, 0.5f, 0.5f);

    [SerializeField]
    Material SelectedMaterial;

    [SerializeField]
    Material DeselectedMaterial;


    public void EnableHighlight(List<MeshRenderer> selection)
    {
        foreach (var item in selection)
        {
            if (item != null)
            {
                //item.materials[1] = SelectedMaterial;
                var material = item.materials[1];
                material.color = SelectedColor;
            }
        }
    }

    public void DisableHighlight(List<MeshRenderer> selection)
    {
        foreach (var item in selection)
        {
            //item.materials[1] = DeselectedMaterial;
            var material = item.materials[1];
            material.color = DeselectedColor;
        }
        selection.Clear();
    }
}
