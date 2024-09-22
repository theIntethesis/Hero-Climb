extends Control

@onready var WizardButton: Button = $VFlowContainer/GridContainer/Wizard
@onready var FigherButton: Button = $VFlowContainer/GridContainer/Fighter
@onready var RogueButton: Button = $VFlowContainer/GridContainer/Rogue


func _on_rogue_pressed() -> void:
	WizardButton.toggle_mode = false;
	FigherButton.toggle_mode = false;

func _on_wizard_pressed() -> void:
	RogueButton.toggle_mode = false;
	FigherButton.toggle_mode = false;

func _on_figher_pressed() -> void:
	WizardButton.toggle_mode = false;
	RogueButton.toggle_mode = false;
