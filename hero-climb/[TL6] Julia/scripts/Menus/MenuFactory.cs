
using System;
using System.Collections.Generic;
using Godot;

public static class MenuFactory
{
    public enum ElementName
    {
        CharacterCreator,
        CreditsMenu,
        DeathScreen,
        MainMenu,
        PauseMenu,
        QuitConfirm,
        SettingsMenu,
        LicenseMenu
    }

    static Dictionary<ElementName, PackedScene> MenuScenes = new Dictionary<ElementName, PackedScene>
    {
        {ElementName.CharacterCreator, ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/Leaves/CharacterCreator.tscn")},
        {ElementName.CreditsMenu, ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/Leaves/CreditsMenu.tscn")},
        {ElementName.DeathScreen, ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/Composites/DeathScreen.tscn")},
        {ElementName.MainMenu, ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/Composites/MainMenu.tscn")},
        {ElementName.PauseMenu, ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/Composites/PauseMenu.tscn")},
        {ElementName.QuitConfirm, ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/Leaves/QuitConfirm.tscn")},
        {ElementName.SettingsMenu, ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/Leaves/SettingsMenu.tscn")},
        {ElementName.LicenseMenu, ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/Leaves/LicenseMenu.tscn")}
    };

    public static MenuLeaf CharacterCreator()
    {
        return (CharacterCreator)MenuScenes[ElementName.CharacterCreator].Instantiate();
    }
    public static MenuLeaf CreditsMenu()
    {
        return (CreditsMenu)MenuScenes[ElementName.CreditsMenu].Instantiate();
    }
    public static MenuCompositeBase DeathScreen()
    {
        return (MenuStack)MenuScenes[ElementName.DeathScreen].Instantiate();
    }
    public static MenuCompositeBase MainMenu()
    {
        return (MenuStack)MenuScenes[ElementName.MainMenu].Instantiate();
    }
    public static MenuCompositeBase PauseMenu()
    {
        return (MenuStack)MenuScenes[ElementName.PauseMenu].Instantiate();
    }
    public static MenuLeaf QuitConfirm()
    {
        return (QuitConfirm)MenuScenes[ElementName.QuitConfirm].Instantiate();
    }
    public static MenuLeaf SettingsMenu()
    {
        return (SettingsMenu)MenuScenes[ElementName.SettingsMenu].Instantiate();
    }

    public static MenuLeaf LicenseMenu()
    {
        return (LicenseMenu)MenuScenes[ElementName.LicenseMenu].Instantiate();
    }
}