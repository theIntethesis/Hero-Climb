extends Node2D

@export var Speed = 2.0

func _process(delta):
	position.y -= Speed * delta
	Speed += .001


func _on_area_2d_body_entered(body):
	if body.has_method("entered_lava"):
		body.entered_lava()
