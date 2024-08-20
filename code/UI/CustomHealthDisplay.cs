
using SWB.HUD;
using SWB.Base;
using SWB.Shared;
using Sandbox.UI;
using Sandbox.UI.Construct;

public class CustomHealthDisplay : HealthDisplay
{
	public CustomHealthDisplay( IPlayerBase player ) : base( player )
    {
        StyleSheet.Load( "/UI/CustomHealthDisplay.scss" );
    }
}