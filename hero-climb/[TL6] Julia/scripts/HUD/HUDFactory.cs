using System;
using System.Collections.Generic;
using Godot;

public static class HUDFactory
{
    enum ElementName
    {
        MoneyLabel,
        Heart,
        GameShop
    }

    static Dictionary<ElementName, PackedScene> MenuScenes = new Dictionary<ElementName, PackedScene>
    {
        {ElementName.MoneyLabel, ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/HUD/Leaves/MoneyLabel.tscn")},
        {ElementName.Heart, ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/HUD/Leaves/Heart.tscn")},
        {ElementName.GameShop, ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/HUD/Composites/Shop.tscn")},
    };

    public static MoneyLabel MoneyLabel()
    {
        return (MoneyLabel)MenuScenes[ElementName.MoneyLabel].Instantiate();
    }

    public static HeartGrid HeartGrid()
    {
        return new HeartGrid();
    }  

    public static PlayerCameraStack PlayerCameraStack(PlayerCamera parent)
    {
        return new PlayerCameraStack(parent);
    }  

    public static CharacterHUD CharacterHUD(int maxhealth)
    {
        return new CharacterHUD(maxhealth);
    }

    public static Heart Heart()
    {
        return (Heart)MenuScenes[ElementName.Heart].Instantiate();
    }

    public static GameShop GameShop()
    {
        return (GameShop)MenuScenes[ElementName.GameShop].Instantiate();
    }
}