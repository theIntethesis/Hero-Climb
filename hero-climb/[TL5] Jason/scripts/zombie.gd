extends CharacterBody2D

# Variables to control speed and direction
@export var speed = 100
var direction = Vector2.RIGHT

# Define the boundaries for movement
@export var left_limit = -200
@export var right_limit = 200

func _ready():
	# Set the initial position
	position.x = left_limit
	# Start the run animation
	$AnimatedSprite2D.play("run")

func _process(delta):
	# Move the zombie
	position += direction * speed * delta

	# Check if the zombie has reached the limits
	if position.x >= right_limit:
		direction = Vector2.LEFT
		$AnimatedSprite2D.flip_h = true  # Flip the sprite horizontally
	elif position.x <= left_limit:
		direction = Vector2.RIGHT
		$AnimatedSprite2D.flip_h = false  # Reset the flip
