
using SWB.HUD;

public class CustomRootDisplay : RootDisplay
{
	Killfeed killfeed;
	Hitmarker hitmarker;
	protected override void OnStart()
	{
        Log.Info( "CustomRootDisplay.OnStart" );
		if ( IsProxy )
		{
			this.GameObject.Destroy();
			return;
		}

		Panel.StyleSheet.Load( "/swb_hud/RootDisplay.cs.scss" );
		Panel.AddChild( new CustomHealthDisplay( Player ) );
		Panel.AddChild( new CustomAmmoDisplay( Player ) );
		Panel.AddChild( new Scoreboard() );

		killfeed = new Killfeed( Player );
		Panel.AddChild( killfeed );

		hitmarker = new Hitmarker();
		Panel.AddChild( hitmarker );
	}
} 