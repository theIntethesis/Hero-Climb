// Julia Abdel-Monem

using System.Linq;
using Godot;


// Composite 
/* Superclass */
public partial class MenuComposite : MenuCompositeBase
{

    public MenuComposite() : base()
    {        
        SetAnchorsPreset(LayoutPreset.FullRect); 
    }

    public override Node GetContainer()
    {
        return this;
    }
}

