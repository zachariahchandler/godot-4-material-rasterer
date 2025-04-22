extends Node3D

@export var file_name : String
@export var path : String

func _ready():
  await RenderingServer.frame_post_draw
  var img = get_viewport().get_texture().get_image().save_png(path + file_name)
