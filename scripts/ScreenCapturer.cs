using Godot;
using System;
using System.Threading.Tasks;

public partial class ScreenCapturer : Node {
  [Export] bool enabled = true;
  
  [Export] string filePath; // the folder to save the image to
  [Export] string suffix = ".png";
  
  [Export] MeshInstance3D meshInstance;
  
  [Export] Material[] materials;
  
  [Export] Vector2[] resolutions;
  
  public override void _Ready () {
    if (!enabled) {return;}
    CaptureScreen();
  }
  
  public async Task CaptureScreen () {   
    Window window = GetWindow();
    window.MinSize = new Vector2I(1,1); //this is to allow for really small renders, otherwise the default minimum is 64x64
    Viewport viewport = GetViewport();
    
    for (int i = 0; i < materials.Length; i++) {
      meshInstance.MaterialOverlay = materials[i];
      
      for (int j = 0; j < resolutions.Length; j++) {
        meshInstance.Show();
        
        window.Size = (Vector2I)resolutions[j];
        
        await ToSignal(RenderingServer.Singleton, RenderingServerInstance.SignalName.FramePostDraw);
        
        string f = filePath + materials[i].ResourceName + "_" + resolutions[j].X + "x" + resolutions[j].Y + suffix;
        
        viewport.GetTexture().GetImage().SavePng(f);
        
        GD.Print("saving image: " + f);
        
        meshInstance.Hide();
        
        await ToSignal(RenderingServer.Singleton, RenderingServerInstance.SignalName.FramePostDraw);
      }
    }
    
    CallDeferred(MethodName.Quit);
  }
  
  void Quit () {
    GetTree().Quit ();
  }
}
