using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets random material to MeshRenderer from MaterialSet
/// Author: Adik
/// </summary>
[RequireComponent(typeof(MeshRenderer))]
public class RandomColor : MonoBehaviour
{
    MeshRenderer _renderer;

    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        MaterialSet materialSet = GetMaterialSet();
        SetRandomColorFromColorSet(materialSet);
    }

    /// <summary>
    /// Load MaterialSet from Resources
    /// </summary>
    /// <returns>MaterialSet</returns>
    MaterialSet GetMaterialSet()
    {
        //Using different materials instead of setting random color - for case of Instancing (better for performance)
        //All balls with same material will be drown in 1 draw call
        //Also it will allow you to use some special materials on some balls
        MaterialSet[] materialSets = Resources.LoadAll<MaterialSet>("Settings");
        if (materialSets.Length > 0)
        {
            //Dummy get first color set
            MaterialSet materialSet = materialSets[0];
            return materialSet;
        }
        return null;
    }

    /// <summary>
    /// Set random material from MaterialSet
    /// </summary>
    /// <param name="materialSet">MaterialSet for picking materials</param>
    void SetRandomColorFromColorSet(MaterialSet materialSet)
    {
        if (materialSet)
        {
            _renderer.material = materialSet.Materials[Random.Range(0, materialSet.Materials.Length)];
        }
    }
}
