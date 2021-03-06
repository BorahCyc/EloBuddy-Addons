﻿using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using SharpDX;
using System;
using System.Linq;

namespace BCMaokai
{
    class DamageIndicator
    {
        public static float QDMG(Obj_AI_Base target)
        {
            if (Spells.Q.IsReady())
                return Player.Instance.CalculateDamageOnUnit(target, DamageType.Magical, new[] { 0f, 70f, 115f, 160f, 205f, 250f }[Spells.Q.Level] + 0.40f * Player.Instance.TotalMagicalDamage);
            else
                return 0f;
        }
        public static float WDMG(Obj_AI_Base target)
        {
            if (Spells.W.IsReady())
                return Player.Instance.CalculateDamageOnUnit(target, DamageType.Magical, new[] { 0f, 0.09f, 0.1f, 0.11f, 0.12f, 0.13f }[Spells.W.Level] + 0.05f * Player.Instance.TotalMagicalDamage * target.MaxHealth);
            else
                return 0f;
        }
        public static float EDMG(Obj_AI_Base target)
        {
            if (Spells.E.IsReady())
                return Player.Instance.CalculateDamageOnUnit(target, DamageType.Magical, new[] { 0f, 120f, 180f, 240f, 300f, 360f }[Spells.E.Level] + 1f * ObjectManager.Player.TotalMagicalDamage);
            else
                return 0f;
        }
        public static float RDMG(Obj_AI_Base target)
        {
            if (Spells.R.IsReady())
                return Player.Instance.CalculateDamageOnUnit(target, DamageType.Magical, new[] { 0f, 100f, 200f, 300f }[Spells.R.Level] + 0.4f * ObjectManager.Player.TotalMagicalDamage);
            else
                return 0f;
        }
        public static float SpellsDMG(Obj_AI_Base target)
        {
            if (target == null)
            {
                return 0;
            }
            else if (target != null)
            {
                return QDMG(target) + WDMG(target) + EDMG(target) + RDMG(target);
            }
            else return 0f;
        }
        public static void Damage_Indicator(EventArgs args)
        {
            if (AddonMenu.DrawMenu["draw"].Cast<CheckBox>().CurrentValue)
                if (AddonMenu.DrawMenu["dmg"].Cast<CheckBox>().CurrentValue)
                {
                    foreach (var unit in EntityManager.Heroes.Enemies.Where(u => u.IsValidTarget() && u.IsHPBarRendered)
                        )
                    {

                        var damage = SpellsDMG(unit);

                        if (damage <= 0)
                        {
                            continue;
                        }
                        var Special_X = unit.ChampionName == "Jhin" || unit.ChampionName == "Annie" ? -12 : 0;
                        var Special_Y = unit.ChampionName == "Jhin" || unit.ChampionName == "Annie" ? -3 : 9;

                        var DamagePercent = ((unit.TotalShieldHealth() - damage) > 0
                            ? (unit.TotalShieldHealth() - damage)
                            : 0) / (unit.MaxHealth + unit.AllShield + unit.AttackShield + unit.MagicShield);
                        var currentHealthPercent = unit.TotalShieldHealth() / (unit.MaxHealth + unit.AllShield + unit.AttackShield + unit.MagicShield);

                        var StartPoint = new Vector2((int)(unit.HPBarPosition.X + Special_X + DamagePercent * 107) + 1,
                            (int)unit.HPBarPosition.Y + Special_Y);
                        var EndPoint = new Vector2((int)(unit.HPBarPosition.X + Special_X + currentHealthPercent * 107) + 1,
                            (int)unit.HPBarPosition.Y + Special_Y);
                        var Color = AddonMenu.DrawMenu["Color"].Cast<ColorPicker>().CurrentValue;
                        Drawing.DrawLine(StartPoint, EndPoint, 9.82f, Color);
                    }
                }
        }
    }
}