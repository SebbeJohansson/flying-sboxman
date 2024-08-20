using Sandbox.Network;
using System.Threading.Tasks;
using SWB.Base;

namespace SWB.Demo;

[Group( "SWB" )]
[Title( "Demo NetworkManager" )]
public class DemoNetworkManager : Component, Component.INetworkListener
{
	[Property] public PrefabScene PlayerPrefab { get; set; }
		private Chat Chat { get; set; }

	protected override Task OnLoad()
	{
		if ( !GameNetworkSystem.IsActive )
		{
			GameNetworkSystem.CreateLobby();
		}

		// Turn off weapon customization
		WeaponSettings.Instance.Customization = false;
		// Turn off inventory display
		WeaponSettings.Instance.InventoryDisplay = false;
		// Turn off inventory display
		WeaponSettings.Instance.Chat = false;

		Chat = Scene.Directory.FindByName( "Screen" )?.First()?.Components.Get<Chat>();
		if ( Chat == null ) Log.Error( "Chat component not found" );

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
