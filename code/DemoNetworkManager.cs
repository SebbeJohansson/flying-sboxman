using Sandbox.Network;
using System.Threading.Tasks;
using SWB.Base;

namespace SWB.Demo;

[Group( "SWB" )]
[Title( "Demo NetworkManager" )]
public class DemoNetworkManager : Component, Component.INetworkListener
{
	[Property] public PrefabScene PlayerPrefab { get; set; }

	protected override Task OnLoad()
	{
		if ( !GameNetworkSystem.IsActive )
		{
			GameNetworkSystem.CreateLobby();
		}

		// Turn off weapon customization
		WeaponSettings.Instance.Customization = false;

		return base.OnLoad();
	}

	// Called on host
	void INetworkListener.OnActive( Connection connection )
	{
		var playerGO = PlayerPrefab.Clone();
		playerGO.Name = "Player";
		playerGO.NetworkSpawn( connection );
	}
}
