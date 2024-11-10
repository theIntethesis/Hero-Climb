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
        MoneyLabel label = (MoneyLabel)MenuScenes[ElementName.MoneyLabel].Instantiate();

        return label;
    }

    public static HeartGrid HeartGrid()
    {
        HeartGrid grid = new HeartGrid();
        grid.Name = "HeartGrid";

        return grid;
    }  

    public static PlayerCameraStack PlayerCameraStack(PlayerCamera parent)
    {
        PlayerCameraStack stack = new PlayerCameraStack(parent);
        stack.Name = "PlayerCameraStack";
        return stack;
    }  

    public static CharacterHUD CharacterHUD(int maxhealth, int initialMoney)
    {
        CharacterHUD hud = new CharacterHUD(maxhealth, initialMoney);
        hud.Name = "CharacterHUD";

        return hud;
    }

    public static Heart Heart()
    {
        Heart heart = (Heart)MenuScenes[ElementName.Heart].Instantiate();

        return heart;
    }

    public static GameShop GameShop()
    {
        GameShop shop = (GameShop)MenuScenes[ElementName.GameShop].Instantiate();
        shop.Name = "GameShop";
        return shop;
    }

    public static CharacterInfo CharacterInfo()
    {
        CharacterInfo info = new CharacterInfo();
        info.Scale = new Vector2(3.0f, 3.0f);
        info.Name = "CharacterInfo";
        return info;
    }

}