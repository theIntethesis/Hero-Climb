# Gantt Chart
- Overall we're behind on creating tests, but ahead on game implementation
- We're in the stage where everything needs to be tied in to each other's code, which requires more collaboration. We're moving a bit slower than we did when we were individually implementing everything.
- We're also behind on asset creation, focusing more on gettings things functional rather than making it look super pretty right now.

## Ferris

### Completed
- More work on abilities (Facade Implementation)
- Helped with Level Design
- Testing Plan

### Still to Come
- More level creation work
- Implementing Tests
- Sprite Design (Art)

## Taran

### Completed
- Level Piece Design Work
- Collectables
- Level Generation

### Still to Come
- Implementing Tests
- Level Piece Design

## Gavin

### Completed
- Rewrote classes in C#
- SoundController Superclass and Subclasses

### Still to Come
- Advise team on how to implement in our features

## Jason

### Completed
- New Enemies
- Integrate AI with level design elements
- Unique Ability work


### Still to Come
- AI interactions
- Testing Plan
- Optimization

## Julia (hi!)

### Completed
- Complete refactor/rewrite of code base (new gantt chart)
- Player HUD (health and money)
- Shop HUD design and integration
- HUD assets
- Credits Menu
- User Manual

### Still to Come
- Create Prefab (document something written)
- Create and Implement Test Plan
- Menu Assets
- Finish up the User Manual
- Settings Menu and Handler


# Prework Checklist
- Overall, We're all missing:
    - a documented prefab
    - a finished test plan (most of us have some tests written, I (julia) don't have any due to said refactor)

- Dynamic Bindings:
    - Almost everyone is missing the static type setting `Superclass object = new Subclass()` since we're relying on Godot's backend to handle the type conversion from a scene.
    - I've advised everyone to find some way to implement a private data class pattern to quickly meet this need

- Prefab:
    - Most of us are missing documentation, and thats all.


# Demo
- Has Haptic Feedback and Working Controls
- Handful of bugs with input handling
