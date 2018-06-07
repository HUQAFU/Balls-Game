using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialSet", menuName = "Settings/Balls/MaterialSet", order = 1)]
public class MaterialSet : ScriptableObject {
    public Material[] Materials;
}
