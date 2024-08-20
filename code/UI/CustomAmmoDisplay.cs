
using SWB.HUD;
using SWB.Base;
using SWB.Shared;
using Sandbox.UI;
using Sandbox.UI.Construct;

public class CustomAmmoDisplay : AmmoDisplay
{
	public CustomAmmoDisplay( IPlayerBase player ) : base( player )
    {
        StyleSheet.Load( "/UI/CustomAmmoDisplay.scss" );
    }
}