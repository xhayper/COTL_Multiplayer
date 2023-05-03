using Spine;
using Spine.Unity;
using UnityEngine;

namespace COTL_Multiplayer.Wrapper;

public class PlayerPrefabWrapper
{
    public int BlackHearts;
    public int BlueHearts;

    public PlayerFleeceManager.FleeceType CurrentFleece = PlayerFleeceManager.FleeceType.Default;

    public EquipmentType CurrentWeapon = EquipmentType.None;

    public int HP = 3;

    public GameObject PlayerPrefab;
    public Skin PlayerSkin = new("Player Skin");
    public SkeletonAnimation Spine;
    public int SpiritHearts;

    public int TOTAL_HEALTH = 2;

    public PlayerPrefabWrapper(GameObject playerPrefab)
    {
        PlayerPrefab = playerPrefab;
        Spine = playerPrefab.transform.Find("Spine").GetComponent<SkeletonAnimation>();

        UpdateSkin();
    }

    public void SetFleece(PlayerFleeceManager.FleeceType fleece)
    {
        CurrentFleece = fleece;
        UpdateSkin();
    }

    public void SetWeapon(EquipmentType weapon)
    {
        CurrentWeapon = weapon;
        UpdateSkin();
    }

    public void SetTotalHealth(int totalHealth)
    {
        TOTAL_HEALTH = totalHealth;
        UpdateSkin();
    }

    public void SetHealth(int? hp, int? blackHearts, int? blueHearts, int? spiritHearts)
    {
        if (hp != null)
            HP = hp.Value;
        if (blackHearts != null)
            BlackHearts = blackHearts.Value;
        if (blueHearts != null)
            BlueHearts = blueHearts.Value;
        if (spiritHearts != null)
            SpiritHearts = spiritHearts.Value;

        UpdateSkin();
    }

    public void UpdateSkin(bool blackAndWhite = false)
    {
        PlayerSkin = new Skin("Player Skin");

        PlayerSkin.AddSkin(Spine.Skeleton.Data.FindSkin($"Lamb_{(int)CurrentFleece}" +
                                                        (CurrentFleece != PlayerFleeceManager.FleeceType.Default &&
                                                         blackAndWhite
                                                            ? "_BW"
                                                            : "")));

        var str = WeaponData.Skins.Normal.ToString();

        if (CurrentWeapon != EquipmentType.None)
            str = EquipmentManager.GetWeaponData(CurrentWeapon).Skin.ToString();

        PlayerSkin.AddSkin(Spine.Skeleton.Data.FindSkin($"Weapons/{str}"));

        if (HP + BlackHearts + BlueHearts + SpiritHearts <= 1 && TOTAL_HEALTH != 2)
            PlayerSkin.AddSkin(Spine.Skeleton.Data.FindSkin("Hurt2"));
        else if ((HP + BlackHearts + BlueHearts + SpiritHearts <= 2 && TOTAL_HEALTH != 2) ||
                 (HP + BlackHearts + BlueHearts + SpiritHearts <= 1 && TOTAL_HEALTH == 2))
            PlayerSkin.AddSkin(Spine.Skeleton.Data.FindSkin("Hurt1"));

        Spine.Skeleton.SetSkin(PlayerSkin);
        Spine.Skeleton.SetSlotsToSetupPose();
    }
}