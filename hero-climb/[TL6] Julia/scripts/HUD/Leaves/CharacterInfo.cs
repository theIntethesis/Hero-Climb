using Godot;

public partial class CharacterInfo : MenuCompositeBase
{
    GridContainer container;

    public CharacterInfo()
    {
        container = new GridContainer();
        
        AddChild(container);
        container.SetAnchorsAndOffsetsPreset(LayoutPreset.TopLeft);

        Push(HUDFactory.HeartGrid());
        Push(HUDFactory.MoneyLabel());
        Push(HUDFactory.ScoreLabel());
    }

    public override Node GetContainer()
    {
        return container;
    }
}
