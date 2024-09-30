extends Node2D


func _process(delta):
	position.y -= 4*delta


func _on_area_2d_body_entered(body):
	if body.has_method("entered_lava"):
		body.entered_lava()
