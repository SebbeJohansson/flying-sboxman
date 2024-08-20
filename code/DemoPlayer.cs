using SWB.Base;
using SWB.HUD;
using SWB.Player;
using System.Linq;

namespace SWB.Demo;

[Group( "SWB" )]
[Title( "Demo Player" )]
public class DemoPlayer : PlayerBase
{
	void GiveWeapon( string className, bool setActive = false )
	{
		var weaponGO = WeaponRegistry.Instance.Get( className );
		var weapon = weaponGO.Components.Get<Weapon>( true );
		Inventory.AddClone( weaponGO, setActive );
		SetAmmo( weapon.Primary.AmmoType, 360 );
	}

	Weapon GetWeapon( string className )
	{
		var weaponGO = Inventory.Items.First( x => x.Name == className );
		if ( weaponGO is not null )
			return weaponGO.Components.Get<Weapon>();

		return null;
	}

	public override void Respawn()
	{
		base.Respawn();

		if ( IsBot ) return;

		// Give weapon
		GiveWeapon( "swb_l96a1", true );
		// GiveWeapon( "knife" ); // Melee weapons doenst work in swb yet.

		Weapon weapon = GetWeapon( "swb_l96a1" );
		weapon.Attachments.ForEach( attachment =>
		{
			if ( attachment.Hide ) return;
			attachment.EquipBroadCast();
		} );
	}

	public override void OnDeath( Shared.DamageInfo info )
	{
		base.OnDeath( info );

		var localPly = PlayerBase.GetLocal();
		var display = localPly.RootDisplay as RootDisplay;
		display.AddToKillFeed( info.AttackerId, GameObject.Id, info.Inflictor );
	}

	public override void TakeDamage( Shared.DamageInfo info )
	{
		base.TakeDamage( info );

		// Attacker only
		var localPly = PlayerBase.GetLocal();
		if ( !localPly.IsAlive || localPly.GameObject.Id != info.AttackerId ) return;

		var display = localPly.RootDisplay as RootDisplay;
		display.CreateHitmarker( Health <= 0 );
		Sound.Play( "hitmarker" );
	}
}
