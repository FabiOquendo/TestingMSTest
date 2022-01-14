using System.Collections.Generic;

namespace GameEngine.Test
{
    class DamageData
    {
        public static IEnumerable<object[]> GetDamages()
        {
            return new List<object[]>
            {
                new object[] {0, 100},
                new object[] {3, 97},
                new object[] {50, 50},
                new object[] {95, 5},
                new object[] {100, 1},
            };
        }
    }
}
