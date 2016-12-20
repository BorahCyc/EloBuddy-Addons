using System.Drawing;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace BCMaokai
{
    class AddonMenu
    {
        public static Menu CoreMenu;
        public static Menu ComboMenu;
        public static Menu LaneClear;
        public static Menu JungleClear;
        public static Menu DrawMenu;
        public static Menu MiscMenu;

        public static void DesignMenu()
        {
            CoreMenu = MainMenu.AddMenu("BCMaokai", "BCMaokai");
            CoreMenu.AddGroupLabel("Made by Borah Cyc!");
            CoreMenu.AddLabel("Test & Give me your feedback!");

            ComboMenu = CoreMenu.AddSubMenu("Combo");
            {
                ComboMenu.AddGroupLabel("Combo Settings");
                ComboMenu.Add("Qcb", new CheckBox("Use Q"));
                ComboMenu.Add("Wcb", new CheckBox("Use W"));
                ComboMenu.Add("Ecb", new CheckBox("Use E"));
                ComboMenu.Add("Rcb", new CheckBox("Use R"));
                ComboMenu.Add("RcbENM", new Slider("Minium Enemies for R", 0, 1, 5));
            }

            LaneClear = CoreMenu.AddSubMenu("LaneClear");
            {
                LaneClear.AddGroupLabel("LaneClear Settings");
                LaneClear.Add("Qlc", new CheckBox("Use Q"));
                LaneClear.Add("Wlc", new CheckBox("Use W"));
                LaneClear.Add("Elc", new CheckBox("Use E"));
                LaneClear.Add("ManaMNGlc", new Slider("If mana percent below {0}% stop", 45, 0, 100));
            }

            JungleClear = CoreMenu.AddSubMenu("JungleClear");
            {
                JungleClear.AddGroupLabel("LaneClear Settings");
                JungleClear.Add("Qjc", new CheckBox("Use Q"));
                JungleClear.Add("Wjc", new CheckBox("Use W"));
                JungleClear.Add("Ejc", new CheckBox("Use E"));
                JungleClear.Add("ManaMNGjc", new Slider("If mana percent below {0}% stop", 45, 0, 100));
            }

            DrawMenu = CoreMenu.AddSubMenu("Drawings");
            {
                DrawMenu.AddGroupLabel("Draw Settings");
                DrawMenu.Add("draw", new CheckBox("Enable Drawings"));
                DrawMenu.Add("Qdr", new CheckBox("Draw Q"));
                DrawMenu.Add("Wdr", new CheckBox("Draw W"));
                DrawMenu.Add("Edr", new CheckBox("Draw E"));
                DrawMenu.Add("Rdr", new CheckBox("Draw R"));
                DrawMenu.Add("dmg", new CheckBox("Draw Damage Indicator"));
                DrawMenu.Add("Color", new ColorPicker("Damage Indicator Color", Color.FromArgb(255, 255, 236, 0)));
            }

            MiscMenu = CoreMenu.AddSubMenu("Misc");
            {
                MiscMenu.AddGroupLabel("Misc Settings");
                MiscMenu.AddLabel("Anti Gapcloser");
                MiscMenu.Add("Qag", new CheckBox("Use Q to anti GapCloser"));
                MiscMenu.AddLabel("KillSteal Settings");
                MiscMenu.Add("Qks", new CheckBox("Use Q to KS"));
                MiscMenu.Add("Wks", new CheckBox("Use W to KS"));
                MiscMenu.Add("Eks", new CheckBox("Use E to KS"));
                MiscMenu.Add("Rks", new CheckBox("Use R to KS"));
            }         
        }
    }
}
