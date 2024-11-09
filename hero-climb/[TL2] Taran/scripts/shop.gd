extends Node2D


func _on_area_2d_area_entered(area: Area2D) -> void:
	print("Shop entered")
	#PlayerGlobal.InShopArea = true


func _on_area_2d_area_exited(area: Area2D) -> void:
	print("Shop exited")
