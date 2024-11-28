v1.0.0

# Charactor Creator

| Name | | Description | Special Ability
| --- | --- | --- | --- |
| Fighter | <img style="image-rendering: pixelated; width: 64px" src="Manual_Images/Fighter.gif"> | Strong Melee, Slow Movement, High Health | Dash that can break wooden crates
| Rogue |  | Quick Movement, Average Health | Climbs Pipes |
| Wizard | <img style="image-rendering: pixelated; width: 64px" src="Manual_Images/Wizard.gif"> | Lower than average health, Average movement| Ranged Fireball Attack


# Controls

| Action | Keyboard |  Mobile |
| --- | --- | --- |
| Jump | Space | <img style="image-rendering: pixelated; width: 64px" src="hero-climb/[TL6] Julia/assets/Aseprite_Source/jump_unpressed.png"> |
| Movement | WASD | <img style="image-rendering: pixelated; width: 64px" src="hero-climb/[TL6] Julia/assets/Aseprite_Source/arrow_unpressed.png"> |
| Interact (open a shop) | F | Tap anywhere near the center
| Attack | Left Click | <img style="image-rendering: pixelated; width: 64px" src="/home/julia/projects/Hero-Climb/hero-climb/[TL6] Julia/assets/Aseprite_Source/attack_unpressed.png"> |
| Ability | Right Click | <img style="image-rendering: pixelated; width: 64px" src="/home/julia/projects/Hero-Climb/hero-climb/[TL6] Julia/assets/Aseprite_Source/ability_unpressed.png"> |


# Gameplay

## Objective
Climb as far as you can without dying

## Health
You start off with 5 hearts, equivalent to 100 hp. Each Quarter heart represents 5 hp.

You loose health if you are hit by an enemy, and you can gain health by collecting hearts scattered thoughout the tower or by purchasing an upgrade from the shop.

<img style="image-rendering: pixelated; width: 64px" src="Manual_Images/Heart_Pickup.gif">

## Coins
| Coin | Name | Value |
| --- | --- |--- |
| <img style="image-rendering: pixelated; width: 64px" src="Manual_Images/CopperCoin.gif"> | Copper |  1 |
|<img style="image-rendering: pixelated; width: 64px" src="Manual_Images/SilverCoin.gif"> | Silver |  5 |
| <img style="image-rendering: pixelated; width: 64px" src="Manual_Images/GoldCoin.gif">   | Gold |  10 |

Coins can be spent at the shop

## Shop
Tap or Press F while hovering over the shop to open the menu. From there, you can purchase a max health increase, a full healing, a damage increase, and a speed increase. Each time you buy one the price increases.

|  | Description | 
| --- | --- |
| <img style="image-rendering: pixelated; width: 64px" src="Manual_Images/dmg_increase.png"> | Increase Damage |
| <img style="image-rendering: pixelated; width: 64px" src="Manual_Images/speed_increase.png"> | Increase Movement Speed |
| <img style="image-rendering: pixelated; width: 64px" src="Manual_Images/FullHeart.png">   | Completely Heal Self |
| <img style="image-rendering: pixelated; width: 64px" src="Manual_Images/EmptyHeart.png">   | Increase Max Health |

The price for each buff increases each time you buy it. The prices scale with both the chosen class (see below) and the difficulty level.

## Enemies


| Name | | Description | 
| --- | --- | --- | 
| Goblin | <img style="image-rendering: pixelated; width: 64px" src="Manual_Images/Goblin.gif"> | Moves Quick, Lunge Attack|
| Skeleton | <img style="image-rendering: pixelated; width: 64px" src="Manual_Images/Skeleton.gif"> | Ranged Attack |
| Slime | <img style="image-rendering: pixelated; width: 64px" src="Manual_Images/Slime.gif"> | Slow Movement, Splits on Death|
| Zombie | <img style="image-rendering: pixelated; width: 64px" src="Manual_Images/Zombie.gif"> | Average Melee|


# Credits
- Julia Abdel-Monem (UI/UX)
- Jason Culbertson (Enemies)
- Ferris Hammes-Buehler (Main Character)
- Taran Haug (Level Design)
- Gavin Haynes (Sound Design)

# Open Source License

This game uses Godot Engine, available under the following license:

Copyright (c) 2014-present Godot Engine contributors.
Copyright (c) 2007-2014 Juan Linietsky, Ariel Manzur.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
