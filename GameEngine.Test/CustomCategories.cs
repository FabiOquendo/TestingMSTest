using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GameEngine.Test
{
    public class PlayerDefaultsAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[] { "Player Defaults" };
    }

    public class PlayerHealthAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[] { "Player Health" };
    }

    public class PlayerNameAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[] { "Player Name" };
    }

    public class PlayerWeaponsAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[] { "Player Weapons" };
    }
}
