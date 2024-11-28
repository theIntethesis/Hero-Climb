extends Node

signal inactivity_detected
signal activity_detected

var inactivity_timer: float = 0.0
const INACTIVITY_THRESHOLD: float = 500.0  # Seconds before demo mode
var demo_mode_active: bool = false

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

func _process(delta):
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
	
	if input_detected:
		if demo_mode_active:
			demo_mode_active = false
			emit_signal("activity_detected")
		inactivity_timer = 0.0
	else:
		inactivity_timer += delta
		
		if inactivity_timer >= INACTIVITY_THRESHOLD and !demo_mode_active:
			demo_mode_active = true
			emit_signal("inactivity_detected")

func is_demo_mode_active() -> bool:
	return demo_mode_active

func reset_timer():
	inactivity_timer = 0.0
	demo_mode_active = false
