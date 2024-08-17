using SWB.Base;
using SWB.Base.Attachments;

namespace SWB.Demo;

/*
 * Almost all attachment properties can be edited from the scene inspector.
 * For ease of reusability I opted to initialize most properties by code but you don't have to
 */

[Title( "Hunter Scope" )]
public class HunterScope2DBG : Scope2DAttachment
{
	public override string Name => "Hunter Scope x12";
	public override string IconPath => "attachments/swb/sight/scope_hunter/ui/icon.png";
	public override string BodyGroup { get; set; } = "sight";
	public override int BodyGroupChoice { get; set; } = 2;
	public override int BodyGroupDefault { get; set; } = 0;

	// Scope
	public override ScopeInfo ScopeInfo { get; set; } = new()
	{
		LensTexture = "materials/swb/scopes/swb_lens_hunter.png",
		ScopeTexture = "materials/swb/scopes/swb_scope_hunter.png",
		ScopeInDelay = 0.2f,
		ScopeInSound = ResourceLibrary.Get<SoundEvent>( "sounds/swb/scope/swb_sniper.zoom_in.sound" ),
		FOV = 8f,
		AimSensitivity = 0.25f
	};
}

[Title( "Silencer (sniper)" )]
public class SniperSilencerBG : SilencerAttachment
{
	public override string Name => "ATS5 Silencer";
	public override string IconPath => "attachments/swb/muzzle/silencer_sniper/ui/icon.png";
	public override string BodyGroup { get; set; } = "muzzle";
	public override int BodyGroupChoice { get; set; } = 1;
	public override int BodyGroupDefault { get; set; } = 0;

	// Silencer
	public override ParticleSystem MuzzleFlashParticle { get; set; } = ParticleSystem.Load( "particles/swb/muzzle/flash_silenced.vpcf" );
	[Property, Group( "Silencer" )] public override SoundEvent ShootSound { get; set; } = ResourceLibrary.Get<SoundEvent>( "sounds/swb/attachments/silencer/swb_sniper.silenced.fire.sound" );
}

[Title( "Rail (sniper)" )]
public class SniperRailBG : RailAttachment
{
	public override string Name => "UTG Quad-Rail";
	public override string IconPath => "attachments/swb/rail/rail_quad/ui/icon.png";
	public override string BodyGroup { get; set; } = "rail";
	public override int BodyGroupChoice { get; set; } = 1;
	public override int BodyGroupDefault { get; set; } = 0;
}

