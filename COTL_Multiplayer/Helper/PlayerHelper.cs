using Mirror;
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

        playerPrefab.GetComponent<PlayerController>().gameObject.SetActive(false);
        playerPrefab.GetComponent<PlayerFarming>().gameObject.SetActive(false);
        playerPrefab.GetComponent<Inventory>().gameObject.SetActive(false);
        playerPrefab.GetComponent<PlayerSimpleInventory>().gameObject.SetActive(false);
        playerPrefab.GetComponent<PlayerArrows>().gameObject.SetActive(false);
        playerPrefab.GetComponent<PlayerWeapon>().gameObject.SetActive(false);
        playerPrefab.GetComponent<PlayerSpells>().gameObject.SetActive(false);
        playerPrefab.GetComponent<PlayerStealth>().gameObject.SetActive(false);
        playerPrefab.GetComponent<PlayerAbility>().gameObject.SetActive(false);
        playerPrefab.GetComponent<PlayerRelic>().gameObject.SetActive(false);
        playerPrefab.GetComponent<Interactor>().gameObject.SetActive(false);

        playerPrefab.transform.Find("Canvas").gameObject.SetActive(false);
        playerPrefab.transform.Find("InventoryItemIcon").gameObject.SetActive(false);
        playerPrefab.transform.Find("Weapon Aiming").gameObject.SetActive(false);
        playerPrefab.transform.Find("Curse Aiming").gameObject.SetActive(false);
        playerPrefab.transform.Find("Heavy Aiming").gameObject.SetActive(false);
        playerPrefab.transform.Find("Aiming Target").gameObject.SetActive(false);
        playerPrefab.transform.Find("CharacterBase").Find("Heavy Attack Target").gameObject.SetActive(false);

        var networkIdentity = playerPrefab.AddComponent<NetworkIdentity>();
        var networkTransform = playerPrefab.AddComponent<NetworkTransform>();

        // `set` is internal for some reason lmao
        // networkIdentity.assetId = 1248124;
        
        networkTransform.target = playerPrefab.transform;
        
        return playerPrefab;
    }
}