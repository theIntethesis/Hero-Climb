extends Marker2D


func _on_area_2d_area_entered(area: Area2D) -> void:
	print('deleting floor')
	get_parent().queue_free()
