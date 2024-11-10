# Preamble

The key words "MUST", "MUST NOT", "REQUIRED", "SHALL", "SHALL
NOT", "SHOULD", "SHOULD NOT", "RECOMMENDED",  "MAY", and
"OPTIONAL" in this document are to be interpreted as described in
RFC 2119.

# What
A collection of classes to make creating a navigable menu system in Godot 4.2 or newer.

## MenuElement 
An abstract class defining the behavior and relationship between nodes, and contains methods and properties that exist on both Leaves and Composites. 

## MenuCompositeBase
An abstract class that defines a bunch of virtual methods to define how a composite works. 

## MenuComposite
The simplest realization of MenuCompositeBase.

## MenuStack
A more complex realization of MenuCompositeBase, hiding the previous top of the stack when an element is pushed, and showing the next element when an element is popped.

## MenuLeaf
A base class for anything that is not a composite in the Menu Tree. Each element MAY contain Godot Node elements as its static composition. 

# Why
These menu elements are useful in creating a structured set of menus that are easily navigable. Instead of using scene switching to change the current menu context, push the first context onto a menustack, and then when a user clicks on a button, simply push a child node to the same context.

# How to Use
MenuLeaf, MenuStack, and MenuComposite are ready to be assigned to Control nodes out out of the box. 

## MenuElement 
InitialParent MUST be set if a MenuElement is created as part of a scene. Toggle "Is Background" and "Is Poppable" as needed in the inspector.

## MenuCompositeBase
To create a composite, inherit from this class and define `public override Node GetContainer()`. Many of the array methods from MenuCompositeBase can be overriden, but `GetContainer()` MUST be used to refer to node in which array operations occur on.

If a `MenuElement` has `IsBackground()` set to true, then it can be removed as needed. MenuStack removes backgrounds when they are the head.

If a `MenuElement` has `IsPoppable()` set to false, then it MUST never be removed from the composite, and is removed with the rest of the composite.

Everything in a MenuCompositeBase (`GetContainer().GetChildren()`) MUST be a MenuElement. When an element is added onto a MenuComposite, `MenuElement.OnPush()` SHOULD be called. When an element is removed from a menu composite, `MenuElement.OnPop()` SHOULD be called. 

## MenuStack/MenuComposite
Drag onto a contol node in Godot/Assign a control node this script. Then, ensure that every direct child is a MenuElement by either dragging the `MenuLeaf` or `MenuComposite` script onto it (must also be a control node).

- MenuStack will not hide elements that it starts off with, and will only hide the last element in the list when another element is pushed.

- MenuStack will remove items with `IsBackground() == true` when they become the head.

## MenuLeaf
Drag onto a control node in Godot.

Override `OnPush(MenuCompositeBase)`, `OnPop()`, `OnShow()` and `OnHide()` as needed. `OnPush(MenuCompositeBase)` MUST call `MenuElement.OnPush(MenuCompositeBase)` (`base.OnPush()`) for `MenuElement.Parent()` to be valid.

`OnPop()` MUST NOT contain code that is important as part of a node's cleanup, since a MenuComposite is not required to call it (such as `MenuComposite.SilentRemove()`). It is useful for defining chains of action (when MainMenu is Popped, Push QuitConfirm as an example).

# Requirements

Godot Mono 4.2 and .NET 6.0 or newer