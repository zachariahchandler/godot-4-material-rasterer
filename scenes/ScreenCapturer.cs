using Godot;
using System;
using System.Threading.Tasks;

public partial class ScreenCapturer : Node {
  [Export] Vector2[] resolutions;
  
  [Export] string filePath; // the folder to save the image to
  [Export] string fileName; // the name of the file sans extension
  [Export] string extension = ".png";
  
  public override void _Ready () {
    CaptureScreen();
  }
  
  public async Task CaptureScreen () {
    Window window = GetWindow();
    Viewport viewport = GetViewport();
    
    for (int i = 0; i < resolutions.Length; i++) {
      window.Size = (Vector2I)resolutions[i];
      
      await ToSignal(RenderingServer.Singleton, RenderingServerInstance.SignalName.FramePostDraw);
      
      string f = filePath + fileName + "_" + resolutions[i].X + "x" + resolutions[i].Y + extension;
      
      viewport.GetTexture().GetImage().SavePng(f);
      
      GD.Print("saving image: " + f);
    }
    
    CallDeferred(MethodName.Quit);
  }
  
  void Quit () {
    GetTree().Quit ();
  }
}
