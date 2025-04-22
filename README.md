# godot-4-material-rasterer

renders godot materials (or, anything you like really) at a series of arbitrary resolutions and saves the results as PNGs.

***

## what's this for?

i like modelling with programs like [trenchbroom](https://trenchbroom.github.io/), and i appreciate simple texturework over complicated shaders. i also really like [ambientcg](https://ambientcg.com/)'s textures, but they're not always suited to this purpose because they're split up into their component pieces (normals, height, roughness, occlusion, etc.), so i wanted a way to use those resources in my low-fidelity workflow.

also i couldn't be bothered setting this up in blender.

***

## how to use:

you will need:
- godot 4.X .NET[^1] (tested in 4.4.1)
- some textures for a PBR shader (i recommend [ambientcg](https://ambientcg.com/) for this)
- that's it!

in the base scene you will find a camera pointed at a quad with an example material applied.

before hitting `Play` you will need to: 
- set the exported `Resolutions`, `File Path`, `File Name`, and `Extension`[^2] parameters in the `ScreenCapturer` script, which is attached to the node of the same name.
- modify the material applied to the quad: supply it with textures for albedo, smoothness/roughness, metallic, occlusion, normal and whatever else you feel like.
- adjust the lighting to your liking (by default it's trying to be fairly neutral).

once that's done, simply hit `Play` and the program will save renders at all specified resolutions[^3] and automatically quit.

[^1]: there *is* a gd script in this project which will save a render just like the c# version however it's not as fully featured at the moment. happy to improve the gd script if requested.

[^2]: the `Extension` param *doesn't* change the format of the file, it's simply appended to the file's name when saved. happy to expand functionality if requested.

[^3]: note that the default resolution specified in the project settings is ignored.


