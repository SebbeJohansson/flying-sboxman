
using SWB.HUD;

public class CustomRootDisplay : RootDisplay
{
	// public CustomAmmoDisplay( IPlayerBase player ) : base( player )
    // {
    //     StyleSheet.Load( "/UI/CustomAmmoDisplay.scss" );
    // }
	Killfeed killfeed;
	Hitmarker hitmarker;
	protected override void OnStart()
	{
		// base.OnStart();
        Log.Info( "CustomRootDisplay.OnStart" );
		if ( IsProxy )
		{
			this.GameObject.Destroy();
			return;
		}

		Panel.StyleSheet.Load( "/swb_hud/RootDisplay.cs.scss" );
		Panel.AddChild( new HealthDisplay( Player ) );
		Panel.AddChild( new CustomAmmoDisplay( Player ) );
		Panel.AddChild( new Scoreboard() );

		killfeed = new Killfeed( Player );
		Panel.AddChild( killfeed );

		hitmarker = new Hitmarker();
		Panel.AddChild( hitmarker );
		Panel.StyleSheet.Load( "/UI/Styles/ReplacementStyling.scss" );
	}
} 