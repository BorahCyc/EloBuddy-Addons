using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace Amumu
{
    class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (!Player.Instance.Hero.Equals(Champion.Amumu)) return;
            try
            {
                Game.OnTick += OnTick;
                //Drawing.OnDraw += OnDraw;
                AddonMenu.DesignMenu();
                Spells.LoadSpells();
                Chat.Print("Amumu Loaded!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void OnTick(EventArgs args)
        {
            if (Player.Instance.IsDead) return;

            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
            { Mode.ComboExecute(); } 
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            { Mode.LaneClearExecute(); } 
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
            { Mode.JungleClearExecute(); }
            //if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee))
            //{ Mode.FleeExecute(); }
        }

        private static void OnDraw(EventArgs args)
        {
            if (AddonMenu.DrawMenu["enadr"].Cast<CheckBox>().CurrentValue)
            {
                if (AddonMenu.DrawMenu["Qdr"].Cast<CheckBox>().CurrentValue)
                {
                    Circle.Draw(Spells.Q.IsLearned ? Color.HotPink : Color.Zero, Spells.Q.Range, Player.Instance.Position);
                }
                if (AddonMenu.DrawMenu["Wdr"].Cast<CheckBox>().CurrentValue)
                {
                    Circle.Draw(Spells.W.IsLearned ? Color.Cyan : Color.Zero, Spells.W.Range, Player.Instance.Position);
                }
                if (AddonMenu.DrawMenu["Edr"].Cast<CheckBox>().CurrentValue)
                {
                    Circle.Draw(Spells.W.IsLearned ? Color.Cyan : Color.Zero, Spells.E.Range, Player.Instance.Position);
                }
                if (AddonMenu.DrawMenu["Rdr"].Cast<CheckBox>().CurrentValue)
                {
                    Circle.Draw(Spells.R.IsLearned ? Color.Yellow : Color.Zero, Spells.R.Range, Player.Instance.Position);
                }
            }
        }
    }
}
