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
        public static Menu DrawMenu;

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

            DrawMenu = CoreMenu.AddSubMenu("Drawings");
            {
                DrawMenu.AddGroupLabel("Draw Settings");
                DrawMenu.Add("Qdr", new CheckBox("Draw Q"));
                DrawMenu.Add("Wdr", new CheckBox("Draw W"));
                DrawMenu.Add("Edr", new CheckBox("Draw E"));
                DrawMenu.Add("Rdr", new CheckBox("Draw R"));
            }

            LaneClear = CoreMenu.AddSubMenu("LaneClear");
            {
                LaneClear.AddGroupLabel("LaneClear Settings");
                LaneClear.Add("Qlc", new CheckBox("Use Q"));
                LaneClear.Add("Wlc", new CheckBox("Use W"));
                LaneClear.Add("Elc", new CheckBox("Use E"));
                LaneClear.Add("ManaMNGlc", new Slider("If mana percent below {0}% stop", 45, 0, 100));
            }

        }
    }
}
