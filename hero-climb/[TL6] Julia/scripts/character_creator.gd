extends Control

@onready var WizardButton: Button = $VFlowContainer/GridContainer/Wizard
@onready var FigherButton: Button = $VFlowContainer/GridContainer/Fighter
@onready var RogueButton: Button = $VFlowContainer/GridContainer/Rogue


# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass


func _on_rogue_pressed() -> void:
	WizardButton.toggle_mode = false;
	FigherButton.toggle_mode = false;

func _on_wizard_pressed() -> void:
	RogueButton.toggle_mode = false;
	FigherButton.toggle_mode = false;

func _on_figher_pressed() -> void:
	WizardButton.toggle_mode = false;
	RogueButton.toggle_mode = false;
