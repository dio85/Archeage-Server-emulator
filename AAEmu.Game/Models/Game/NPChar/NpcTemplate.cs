﻿using System.Collections.Generic;

using AAEmu.Game.Models.Game.AI.v2.Params;
using AAEmu.Game.Models.Game.Items;
using AAEmu.Game.Models.Game.Skills.Static;
using AAEmu.Game.Models.Game.Skills.Templates;
using AAEmu.Game.Models.Game.Units;

namespace AAEmu.Game.Models.Game.NPChar;

public class NpcTemplate
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public bool NpcOnly { get; set; }
    public uint OwnerTypeId { get; set; }
    public int CharRaceId { get; set; }
    public NpcGradeType NpcGradeId { get; set; }
    public NpcKindType NpcKindId { get; set; }
    public byte Level { get; set; }
    public NpcTemplateType NpcTemplateId { get; set; }
    public uint ModelId { get; set; }
    public uint FactionId { get; set; }
    public uint HeirLevel { get; set; }
    public bool SkillTrainer { get; set; }
    public int AiFileId { get; set; }
    public bool Merchant { get; set; }
    public int NpcNicknameId { get; set; }
    public bool Auctioneer { get; set; }
    public bool ShowNameTag { get; set; }
    public bool VisibleToCreatorOnly { get; set; }
    public bool NoExp { get; set; }
    public int PetItemId { get; set; }
    public int BaseSkillId { get; set; }
    public bool TrackFriendship { get; set; }
    public bool Priest { get; set; }
    public int NpcTedencyId { get; set; }
    public bool Blacksmith { get; set; }
    public bool Teleporter { get; set; }
    public float Opacity { get; set; }
    public bool AbilityChanger { get; set; }
    public float Scale { get; set; }
    public float SightRangeScale { get; set; }
    public float SightFovScale { get; set; }
    public int MilestoneId { get; set; }
    public float AttackStartRangeScale { get; set; }
    public bool Aggression { get; set; }
    public float ExpMultiplier { get; set; }
    public int ExpAdder { get; set; }
    public bool Stabler { get; set; }
    public bool AcceptAggroLink { get; set; }
    public int RecrutingBattlefieldId { get; set; }
    public float ReturnDistance { get; set; }
    public int NpcAiParamId { get; set; }
    public bool NonPushableByActor { get; set; }
    public bool Banker { get; set; }
    public int AggroLinkSpecialRuleId { get; set; }
    public float AggroLinkHelpDist { get; set; }
    public bool AggroLinkSightCheck { get; set; }
    public bool Expedition { get; set; }
    public int HonorPoint { get; set; }
    public bool Trader { get; set; }
    public bool AggroLinkSpecialGuard { get; set; }
    public bool AggroLinkSpecialIgnoreNpcAttacker { get; set; }
    public float AbsoluteReturnDistance { get; set; }
    public bool Repairman { get; set; }
    public bool ActivateAiAlways { get; set; }
    public bool Specialty { get; set; }
    public uint SpecialtyCoinId { get; set; }
    public bool UseRangeMod { get; set; }
    public int NpcPostureSetId { get; set; }
    public int MateEquipSlotPackId { get; set; }
    public int MateKindId { get; set; }
    public uint EngageCombatGiveQuestId { get; set; }
    public bool NoApplyTotalCustom { get; set; }
    public bool BaseSkillStrafe { get; set; }
    public float BaseSkillDelay { get; set; }
    public int NpcInteractionSetId { get; set; }
    public bool UseAbuserList { get; set; }
    public bool ReturnWhenEnterHousingArea { get; set; }
    public bool LookConverter { get; set; }
    public bool UseDDCMSMountSkill { get; set; }
    public bool CrowdEffect { get; set; }
    public uint AnimActionId { get; set; }
    public byte Race { get; set; }
    public byte Gender { get; set; }
    public uint MerchantPackId { get; set; }

    public uint HairId { get; set; }
    public uint HornId { get; set; }
    public UnitCustomModelParams ModelParams { get; set; }
    public EquipItemsTemplate Items { get; set; }
    public (uint ItemId, bool NpcOnly)[] BodyItems { get; set; }
    public List<uint> Buffs { get; set; }
    public List<BonusTemplate> Bonuses { get; set; }
    public AiParams AiParams { get; set; }
    public Dictionary<SkillUseConditionKind, List<NpcSkill>> Skills { get; set; }
    public List<NpcPassiveBuff> PassiveBuffs { get; set; }
    public uint TotalCustomId { get; set; }

    public NpcTemplate()
    {
        HairId = 0;
        HornId = 0;
        Items = new EquipItemsTemplate();
        ModelParams = new UnitCustomModelParams();
        BodyItems = new (uint, bool)[7];
        Buffs = new List<uint>();
        Bonuses = new List<BonusTemplate>();
        Skills = new Dictionary<SkillUseConditionKind, List<NpcSkill>>();
        PassiveBuffs = new List<NpcPassiveBuff>();
    }

    public void BindSkills(List<NpcSkill> skills)
    {
        foreach (var skill in skills)
        {
            if (!Skills.ContainsKey(skill.SkillUseCondition))
                Skills.Add(skill.SkillUseCondition, new List<NpcSkill>());

            Skills[skill.SkillUseCondition].Add(skill);
        }
    }
}
