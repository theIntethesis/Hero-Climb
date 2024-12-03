extends Node

signal inactivity_detected
signal activity_detected

@onready
var inactivity_timer = get_node("InactivityTimer")

var triggered_inactivity: bool = false

# List of actions to monitor - add your specific action names here
var monitored_actions = [
	"move_left",
	"move_right",
	"move_up",
	"move_down",
	"jump",
	"attack"
]

func _ready():
	process_mode = Node.PROCESS_MODE_ALWAYS  # Keep running even when paused

func _process(_delta):
	if !GameHandler.Instance().UseInactivity:
		return
	
	var input_detected = false
	
	# Check for any key, mouse, or joypad input
	if Input.is_anything_pressed():
		input_detected = true
	
	# Check for any monitored actions
	for action in monitored_actions:
		if Input.is_action_pressed(action):
			input_detected = true
			break
	
	# Check for mouse movement
	if Input.get_last_mouse_velocity().length() > 0:
		input_detected = true

	# if !inactivity_timer.is_stopped():
		# print(inactivity_timer.time_left)
	
	if input_detected:
		if triggered_inactivity:
			triggered_inactivity = false
			# emit_signal("activity_detected")
			# print("activity dectected")
			activity_detected.emit()

		# inactivity_timer.start()


func is_triggered_inactivity() -> bool:
	return triggered_inactivity

func _on_inactivity_timer_timeout() -> void:
	if !GameHandler.Instance().UseInactivity:
		return
		
	triggered_inactivity = true
	inactivity_detected.emit()
	inactivity_timer.stop()
	# print("inactivity dectected")