﻿class RaiseHeightmap extends ScriptableWizard {
	var addHeight = .1;
	static var terrain : TerrainData;
 
	@MenuItem ("Terrain/Raise or Lower Heightmap...")
	static function CreateWizard () {
		terrain = null;
		var terrainObject : Terrain = (Selection.activeObject as GameObject).GetComponent(Terrain) as Terrain;
		if (!terrainObject) {
			terrainObject = Terrain.activeTerrain;
		}
		if (terrainObject) {
			terrain = terrainObject.terrainData;
			var buttonText = "Apply Height";
		}
		else {
			buttonText = "Cancel";
		}
		ScriptableWizard.DisplayWizard("Raise/Lower Heightmap", RaiseHeightmap, buttonText);
	}
 
	function OnWizardUpdate () {
		if (!terrain) {
			helpString = "No terrain found";
			return;
		}
 
		addHeight = Mathf.Clamp(addHeight, -1.0, 1.0);
		helpString = (terrain.size.y*addHeight) + " meters (" + parseInt(addHeight*100.0) + "%)";
	}
 
	function OnWizardCreate () {
		if (!terrain) {
			return;
		}
		Undo.RegisterUndo(terrain, "Raise or Lower Heightmap");
 
		var heights = terrain.GetHeights(0, 0, terrain.heightmapWidth, terrain.heightmapHeight);
		for (var y = 0; y < terrain.heightmapHeight; y++) {
			for (var x = 0; x < terrain.heightmapWidth; x++) {
				heights[y,x] = heights[y,x] + addHeight;
			}
		}
		terrain.SetHeights(0, 0, heights);
		terrain = null;
	}
}