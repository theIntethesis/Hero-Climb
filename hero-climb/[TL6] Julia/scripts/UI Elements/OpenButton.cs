using Godot;
using System;
using System.Text.RegularExpressions;

public partial class OpenButton : Button
{
    public enum MenuNodeEnum {
        CharacterCreator = 0, 
        DeathScreen = 1,
        MainMenu = 2,
        PauseMenu = 3,
        QuitConfirm = 4,
        SettingsMenu = 5,
        WinScreen = 6, 
    }
    

	[Export]
	private MenuNodeEnum key;

    public override void _Ready()
    {
		Pressed += () => {
			switch (key)
			{
				case MenuNodeEnum.CharacterCreator:
					MenuWrapper.Instance().Push(new CharacterCreator());
					break;
				case MenuNodeEnum.DeathScreen:
					MenuWrapper.Instance().Push(new DeathScreen());
					break;
				case MenuNodeEnum.MainMenu:
					MenuWrapper.Instance().Push(new MainMenu());
					break;
				case MenuNodeEnum.PauseMenu:
					MenuWrapper.Instance().Push(new PauseMenu());
					break;
				case MenuNodeEnum.QuitConfirm:
					MenuWrapper.Instance().Push(new QuitConfirm());
					break;
				case MenuNodeEnum.SettingsMenu:
					MenuWrapper.Instance().Push(new SettingsMenu());
					break;
				case MenuNodeEnum.WinScreen:
					MenuWrapper.Instance().Push(new WinScreen());
					break;
			}
		};
    }
}
