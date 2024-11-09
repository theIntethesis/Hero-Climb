
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
        SettingsMenu
    }

    static Dictionary<ElementName, PackedScene> MenuScenes = new Dictionary<ElementName, PackedScene>
    {
        {ElementName.CharacterCreator, ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/CharacterCreator.tscn")},
        {ElementName.CreditsMenu, ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/CreditsMenu.tscn")},
        {ElementName.DeathScreen, ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/DeathScreen.tscn")},
        {ElementName.MainMenu, ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/MainMenu.tscn")},
        {ElementName.PauseMenu, ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/PauseMenu.tscn")},
        {ElementName.QuitConfirm, ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/QuitConfirm.tscn")},
        {ElementName.SettingsMenu, ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/SettingsMenu.tscn")}
    };


    public static MenuElement CharacterCreator()
    {
        return (CharacterCreator)MenuScenes[ElementName.CharacterCreator].Instantiate();
    }
    public static MenuElement CreditsMenu()
    {
        return (CreditsMenu)MenuScenes[ElementName.CreditsMenu].Instantiate();
    }
    public static MenuComposite DeathScreen()
    {
        return (MenuStack)MenuScenes[ElementName.DeathScreen].Instantiate();
    }
    public static MenuComposite MainMenu()
    {
        return (MenuStack)MenuScenes[ElementName.MainMenu].Instantiate();
    }
    public static MenuElement PauseMenu()
    {
        return (MenuStack)MenuScenes[ElementName.PauseMenu].Instantiate();
    }
    public static MenuElement QuitConfirm()
    {
        return (QuitConfirm)MenuScenes[ElementName.QuitConfirm].Instantiate();
    }
    public static MenuElement SettingsMenu()
    {
        return (SettingsMenu)MenuScenes[ElementName.SettingsMenu].Instantiate();
    }
}