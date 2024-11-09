extends Node2D

@export var Speed = 3.0

func _process(delta):
	position.y -= Speed * delta


func _on_area_2d_body_entered(body):
	if body.has_method("entered_lava"):
		body.entered_lava()
