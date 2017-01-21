using System.
Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Wall : ObstaculoEstatico {

	[Serializable]
	public struct WallColor {
		public string colorName;
		public Material material;
	}
	public List<WallColor> colors;
	public Dictionary<string, Material> wallColors;

	public Material selectedMaterial;

	void Start () {
		wallColors = colors.ToDictionary(color => color.colorName, color => color.material);
	}

	void Update () {
	}

	override public void Initialize(GlobalConfig.ColorsToLines colorsToLines){
		base.Initialize (colorsToLines);
		var material = wallColors [colorsToLines.color];
		var children = GetComponentsInChildren<MeshRenderer> ();
		foreach (var child in children){
			child.material = material;
		}
	}
}
