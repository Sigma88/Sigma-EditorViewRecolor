# Sigma EditorView Recolor


**Allows to recolor the outside view of the editor scenes**


KSP Forum Thread: http://forum.kerbalspaceprogram.com/index.php?/topic/163184-0/

Download Latest Release: https://github.com/Sigma88/Sigma-EditorViewRecolor/releases/latest

Dev version: https://github.com/Sigma88/Sigma-EditorViewRecolor/tree/Development


# Settings

```
SigmaEditorViewRecolor
{
}
```
This is the settings node, it is provided by the mod and should be edited using
[ModuleManager](http://forum.kerbalspaceprogram.com/index.php?/topic/50533-0/) patches.

The SigmaEditorViewRecolor settings node can contain the following settings:

  - **EditorSkyBox**, *\<string\>*, Path to a folder containing the new textures for the editor skybox.
    
    <pre>
    If set to '<i>GalaxyTex</i>' the galaxy skybox will be used.
    
    If used to define a path of a folder, it must end in '/'.
    
    Files must be named '<i>Sunny3_up</i>', '<i>Sunny3_down</i>', '<i>Sunny3_left</i>', '<i>Sunny3_right</i>', '<i>Sunny3_front</i>', '<i>Sunny3_back</i>'.
    </pre>
    
  - **EditorGroundTex**, *\<string\>*, Name of the texture to be used for the ground visible outside.
		
    ```
    Can be used to load both custom or stock textures.
    ```
    
  - **EditorGroundColor**, *\<Color\>*, Color of the texture used for the ground visible outside.
		
    ```
    Must be a unity color. (e.g. white = 1,1,1,1)
    ```
    
  - **FogEnabled**, *\<bool\>*, Enable/Disable the fog.
		
    ```
    The fog effect can be seen near the horizon where the ground is slightly tinted.
    ```
    
  - **FogColor**, *\<Color\>*, The color of the fog.
		
    ```
    Must be a unity color. (e.g. white = 1,1,1,1)
    ```
    
  - **KSCGroundTex**, *\<string\>*, Name of the texture to be used for the KSC ground.
		
    ```
    Only available when Kopernicus is not installed.
    
    Can be used to load both custom or stock textures.
    ```
    
  - **KSCGroundColor**, *\<Color\>*, Color of the texture used for the KSC ground.
		
    ```
    Only available when Kopernicus is not installed.
    
    Must be a unity color. (e.g. white = 1,1,1,1)
    ```
