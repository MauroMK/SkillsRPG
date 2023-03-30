using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertToRegularMesh : MonoBehaviour
{
    //* This script helps to replace the skinned mesh renderer of the objects that we want to put in scene
    //* to normal mesh filter and mesh renderer components

    [ContextMenu("Convert to regular mesh")]
    void Convert()
    {
        // Get and add the components
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        // Put the Skinned Mesh Renderer mesh and materials to the filter and renderer variables
        meshFilter.sharedMesh = skinnedMeshRenderer.sharedMesh;
        meshRenderer.sharedMaterials = skinnedMeshRenderer.sharedMaterials;

        // Delete the Skinned Mesh Renderer
        DestroyImmediate(skinnedMeshRenderer);
        DestroyImmediate(this);
    }
}
