using UnityEngine;
using Object = UnityEngine.Object;

namespace COTL_Multiplayer.Helper;

public static class PlayerHelper
{
    public static GameObject CreatePlayer()
    {
        // var playerPrefab = Object.Instantiate(LocationManager._Instance.PlayerPrefab);
        var playerPrefab = LocationManager._Instance.PlacePlayer();
        playerPrefab.tag = "Untagged";

        Object.Destroy(playerPrefab.GetComponent<PlayerController>());
        Object.Destroy(playerPrefab.GetComponent<PlayerFarming>());
        Object.Destroy(playerPrefab.GetComponent<Inventory>());
        Object.Destroy(playerPrefab.GetComponent<PlayerSimpleInventory>());
        Object.Destroy(playerPrefab.GetComponent<PlayerArrows>());
        Object.Destroy(playerPrefab.GetComponent<PlayerWeapon>());
        Object.Destroy(playerPrefab.GetComponent<PlayerSpells>());
        Object.Destroy(playerPrefab.GetComponent<PlayerStealth>());
        Object.Destroy(playerPrefab.GetComponent<PlayerAbility>());
        Object.Destroy(playerPrefab.GetComponent<PlayerRelic>());
        Object.Destroy(playerPrefab.GetComponent<Interactor>());

        Object.Destroy(playerPrefab.transform.Find("Canvas").gameObject);
        Object.Destroy(playerPrefab.transform.Find("InventoryItemIcon").gameObject);
        Object.Destroy(playerPrefab.transform.Find("Weapon Aiming").gameObject);
        Object.Destroy(playerPrefab.transform.Find("Curse Aiming").gameObject);
        Object.Destroy(playerPrefab.transform.Find("Heavy Aiming").gameObject);
        Object.Destroy(playerPrefab.transform.Find("Aiming Target").gameObject);
        Object.Destroy(playerPrefab.transform.Find("CharacterBase").Find("Heavy Attack Target").gameObject);

        return playerPrefab;
    }
}