extends Control

@onready var WizardButton: Button = $VFlowContainer/GridContainer/WizardButton
@onready var FighterButton: Button = $VFlowContainer/GridContainer/FighterButton
@onready var RogueButton: Button = $VFlowContainer/GridContainer/RogueButton

@onready var WizardSprite: AnimatedSprite2D = $VFlowContainer/Control/Control/Wizard
@onready var FighterSprite: AnimatedSprite2D = $VFlowContainer/Control/Control/Fighter
@onready var RogueSprite: AnimatedSprite2D = $VFlowContainer/Control/Control/Rogue


# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	WizardSprite.visible = false;
	FighterSprite.visible = false;
	RogueSprite.visible = false;



func _on_rogue_pressed() -> void:
	WizardButton.toggle_mode = false;
	FighterButton.toggle_mode = false;
	WizardSprite.visible = false;
	FighterSprite.visible = false;
	RogueSprite.visible = true;

func _on_wizard_pressed() -> void:
	RogueButton.toggle_mode = false;
	FighterButton.toggle_mode = false;
	RogueSprite.visible = false;
	FighterSprite.visible = false;
	WizardSprite.visible = true;

func _on_figher_pressed() -> void:
	WizardButton.toggle_mode = false;
	RogueButton.toggle_mode = false;
	RogueSprite.visible = false;
	WizardSprite.visible = false;
	FighterSprite.visible = true;
